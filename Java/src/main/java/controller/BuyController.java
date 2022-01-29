package controller;

import domain.Bilet;
import domain.Zbor;
import javafx.fxml.FXML;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import service.Service;

import java.io.IOException;

public class BuyController {

    Zbor zbor;
    Service service;
    Stage stage;

    @FXML
    private TextField txtNumeClient;
    @FXML
    private TextField txtNumeTuristi;
    @FXML
    private TextField txtAdresaClient;
    @FXML
    private TextField txtNrLocuri;

    public void setService(Zbor zbor,Service service, Stage stage) {
        this.zbor=zbor;
        this.service = service;
        this.stage = stage;
    }

    @FXML
    public void handleBuy() throws IOException {
        String numeClient=txtNumeClient.getText();
        String numeTuristi=txtNumeTuristi.getText();
        String adresaClient=txtAdresaClient.getText();
        Integer nrLocuri= Integer.valueOf(txtNrLocuri.getText());
        Integer zborId=zbor.getId();

        Bilet bilet=new Bilet(numeClient, numeTuristi,adresaClient,nrLocuri,zborId);
        int i=0;
        for (Bilet b:service.getAllBilete())
            i++;
        bilet.setId(i+1);
        service.addBilet(bilet);
    }
}
