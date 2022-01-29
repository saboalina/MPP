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

public class ClientRpcWorker implements Runnable, Observer {
    private Service server;
    private Socket connection;

    private ObjectInputStream input;
    private ObjectOutputStream output;
    private volatile boolean connected;
    public ClientRpcWorker(Service server, Socket connection) {
        this.server = server;
        this.connection = connection;
        try{
            output=new ObjectOutputStream(connection.getOutputStream());
            output.flush();
            input=new ObjectInputStream(connection.getInputStream());
            connected=true;
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public void run() {
        while(connected){
            try {
                Object request=input.readObject();
                Response response=handleRequest((Request)request);
                if (response!=null){
                    sendResponse(response);
                }
            } catch (IOException e) {
                e.printStackTrace();
            } catch (ClassNotFoundException e) {
                e.printStackTrace();
            }
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        try {
            input.close();
            output.close();
            connection.close();
        } catch (IOException e) {
            System.out.println("Error "+e);
        }
    }


    private static Response okResponse=new Response.Builder().type(ResponseType.OK).build();
    //  private static Response errorResponse=new Response.Builder().type(ResponseType.ERROR).build();
    private Response handleRequest(Request request){
        Response response=null;

        if (request.type()== RequestType.LOGIN){
            System.out.println("Login request ..."+request.type());
            Employee employee=(Employee) request.data();
            try {
                server.login(employee, this);
                return okResponse;
            } catch (ValidationException e) {
                connected=false;
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }

        if (request.type()== RequestType.LOGOUT){
            System.out.println("Logout request..."+request.type());
            Employee employee=(Employee) request.data();
            try {
                server.logout(employee, this);
                connected=false;
                return okResponse;

            } catch (ValidationException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }

        if (request.type()== RequestType.GET_FLIGHTS){
            System.out.println("GetFlights Request ...");
            try {
                Iterable<Flight> list_flight= server.getAllFlights();
                return new Response.Builder().type(ResponseType.GET_FLIGHTS).data(list_flight).build();
            } catch (ValidationException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.GET_FILTERED){
            System.out.println("GetFiltered Request ...");
            Flight flight = (Flight) request.data();
            try {
                Iterable<Flight> list_flight= server.filter(flight.getDestination(), flight.getDepartureDate());
                return new Response.Builder().type(ResponseType.GET_FILTERED).data(list_flight).build();
            } catch (ValidationException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.GET_TICKETS){
            System.out.println("GetFlights Request ...");
            //ProbaDTO udto=(ProbaDTO)request.data();
            try {
                Iterable<Ticket> list_ticket= server.getAllTickets();
                return new Response.Builder().type(ResponseType.GET_TICKETS).data(list_ticket).build();
            } catch (ValidationException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        if (request.type()== RequestType.ADD_TICKET){
            System.out.println("SignUpRequest ...");
            Ticket ticket=(Ticket) request.data();
            try {
                server.addTicket(ticket, this);
                return okResponse;
            } catch (ValidationException e) {
                return new Response.Builder().type(ResponseType.ERROR).data(e.getMessage()).build();
            }
        }
        return response;
    }

    private void sendResponse(Response response) throws IOException {
        System.out.println("sending response "+response);
        output.writeObject(response);
        output.flush();
    }

    @Override
    public void ticketAdded(List<Flight> list_flight) {
        Response resp=new Response.Builder().type(ResponseType.ADD_TICKET).data(list_flight).build();
        try {
            sendResponse(resp);
        } catch (IOException e) {
            throw new ValidationException("Sending error: "+e);
        }
    }

}
