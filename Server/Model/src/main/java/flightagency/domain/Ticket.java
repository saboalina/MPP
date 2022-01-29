package flightagency.domain;

import java.io.Serializable;

public class Ticket extends Entity<Integer> implements Serializable {

    private String clientName, touristsName, clientAddress;
    private Integer noSeats, flightId;

    public Ticket(String clientName, String touristsName, String clientAddress, Integer noSeats, Integer flightId) {
        this.clientName = clientName;
        this.touristsName = touristsName;
        this.clientAddress = clientAddress;
        this.noSeats = noSeats;
        this.flightId = flightId;
    }

    public String getClientName() {
        return clientName;
    }

    public void setClientName(String clientName) {
        this.clientName = clientName;
    }

    public String getTouristsName() {
        return touristsName;
    }

    public void setTouristsName(String touristsName) {
        this.touristsName = touristsName;
    }

    public String getClientAddress() {
        return clientAddress;
    }

    public void setClientAddress(String clientAddress) {
        this.clientAddress = clientAddress;
    }

    public Integer getNoSeats() {
        return noSeats;
    }

    public void setNoSeats(Integer noSeats) {
        this.noSeats = noSeats;
    }

    public Integer getFlightId() {
        return flightId;
    }

    public void setFlightId(Integer flightId) {
        this.flightId = flightId;
    }

    @Override
    public String toString() {
        return "Ticket{" +
                "clientName='" + clientName + '\'' +
                ", touristsName='" + touristsName + '\'' +
                ", clientAddress='" + clientAddress + '\'' +
                ", noSeats=" + noSeats +
                ", flightId=" + flightId +
                '}';
    }
}

