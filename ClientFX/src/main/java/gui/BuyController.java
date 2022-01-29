package gui;

import domain.Flight;
import domain.Ticket;
import javafx.fxml.FXML;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import service.Observer;
import service.Service;

import java.io.IOException;
import java.util.List;

public class BuyController implements Observer {

    Flight flight;
    Service service;
    Stage stage;

    @FXML
    private TextField txtClientName;
    @FXML
    private TextField txtTouristsName;
    @FXML
    private TextField txtClientAddress;
    @FXML
    private TextField txtNoSeats;

    public void setService(Flight flight,Service service, Stage stage) {
        this.flight=flight;
        this.service = service;
        this.stage = stage;
    }

    @FXML
    public void handleBuy() throws IOException {
        String clientName=txtClientName.getText();
        String touristsName=txtTouristsName.getText();
        String clientAddress=txtClientAddress.getText();
        Integer noSeats= Integer.valueOf(txtNoSeats.getText());
        Integer flightId=flight.getId();

        Ticket ticket=new Ticket(clientName,touristsName, clientAddress, noSeats, flightId);
        int i=0;
        for (Ticket t:service.getAllTickets())
            i++;
        ticket.setId(i+1);
        //addTicket(ticket);
    }

//    @Override
//    public void addTicket(Ticket ticket) {
//
//    }

    @Override
    public void ticketAdded(List<Flight> list_flight) {

    }
}
