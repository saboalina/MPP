package gui;

import domain.Employee;
import domain.validators.ValidationException;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.scene.Node;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import javafx.stage.WindowEvent;
import service.Service;

import java.io.IOException;

public class LogInController {

    @FXML
    private Label lblStatus;
    @FXML
    private TextField txtUsername;
    @FXML
    private PasswordField txtPassword;

    Employee employee;
    Service service;
    Stage stage;
    MainController mainCtrl;

    Parent mainParent;

    public void setServer(Service service) {
        //this.stage = stage;
        this.service = service;
    }

    public void setService(Service service) {
        this.service = service;
        //this.stage = stage;
    }

    public void setParent(Parent p){
        mainParent=p;
    }

    public void setMainController(MainController chatController) {
        this.mainCtrl = chatController;
    }

    public void initializeUser() {
        this.employee = service.findOne(txtUsername.getText());
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
        //mainController.setService(service, employee, stage, newStage);
    }

//    @FXML
//    public void signIn() throws IOException {
//        if (txtUsername.getText().length()!=0 &&
//                txtPassword.getText().length()!=0
//                && service.getEmployee(txtUsername.getText(), txtPassword.getText())!=null) {
//            //initializeUser();
//            loadMainStage();
//            stage.close();
//        }
//        else {
//            lblStatus.setText("Sign in failed");
//            lblStatus.setTextFill(Color.web("#ba170b"));
//        }
//    }

    @FXML
    public void logIn(ActionEvent actionEvent) {

        //Parent root;
        String username = txtUsername.getText();
        String password = txtPassword.getText();
        Employee employee1 = new Employee("", password);
        employee1.setId(username);

        if(employee1==null){
            MessageAlert.showMessage(null, Alert.AlertType.INFORMATION, "Logare esuata!", "Acest utilizator nu exista");

        }else{
            try{
                service.login(employee1, mainCtrl);
                // Util.writeLog("User succesfully logged in "+crtUser.getId());
                Stage stage=new Stage();
                stage.setTitle("Chat Window for " +employee1.getId());
                stage.setScene(new Scene(mainParent));

                stage.setOnCloseRequest(new EventHandler<WindowEvent>() {
                    @Override
                    public void handle(WindowEvent event) {
                        mainCtrl.logout();
                        System.exit(0);
                    }
                });

                mainCtrl.initialize();
                stage.show();
                mainCtrl.setUser(employee1);
                //mainCtrl.setLoggedFriends();
                ((Node)(actionEvent.getSource())).getScene().getWindow().hide();

            }   catch (ValidationException e) {
                Alert alert = new Alert(Alert.AlertType.INFORMATION);
                alert.setTitle("MPP chat");
                alert.setHeaderText("Authentication failure");
                alert.setContentText("Wrong username or password");
                alert.showAndWait();
            }
        }


    }
}
