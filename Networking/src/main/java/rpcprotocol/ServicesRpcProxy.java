package rpcprotocol;

import domain.Employee;
import domain.Flight;
import domain.Ticket;
import domain.validators.ValidationException;
import service.Observer;
import service.Service;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.Socket;
import java.util.List;
import java.util.concurrent.BlockingQueue;
import java.util.concurrent.LinkedBlockingQueue;

public class ServicesRpcProxy implements Service {

    private String host;
    private int port;

    private Observer client;
    private Observer clientSearch;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private Socket connection;

    private BlockingQueue<Response> qresponses;
    private volatile boolean finished;
    public ServicesRpcProxy(String host, int port) {
        this.host = host;
        this.port = port;
        qresponses=new LinkedBlockingQueue<Response>();
    }

    private void closeConnection() {
        finished=true;
        try {
            input.close();
            output.close();
            connection.close();
            client=null;
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    private void sendRequest(Request request)throws ValidationException {
        try {
            output.writeObject(request);
            output.flush();


        } catch (IOException e) {
            throw new ValidationException("Error sending object "+e);
        }

    }

    private Response readResponse() throws ValidationException {
        Response response=null;
        try{

            response=qresponses.take();

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        return response;
    }

    private void initializeConnection() throws ValidationException {
        try {
            connection=new Socket(host,port);
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input=new ObjectInputStream(connection.getInputStream());
            finished=false;
            startReader();
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void handleUpdate(Response response){
        if (response.type()== ResponseType.ADD_TICKET){
            List<Flight> list_flight= (List<Flight>) response.data();
            try {
                System.out.println("IN HANDLE UPDATE");
                client.ticketAdded(list_flight);
                clientSearch.ticketAdded(list_flight);
            } catch (ValidationException e) {
                e.printStackTrace();
            }
        }
    }

    private boolean isUpdate(Response response){
        return response.type()== ResponseType.ADD_TICKET;
    }

    private void startReader(){
        Thread tw=new Thread(new ReaderThread());
        tw.start();
    }

    @Override
    public Employee findOne(String username) {
        return null;
    }

    @Override
    public Iterable<Employee> findAll() {
        return null;
    }

    @Override
    public Employee getEmployee(String username, String password) {
        return null;
    }

    @Override
    public Iterable<Flight> getAllFlights() {
        Request req=new Request.Builder().type(RequestType.GET_FLIGHTS).data(null).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new ValidationException(err);
        }
        List<Flight> list_flight= (List<Flight>) response.data();
        return list_flight;
    }

    @Override
    public Iterable<Ticket> getAllTickets() {
        Request req=new Request.Builder().type(RequestType.GET_TICKETS).data(null).build();
        //Request req=new Request.Builder().type(RequestType.LOGIN).data(employee).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new ValidationException(err);
        }
        List<Ticket> list_ticket= (List<Ticket>) response.data();
        return list_ticket;
    }

    @Override
    public List<Flight> filter(String destination, String departureDate) {
        Flight flight=new Flight(destination, departureDate, "","",0);
        Request req=new Request.Builder().type(RequestType.GET_FILTERED).data(flight).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new ValidationException(err);
        }
        List<Flight> list_flight= (List<Flight>) response.data();
        return list_flight;
    }

    @Override
    public void login(Employee employee, Observer client) {
        initializeConnection();
        Request req=new Request.Builder().type(RequestType.LOGIN).data(employee).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.OK){
            this.client=client;
            return;
        }
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            closeConnection();
            throw new ValidationException(err);
        }
    }

    @Override
    public void logout(Employee employee, Observer client) {
        Request req=new Request.Builder().type(RequestType.LOGOUT).data(employee).build();
        sendRequest(req);
        Response response=readResponse();
        closeConnection();
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            throw new ValidationException(err);
        }
    }

    @Override
    public void addTicket(Ticket ticket, Observer clientSearch) {
        Request req=new Request.Builder().type(RequestType.ADD_TICKET).data(ticket).build();
        sendRequest(req);
        Response response=readResponse();
        if (response.type()== ResponseType.OK){
            this.clientSearch=clientSearch;
            return;
        }
        if (response.type()== ResponseType.ERROR){
            String err=response.data().toString();
            closeConnection();
            throw new ValidationException(err);
        }
    }

    private class ReaderThread implements Runnable{
        public void run() {
            while(!finished){
                try {
                    Object response=input.readObject();
                    System.out.println("response received "+response);
                    if (isUpdate((Response)response)){
                        handleUpdate((Response)response);
                    }else{

                        try {
                            qresponses.put((Response)response);
                        } catch (InterruptedException e) {
                            e.printStackTrace();
                        }
                    }
                } catch (IOException e) {
                    System.out.println("Reading error "+e);
                } catch (ClassNotFoundException e) {
                    System.out.println("Reading error "+e);
                }
            }
        }
    }
}
