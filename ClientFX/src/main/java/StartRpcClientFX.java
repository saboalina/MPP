import gui.LogInController;
import gui.MainController;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import rpcprotocol.ServicesRpcProxy;
import service.Service;

import java.io.IOException;
import java.util.Properties;

public class StartRpcClientFX extends Application {
    private Stage primaryStage;

    private static int defaultChatPort = 55557;
    private static String defaultServer = "localhost";


    public void start(Stage primaryStage) throws Exception {
        System.out.println("In start");
        Properties clientProps = new Properties();
        try {
            clientProps.load(StartRpcClientFX.class.getResourceAsStream("/client.properties"));
            System.out.println("Client properties set. ");
            clientProps.list(System.out);
        } catch (IOException e) {
            System.err.println("Cannot find client.properties " + e);
            return;
        }
        String serverIP = clientProps.getProperty("server.host", defaultServer);
        int serverPort = defaultChatPort;

        try {
            serverPort = Integer.parseInt(clientProps.getProperty("server.port"));
        } catch (NumberFormatException ex) {
            System.err.println("Wrong port number " + ex.getMessage());
            System.out.println("Using default port: " + defaultChatPort);
        }
        System.out.println("Using server IP " + serverIP);
        System.out.println("Using server port " + serverPort);

        Service server = new ServicesRpcProxy(serverIP, serverPort);

        FXMLLoader loader = new FXMLLoader();
        loader.setLocation(getClass().getResource("/views/LoginPage.fxml"));
        Parent root = loader.load();


        LogInController loginController =
                loader.<LogInController>getController();
        loginController.setService(server);

        FXMLLoader cloader = new FXMLLoader();
        cloader.setLocation(getClass().getResource("/views/MainPage.fxml"));
        Parent croot=cloader.load();

        MainController mainController =
                cloader.<MainController>getController();
        mainController.setService(server);

        loginController.setMainController(mainController);
        loginController.setParent(croot);


        primaryStage.setTitle("Flight Agency");
        primaryStage.setScene(new Scene(root));
        primaryStage.show();
    }
}
