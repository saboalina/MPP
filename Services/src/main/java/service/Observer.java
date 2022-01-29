package service;

import domain.Flight;

import java.util.List;

public interface Observer {
    void ticketAdded(List<Flight> list_flight);

}
