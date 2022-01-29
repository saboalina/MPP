package domain;

import java.io.Serializable;
import java.time.LocalDate;

public class Flight extends Entity<Integer> implements Serializable {

    private String destination, departureDate, departureTime, airport;
    private Integer availableSeats;
    private LocalDate date;

    public Flight(String destination, String departureDate, String departureTime, String airport, Integer availableSeats) {
        this.destination = destination;
        this.departureDate = departureDate;
        this.departureTime = departureTime;
        this.airport = airport;
        this.availableSeats = availableSeats;
    }

    public String getDestination() {
        return destination;
    }

    public void setDestination(String destination) {
        this.destination = destination;
    }

    public String getDepartureDate() {
        return departureDate;
    }

    public void setDepartureDate(String departureDate) {
        this.departureDate = departureDate;
    }

    public String getDepartureTime() {
        return departureTime;
    }

    public void setDepartureTime(String departureTime) {
        this.departureTime = departureTime;
    }

    public String getAirport() {
        return airport;
    }

    public void setAirport(String airport) {
        this.airport = airport;
    }

    public Integer getAvailableSeats() {
        return availableSeats;
    }

    public void setAvailableSeats(Integer available_seats) {
        this.availableSeats = available_seats;
    }

    public String getAvailableSeatsString(){
        return availableSeats+"";
    }

    @Override
    public String toString() {
        return "Flight{" +
                "destination='" + destination + '\'' +
                ", departureDate='" + departureDate + '\'' +
                ", departureTime='" + departureTime + '\'' +
                ", airport='" + airport + '\'' +
                ", available_seats=" + availableSeats +
                '}';
    }
}
