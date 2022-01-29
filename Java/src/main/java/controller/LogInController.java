package controller;

import domain.Angajat;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.scene.paint.Color;
import javafx.stage.Stage;
import service.Service;

import java.io.IOException;

public class LogInController {


    @FXML
    private Label lblStatus;
    @FXML
    private TextField txtUsername;
    @FXML
    private PasswordField txtParola;

    Angajat angajat;
    Service service;
    Stage stage;

    public void setService(Service service, Stage stage) {
        this.service = service;
        this.stage = stage;


    }

    public void initializeUser() {
        this.angajat = service.findOne(txtUsername.getText());
    }

    public void loadMainStage() throws IOException {

        Stage newStage = new Stage();
        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(getClass().getResource("/views/MainPage.fxml"));
        AnchorPane layout = loader.load();
        newStage.setScene(new Scene(layout));
//        newStage.setTitle("MeetLy");
        newStage.show();

        MainController mainController = loader.getController();
        mainController.setService(service, angajat, stage, newStage);
    }

    @FXML
    public void signIn() throws IOException {
        if (txtUsername.getText().length()!=0 &&
                txtParola.getText().length()!=0
                && service.getAngajat(txtUsername.getText(), txtParola.getText())!=null) {
            initializeUser();
            loadMainStage();
            stage.close();
        }
        else {
            lblStatus.setText("Sign in failed");
            lblStatus.setTextFill(Color.web("#ba170b"));
        }
    }
}
