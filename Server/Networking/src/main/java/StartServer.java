import org.apache.thrift.server.TServer;
import org.apache.thrift.server.TThreadPoolServer;
import org.apache.thrift.transport.TServerSocket;
import org.apache.thrift.transport.TServerTransport;
import org.apache.thrift.transport.TTransportException;
import repository.EmployeeRepository;
import repository.FlightRepository;
import repository.TicketRepository;
import repository.jdbc.EmployeeDBRepository;
import repository.jdbc.FlightDBRepository;
import repository.jdbc.TicketDBRepository;
import server.Service;
import service.IService;

import java.io.FileInputStream;
import java.io.IOException;
import java.util.Properties;

public class StartServer {
    public static void main(String[] args) throws TTransportException {


        Properties properties = new Properties();
        try {
            properties.load(new FileInputStream("C:\\Users\\user\\Desktop\\labMpp\\JavaServer\\db.properties"));
        } catch (IOException e) {
            e.printStackTrace();
        }

        EmployeeRepository employeeDBRepository=new EmployeeDBRepository(properties);
        FlightRepository flightDBRepository=new FlightDBRepository(properties);
        TicketRepository ticketDBRepository=new TicketDBRepository(properties);
        Service service = new Service(employeeDBRepository, flightDBRepository, ticketDBRepository);

        ServiceWorker proxy = new ServiceWorker("localhost", 9090, service);
        IService.Processor<ServiceWorker> processor = new IService.Processor<ServiceWorker>(proxy);

        TServerTransport transport = new TServerSocket(9090);
        TServer server = new TThreadPoolServer(new TThreadPoolServer.Args(transport).processor(processor));

        System.out.println("Server started!");
        server.serve();
    }
}
