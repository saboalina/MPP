package gui;

import domain.Employee;
import domain.Flight;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import service.Observer;
import service.Service;

import java.io.IOException;
import java.net.URL;
import java.util.List;
import java.util.ResourceBundle;

public class MainController implements Initializable, Observer {

    Employee employee;
    Service service;
    Stage stage;
    Stage previousStage;

    @FXML
    private TableView<Flight> tableFlights;
    @FXML
    private TableColumn<Flight, String> destination;
    @FXML
    private TableColumn<Flight, String> departureDate;
    @FXML
    private TableColumn<Flight, String> departureTime;
    @FXML
    private TableColumn<Flight, String> airport;
    @FXML
    private TableColumn<Flight, String> noSeats;

    ObservableList<Flight> zboruriTableModel = FXCollections.observableArrayList();

    public void setService(Service service) {
        this.service = service;
    }

    public void initialize() {
        initFriendshipTableModel();
        initializeFriendsTable();
    }

    private void initializeFriendsTable() {
        destination.setCellValueFactory(new PropertyValueFactory<>("Destination"));
        departureDate.setCellValueFactory(new PropertyValueFactory<>("DepartureDate"));
        departureTime.setCellValueFactory(new PropertyValueFactory<>("DepartureTime"));
        airport.setCellValueFactory(new PropertyValueFactory<>("Airport"));
        noSeats.setCellValueFactory(new PropertyValueFactory<>("AvailableSeatsString"));
        tableFlights.setItems(zboruriTableModel);
    }

    private void initFriendshipTableModel() {
        List<Flight> zboruri = (List<Flight>) service.getAllFlights();
        zboruriTableModel.setAll(zboruri);
    }

    @FXML
    private void loadSearchStage() throws IOException {
        Stage newStage = new Stage();
        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(getClass().getResource("/views/SearchPage.fxml"));
        AnchorPane layout = loader.load();
        newStage.setScene(new Scene(layout));

        SearchController searchController = loader.getController();
        searchController.setService(service, newStage);
        searchController.setMainController(this);

        newStage.show();
    }

    public void initModel() {
    }

    public void setUser(Employee employee) {
        this.employee=employee;
    }

    public void logout() {
        service.logout(employee, this);
    }

    public void handleLogout(ActionEvent actionEvent) {
        logout();
        ((Node)(actionEvent.getSource())).getScene().getWindow().hide();
    }

    @Override
    public void initialize(URL location, ResourceBundle resources) {

    }

//    @Override
//    public void addTicket(Ticket ticket) {
//
//        tableFlights.getItems().clear();
//        for(Flight dto:service.getAllFlights()){
//            tableFlights.getItems().add(dto);
//        }
//    }


    @Override
    public void ticketAdded(List<Flight> list_flight) {
        //tableFlights.getItems().clear();
        zboruriTableModel.clear();
        zboruriTableModel.addAll(list_flight);
    }
}
