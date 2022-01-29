package server;

import domain.Employee;
import domain.Flight;
import domain.Ticket;
import domain.validators.ValidationException;
import repository.EmployeeRepository;
import repository.FlightRepository;
import repository.TicketRepository;
import service.Observer;
import service.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class ServiceImpl implements Service {

    private EmployeeRepository employeeRepository;
    private FlightRepository flightRepository;
    private TicketRepository ticketRepository;
    private Map<String, Observer> loggedEmployee;

    public ServiceImpl(EmployeeRepository employeeRepository, FlightRepository flightRepository, TicketRepository ticketRepository) {
        this.employeeRepository = employeeRepository;
        this.flightRepository = flightRepository;
        this.ticketRepository = ticketRepository;
        loggedEmployee=new ConcurrentHashMap<>();
    }

    @Override
    public Employee findOne(String username) {
        return employeeRepository.findOne(username);
    }

    @Override
    public Iterable<Employee> findAll() {
        return employeeRepository.findAll();
    }

    @Override
    public Employee getEmployee(String username, String password) {
        for (Employee e:findAll())
            if(e.getId().equals(username) && e.getPassword().equals(password))
                return e;
        return null;
    }

    @Override
    public Iterable<Flight> getAllFlights() {
        return flightRepository.findAll();
    }

    @Override
    public Iterable<Ticket> getAllTickets() {
        return ticketRepository.findAll();
    }

    @Override
    public List<Flight> filter(String airport, String departureDate) {
        return flightRepository.filter(airport, departureDate);
    }

    @Override
    public void login(Employee employee, Observer client) {
        Employee userR=getEmployee(employee.getId(),employee.getPassword());
        if (userR!=null){
            if(loggedEmployee.size()!=0 && loggedEmployee.get(userR.getId())!=null)
                throw new ValidationException("User already logged in.");
            loggedEmployee.put(userR.getId(), client);
        }else
            throw new ValidationException("Authentication failed.");
    }

    @Override
    public void logout(Employee employee, Observer client) {
        Observer localClient=loggedEmployee.remove(employee.getId());
        if (localClient==null)
            throw new ValidationException("User "+employee.getId()+" is not logged in.");
    }

    @Override
    public void addTicket(Ticket ticket, Observer clientSearch) {
        ticketRepository.save(ticket);
        Flight flight= flightRepository.findOne(ticket.getFlightId());
        flight.setAvailableSeats(flight.getAvailableSeats()-ticket.getNoSeats());
        flightRepository.update(flight);

        notifyAddTicket();
    }

    public List<Employee> getLoggedEmployees() {
        List<Employee> angajati=new ArrayList<>();

        for (Employee angajat : employeeRepository.findAll()){
            if (loggedEmployee.containsKey(angajat.getId())){//the employee is logged in
                Employee angajat1=new Employee(angajat.getId(),angajat.getPassword());
                angajat1.setId(angajat.getId());
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
            Observer client = loggedEmployee.get(angajat.getId());
            if (client != null)
                executor.execute(() -> {
                try {
                    System.out.println("Notifying [" + angajat.getId() + "]");
                    client.ticketAdded((List<Flight>) getAllFlights());
                } catch (ValidationException e) {
                    System.err.println("Error notifying employee " + e);
                }
                });

        }

        executor.shutdown();
    }
}
