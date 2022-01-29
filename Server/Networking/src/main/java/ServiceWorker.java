import domain.Employee;
import domain.Flight;
import domain.Ticket;
import org.apache.thrift.TException;
import org.apache.thrift.protocol.TBinaryProtocol;
import org.apache.thrift.protocol.TProtocol;
import org.apache.thrift.transport.TSocket;
import org.apache.thrift.transport.TTransport;
import server.Service;
import service.IService;

import java.util.ArrayList;
import java.util.List;

public class ServiceWorker implements IService.Iface {
    private String host;
    private int port;

    private Service service;
    private List<Integer> ports = new ArrayList<>();
    private List<MainWindowController.Client> observers = new ArrayList<>();
    private List<TTransport> transports = new ArrayList<>();

    public ServiceWorker(String host, int port, Service service) {
        this.host = host;
        this.port = port;
        this.service = service;
    }

    @Override
    public Employee findOne(String username) throws TException {
        return service.findOne(username);
    }

    @Override
    public List<Employee> findAll() throws TException {
        return (List<Employee>) service.findAll();
    }

    @Override
    public Employee getEmployee(String username, String password) throws TException {
        return service.getEmployee(username, password);
    }

    @Override
    public List<Flight> getAllFlights() throws TException {
        return (List<Flight>) service.getAllFlights();
    }

    @Override
    public List<Ticket> getAllTickets() throws TException {
        return (List<Ticket>) service.getAllTickets();
    }

    @Override
    public List<Flight> filter(String airport, String departureDate) throws TException {
        return service.filter(airport,departureDate);
    }

    @Override
    public void login(Employee employee) throws TException {
        service.login(employee);
    }

    @Override
    public void logout(int port) throws TException {
        removeObserver(port);
    }

    @Override
    public void addTicket(Ticket ticket) throws TException {
        service.addTicket(ticket);
    }

    @Override
    public void addObserver(int port) throws TException {
        TTransport transport = new TSocket("localhost", port);
        transport.open();
        TProtocol protocol = new TBinaryProtocol(transport);
        MainWindowController.Client client = new MainWindowController.Client(protocol);
        observers.add(client);
        transports.add(transport);
        ports.add(port);
    }

    @Override
    public void removeObserver(int port) throws TException {
        int index = ports.indexOf(port);
        observers.remove(index);
        transports.remove(index);
        ports.remove(index);
    }

    @Override
    public void notifyServer() throws TException {
        for (MainWindowController.Client client : observers) {
            client.update((List<Flight>) service.getAllFlights());
        }
    }
}
