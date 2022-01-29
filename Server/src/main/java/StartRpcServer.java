import repository.EmployeeRepository;
import repository.FlightRepository;
import repository.TicketRepository;
import repository.jdbc.EmployeeDBRepository;
import repository.jdbc.FlightDBRepository;
import repository.jdbc.TicketDBRepository;
import server.ServiceImpl;
import service.Service;
import utils.AbstractServer;
import utils.RpcConcurrentServer;

import java.io.IOException;
import java.rmi.ServerException;
import java.util.Properties;

public class StartRpcServer {

    private static int defaultPort=55557;

    public static void main(String[] args) {
        Properties serverProps=new Properties();
        try {
            serverProps.load(StartRpcServer.class.getResourceAsStream("/server.properties"));
            System.out.println("Server properties set. ");
            serverProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find server.properties "+e);
            return;
        }

        EmployeeRepository employeeDBRepository=new EmployeeDBRepository(serverProps);
        FlightRepository flightDBRepository=new FlightDBRepository(serverProps);
        TicketRepository ticketDBRepository=new TicketDBRepository(serverProps);
        Service service =new ServiceImpl(employeeDBRepository, flightDBRepository, ticketDBRepository);

        int serverPort=defaultPort;
        try {
            serverPort = Integer.parseInt(serverProps.getProperty("server.port"));
        }catch (NumberFormatException nef){
            System.err.println("Wrong  Port Number"+nef.getMessage());
            System.err.println("Using default port "+defaultPort);
        }
        System.out.println("Starting server on port: "+serverPort);
        AbstractServer server = new RpcConcurrentServer(serverPort, service );
        try {
            server.start();
        } catch (ServerException e) {
            System.err.println("Error starting the server" + e.getMessage());
        }finally {
            try {
                server.stop();
            }catch(ServerException e){
                System.err.println("Error stopping server "+e.getMessage());
            }
        }
    }
}
