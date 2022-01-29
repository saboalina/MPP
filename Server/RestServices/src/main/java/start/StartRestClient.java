package start;

import flightagency.domain.Flight;
import flightagency.services.rest.ServiceException;
import org.springframework.web.client.RestClientException;
import org.springframework.web.client.RestTemplate;
import rest.client.FlightClient;

public class StartRestClient {
    private final static FlightClient flightClient = new FlightClient();
    public static void main(String[] args) {
        RestTemplate restTemplate=new RestTemplate();
        Flight flight = new Flight("dest2", "date2", "time2", "airport2", 150);
        flight.setId(999);
        try{
            show(()-> System.out.println(flightClient.create(flight)));
            show(()->{
                Flight[] res=flightClient.getAll();
                for(Flight f:res) {
                    System.out.println(f.getId() + ": " + f.getDestination()+ ": " + f.getAvailableSeats());
                }
                System.out.println("/n");
            });

            show(()-> flightClient.delete(String.valueOf(flight.getId())));
            show(()->{
                Flight[] res=flightClient.getAll();
                for(Flight f:res) {
                    System.out.println(f.getId() + ": " + f.getDestination()+ ": " + f.getAvailableSeats());
                }
                System.out.println("/n");
            });

        }catch (RestClientException ex){
            System.out.println("Exception..."+ex.getMessage());
        }
    }

    private static void show(Runnable task){
        try {
            task.run();
        } catch (ServiceException e) {
            System.out.println("Service exception"+ e);
        }
    }
}
