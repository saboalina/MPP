package service;

import domain.Employee;
import domain.Flight;
import domain.Ticket;

import java.util.List;

public interface Service {

    Employee findOne(String username);

    Iterable<Employee> findAll();

    Employee getEmployee(String username, String password);

    Iterable<Flight> getAllFlights();

    Iterable<Ticket> getAllTickets();

    List<Flight> filter(String airport, String departureDate);

    void login(Employee employee, Observer client);

    void logout(Employee employee, Observer client);

    void addTicket(Ticket ticket, Observer clientSearch);
}
