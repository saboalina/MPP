package gui;

import domain.Flight;
import domain.Ticket;
import javafx.application.Platform;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.*;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.stage.Stage;
import service.Observer;
import service.Service;

import java.io.IOException;
import java.time.format.DateTimeFormatter;
import java.util.List;
import java.util.stream.Collectors;

public class SearchController implements Observer {

    @FXML
    private TableView<Flight> tableFlights;
    @FXML
    private TableColumn<Flight, String> destination;
    @FXML
    private TableColumn<Flight, String> departureTime;
    @FXML
    private TableColumn<Flight, String> noSeats;

    @FXML
    private TextField txtDestination;
    @FXML
    private DatePicker date;

    @FXML
    private TextField txtClientName;
    @FXML
    private TextField txtTouristsName;
    @FXML
    private TextField txtClientAddress;
    @FXML
    private TextField txtNoSeats;

    Service service;
    Stage stage;
    MainController mainController;

    ObservableList<Flight> zboruriTableModel = FXCollections.observableArrayList();

    public void setService(Service service, Stage stage) {
        this.service = service;
        this.stage = stage;

    }

    @FXML
    public void initialize() {
    }

    public void setMainController(MainController chatController) {
        this.mainController = chatController;
    }

    private void initializeZboruriTable() {
        destination.setCellValueFactory(new PropertyValueFactory<>("Destination"));
        departureTime.setCellValueFactory(new PropertyValueFactory<>("DepartureTime"));
        noSeats.setCellValueFactory(new PropertyValueFactory<>("AvailableSeatsString"));
        tableFlights.setItems(zboruriTableModel);
    }

    private void initZboruriTableModel() {
        String dateFormat=date.getValue().format(DateTimeFormatter.ofPattern("yyyy-MM-dd"));
        List<Flight> zboruri = service.filter(txtDestination.getText(),dateFormat);
        zboruriTableModel.setAll(zboruri);
    }

    @FXML
    private void loadBuyStage() throws IOException {
//        Stage newStage = new Stage();
//        FXMLLoader loader = new FXMLLoader();
//        loader.setLocation(getClass().getResource("/views/BuyPage.fxml"));
//        AnchorPane layout = loader.load();
//        newStage.setScene(new Scene(layout));

//        try {
//            List<Proba> probeOk = new ArrayList<>();
//            for (DTO dto : probe) {
//                Proba proba = new Proba(dto.getDistanta(), dto.getStil());
//                proba.setId(dto.getId());
//                probeOk.add(proba);
//            }
//            service.inscriereParticipant(textFieldNume.getText(), Integer.parseInt(textFieldVarsta.getText()), probeOk, crtAngajat.getId().toString());
//            mainController.participantInscris(textFieldNume.getText(),Integer.parseInt(textFieldVarsta.getText()), probeOk);
//            MessageAlert.showMessage(null, Alert.AlertType.INFORMATION, "Felicitari!", "Inscriere realizata cu succes!");
//        }
//        catch (ValidationException e){
//            MessageAlert.showMessage(null, Alert.AlertType.INFORMATION,"Inscriere esuata!",e.getMessage());
//        }


        Flight flight = tableFlights.getSelectionModel().getSelectedItem();

        if(flight==null){
            MessageAlert.showMessage(null, Alert.AlertType.INFORMATION, "Error!", "You must select a flight");

        }
        else{
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

            service.addTicket(ticket, this);


            //mainController.ticketAdded(ticket);
        }

    }

    @FXML
    public void handleSearch() {
        initZboruriTableModel();
        initializeZboruriTable();
    }

    @Override
    public void ticketAdded(List<Flight> list_flight) {
        Platform.runLater(new Runnable() {
            @Override
            public void run() {
                zboruriTableModel.clear();

                zboruriTableModel.addAll(list_flight.stream().filter(x->x.getDestination().equals(txtDestination.getText())).collect(Collectors.toList()));
            }
        });

    }
}
