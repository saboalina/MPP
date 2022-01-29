package flightagency.services.rest;

import flightagency.domain.Flight;
import flightagency.repository.FlightRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.stream.StreamSupport;

@RestController
@RequestMapping("/flightagency/flights")
public class FlightController {

    @Autowired
    private FlightRepository flightRepository;


    @RequestMapping(method = RequestMethod.GET)
    public Flight[] getAll(){
        return StreamSupport.stream(flightRepository.findAll().spliterator(), false).toArray(Flight[] :: new);
    }

    @RequestMapping(value = "/{id}", method = RequestMethod.GET)
    public ResponseEntity<?> getById(@PathVariable String id){

        Flight flight=flightRepository.findOne(Integer.valueOf(id));
        if (flight==null)
            return new ResponseEntity<String>("Flight not found", HttpStatus.NOT_FOUND);
        else
            return new ResponseEntity<Flight>(flight, HttpStatus.OK);
    }

    @RequestMapping(method = RequestMethod.POST)
    public Flight create(@RequestBody Flight flight){
        flightRepository.save(flight);
        return flight;
    }

    @RequestMapping(value = "/{id}", method = RequestMethod.PUT)
    public Flight update(@RequestBody Flight flight) {
        System.out.println("Updating flight ...");
        flightRepository.update(flight);
        return flight;
    }

    @RequestMapping(value="/{id}", method= RequestMethod.DELETE)
    public ResponseEntity<?> delete(@PathVariable Integer id){
        System.out.println("Deleting user ... "+id);
        try {
            flightRepository.delete(id);
            return new ResponseEntity<Flight>(HttpStatus.OK);
        }catch (Exception ex){
            System.out.println("Ctrl Delete user exception");
            return new ResponseEntity<String>(ex.getMessage(),HttpStatus.BAD_REQUEST);
        }
    }

    @RequestMapping("/{id}/destination")
    public String destination(@PathVariable Integer id){
        Flight result=flightRepository.findOne(id);
        System.out.println("Result ..."+result);

        return result.getDestination();
    }
}
