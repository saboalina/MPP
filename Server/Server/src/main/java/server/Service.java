package server;

import domain.Employee;
import domain.Flight;
import domain.Ticket;
import domain.validators.ValidationException;
import repository.EmployeeRepository;
import repository.FlightRepository;
import repository.TicketRepository;
import service.Observer;

import java.rmi.RemoteException;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Service {

    private EmployeeRepository employeeRepository;
    private FlightRepository flightRepository;
    private TicketRepository ticketRepository;
    private Map<String, Observer> loggedEmployee;

    public Service(EmployeeRepository employeeRepository, FlightRepository flightRepository, TicketRepository ticketRepository) {
        this.employeeRepository = employeeRepository;
        this.flightRepository = flightRepository;
        this.ticketRepository = ticketRepository;
        loggedEmployee=new ConcurrentHashMap<>();
    }

    public Employee findOne(String username) {
        return employeeRepository.findOne(username);
    }

    public Iterable<Employee> findAll() {
        return employeeRepository.findAll();
    }

    public Employee getEmployee(String username, String password) {
        for (Employee e:findAll())
            if(e.getUsername().equals(username) && e.getPassword().equals(password))
                return e;
        return null;
    }

    public Iterable<Flight> getAllFlights() {
        return flightRepository.findAll();
    }

    public Iterable<Ticket> getAllTickets() {
        return ticketRepository.findAll();
    }

    public List<Flight> filter(String airport, String departureDate) {
        return flightRepository.filter(airport, departureDate);
    }

    public void login(Employee employee) {
        Employee userR=getEmployee(employee.getUsername(),employee.getPassword());
        if (userR!=null){
            return;
        }else
            throw new ValidationException("Authentication failed.");
    }

    public void logout(Employee employee) {
        return;
    }

    public void addTicket(Ticket ticket) {
        ticketRepository.save(ticket);
        Flight flight= flightRepository.findOne(ticket.getFlightId());
        flight.setAvailableSeats(flight.getAvailableSeats()-ticket.getNoSeats());
        flightRepository.update(flight);

        //notifyAddTicket();
    }

    public List<Employee> getLoggedEmployees() {
        List<Employee> angajati=new ArrayList<>();

        for (Employee angajat : employeeRepository.findAll()){
            if (loggedEmployee.containsKey(angajat.getUsername())){//the employee is logged in
                Employee angajat1=new Employee(angajat.getUsername(),angajat.getPassword(), angajat.getName());
                angajat1.setUsername(angajat.getUsername());
                angajati.add(angajat1);
            }
        }
        System.out.println("Size "+angajati.size());
        return angajati;
    }

    private final int defaultThreadsNo=5;

    private void notifyAddTicket(){
        ExecutorService executor= Executors.newFixedThreadPool(defaultThreadsNo);
        for(Employee angajat:getLoggedEmployees()) {
            Observer client = loggedEmployee.get(angajat.getUsername());
            if (client != null)
                executor.execute(() -> {
                try {
                    System.out.println("Notifying [" + angajat.getUsername() + "]");
                    client.ticketAdded((List<Flight>) getAllFlights());
                } catch (ValidationException | RemoteException e) {
                    System.err.println("Error notifying employee " + e);
                }
                });

        }

        executor.shutdown();
    }

}
