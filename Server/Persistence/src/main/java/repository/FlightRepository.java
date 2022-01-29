package repository;

import domain.Flight;

import java.util.List;

public interface FlightRepository extends Repository<Integer, Flight>{
    void update(Flight flight);

    List<Flight> filter(String airport, String departureDate);
}
