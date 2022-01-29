package service;

import flightagency.domain.Flight;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

public interface Observer extends Remote {
    void ticketAdded(List<Flight> list_flight) throws RemoteException;

}
