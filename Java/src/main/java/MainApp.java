import controller.LogInController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.AnchorPane;
import javafx.stage.Stage;
import repository.AngajatDBRepository;
import repository.BiletDBRepository;
import repository.ZborDBRepository;
import service.Service;

import java.io.FileReader;
import java.io.IOException;
import java.util.Properties;

public class MainApp extends Application {
    public static void main(String[] args) {
            launch(args);
//        Properties props=new Properties();
//        try {
//            props.load(new FileReader("bd.properties"));
//        } catch (IOException e) {
//            System.out.println("Cannot find bd.config "+e);
//        }
//
//        AngajatDBRepository angajatRepo=new AngajatDBRepository(props);
//        Angajat angajat =new Angajat("numeAngajat100", "prenumeAngajat100","parola100");
//        angajat.setId("username100");
//
//        Service service =new Service(angajatRepo);
//        System.out.println(service.getAngajat("username2", "parola2"));
//        //angajatRepo.save(angajat);
////        System.out.println("Angajatii din baza de date:");
////        for(Angajat a:angajatRepo.findAll())
////            System.out.println(a);
//
//        BiletRepository biletRepo=new BiletDBRepository(props);
//        Bilet bilet=new Bilet("numeClient100", "numeTuristi100", "adresaClient100", 100, 100);
//        bilet.setId(100);
////        biletRepo.save(bilet);
////        System.out.println("Biletele din baza de date:");
////        for(Bilet b:biletRepo.findAll())
////            System.out.println(b);
//
//        ZborRepository zborRepo=new ZborDBRepository(props);
//        String str="2015-03-31";
//        Date date= java.sql.Date.valueOf(str);
//        Zbor zbor=new Zbor("destinatie100", (java.sql.Date) date, "aeroport100",100);
//        zbor.setId(100);
////        zborRepo.save(zbor);
////        System.out.println("Zborurile din baza de date:");
////        for(Zbor z:zborRepo.findAll())
////            System.out.println(z);

    }

    public void start(Stage primaryStage) throws Exception {
        Properties props=new Properties();
        try {
            props.load(new FileReader("bd.properties"));
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
        }

        AngajatDBRepository angajatRepo=new AngajatDBRepository(props);
        ZborDBRepository zborRepo=new ZborDBRepository(props);
        BiletDBRepository biletRepo=new BiletDBRepository(props);
//        Angajat angajat =new Angajat("numeAngajat100", "prenumeAngajat100","parola100");
//        angajat.setId("username100");

        Service service =new Service(angajatRepo, zborRepo, biletRepo);
       // System.out.println(service.getAngajat("username2", "parola2"));

        initView(primaryStage, service);
        primaryStage.show();
    }


    private void initView(Stage primaryStage, Service service) throws Exception {
        //login
        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(getClass().getResource("/views/LogInPage.fxml"));
        AnchorPane layout = loader.load();
        primaryStage.setScene(new Scene(layout));
//        primaryStage.getIcons().add(new Image("images/app_icon.png"));
//        primaryStage.setTitle("MeetLy");
        LogInController loginController = loader.getController();
        loginController.setService(service, primaryStage);
    }
}
