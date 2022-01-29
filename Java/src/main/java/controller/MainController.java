package controller;

import domain.Angajat;
import domain.Zbor;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.stage.Window;
import service.Service;

import java.io.IOException;
import java.util.List;
import java.util.stream.Collectors;

public class MainController {

    Angajat angajat;
    Service service;
    Stage stage;
    Stage previousStage;

    @FXML
    private TableView<Zbor> tableZboruri;
    @FXML
    private TableColumn<Zbor, String> zborDestinatie;
    @FXML
    private TableColumn<Zbor, String> zborDataSiOra;
    @FXML
    private TableColumn<Zbor, String> zborAeroport;
    @FXML
    private TableColumn<Zbor, String> zborNrLocuri;

    ObservableList<Zbor> zboruriTableModel = FXCollections.observableArrayList();

    public void setService(Service service, Angajat angajat, Stage previousStage, Stage stage) {
        this.service = service;
        this.angajat=angajat;
        this.previousStage = previousStage;
        this.stage = stage;

        initFriendshipTableModel();

    }

    @FXML
    public void initialize() {
        initializeFriendsTable();
//        initializeReceivedTable();
//        initializeSentTable();
    }



    private void initializeFriendsTable() {
        zborDestinatie.setCellValueFactory(new PropertyValueFactory<>("Destinatie"));
        zborDataSiOra.setCellValueFactory(new PropertyValueFactory<>("DataSiOraPlecariiString"));
        zborAeroport.setCellValueFactory(new PropertyValueFactory<>("Aeroport"));
        zborNrLocuri.setCellValueFactory(new PropertyValueFactory<>("NrLocuriDisponibileString"));
        tableZboruri.setItems(zboruriTableModel);
    }

    private void initFriendshipTableModel() {
        List<Zbor> zboruri = (List<Zbor>) service.getAllZboruri();
        zboruriTableModel.setAll(zboruri);
    }

    @FXML
    public void logOut() {
        List<Window> open = Stage.getWindows().stream().filter(Window::isShowing).collect(Collectors.toList());
        for (Window w : open)
            w.hide();
        stage.close();
        previousStage.show();
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

        newStage.show();
    }
//    ObservableList<User> friendsTableModel = FXCollections.observableArrayList();
}
