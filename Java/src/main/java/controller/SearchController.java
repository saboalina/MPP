package controller;

import domain.Zbor;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.DatePicker;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import service.Service;

import java.io.IOException;
import java.util.List;

public class SearchController {

    Service service;
    Stage stage;

    @FXML
    private TableView<Zbor> tableZboruri;
    @FXML
    private TableColumn<Zbor, String> zborDestinatie;
    @FXML
    private TableColumn<Zbor, String> zborDataSiOra;
    @FXML
    private TableColumn<Zbor, String> zborNrLocuri;
    @FXML
    private TextField txtDestinatie;
    @FXML
    private DatePicker dataPick;

    ObservableList<Zbor> zboruriTableModel = FXCollections.observableArrayList();

    public void setService(Service service, Stage stage) {
        this.service = service;
        this.stage = stage;

    }

    @FXML
    public void initialize() {
    }

    private void initializeZboruriTable() {
        zborDestinatie.setCellValueFactory(new PropertyValueFactory<>("Destinatie"));
        zborDataSiOra.setCellValueFactory(new PropertyValueFactory<>("DataSiOraPlecariiString"));
        zborNrLocuri.setCellValueFactory(new PropertyValueFactory<>("NrLocuriDisponibileString"));
        tableZboruri.setItems(zboruriTableModel);
    }

    private void initZboruriTableModel() {
        List<Zbor> zboruri = service.filterByAeroport(txtDestinatie.getText(), dataPick.getValue());
        zboruriTableModel.setAll(zboruri);
    }

    @FXML
    private void loadBuyStage() throws IOException {
        Stage newStage = new Stage();
        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(getClass().getResource("/views/BuyPage.fxml"));
        AnchorPane layout = loader.load();
        newStage.setScene(new Scene(layout));

        Zbor zbor = tableZboruri.getSelectionModel().getSelectedItem();


        BuyController buyController = loader.getController();
        buyController.setService(zbor,service, newStage);

        newStage.show();
    }

    @FXML
    public void handleSearch() {
        initZboruriTableModel();
        initializeZboruriTable();
    }
}
