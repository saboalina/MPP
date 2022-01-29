import domain.Angajat;
import domain.Bilet;
import domain.Zbor;
import repository.*;

import java.io.FileReader;
import java.io.IOException;
import java.util.Date;
import java.util.Properties;

public class Main {
    public static void main(String[] args) {

        Properties props=new Properties();
        try {
            props.load(new FileReader("bd.properties"));
        } catch (IOException e) {
            System.out.println("Cannot find bd.config "+e);
        }

        AngajatRepository angajatRepo=new AngajatDBRepository(props);
        Angajat angajat =new Angajat("numeAngajat100", "prenumeAngajat100","parola100");
        angajat.setId("username100");
        angajatRepo.save(angajat);
        System.out.println("Angajatii din baza de date:");
        for(Angajat a:angajatRepo.findAll())
            System.out.println(a);

        BiletRepository biletRepo=new BiletDBRepository(props);
        Bilet bilet=new Bilet("numeClient100", "numeTuristi100", "adresaClient100", 100, 100);
        bilet.setId(100);
        biletRepo.save(bilet);
        System.out.println("Biletele din baza de date:");
        for(Bilet b:biletRepo.findAll())
            System.out.println(b);

        ZborRepository zborRepo=new ZborDBRepository(props);
        String str="2015-03-31";
        Date date= java.sql.Date.valueOf(str);
        Zbor zbor=new Zbor("destinatie100", (java.sql.Date) date, "aeroport100",100);
        zbor.setId(100);
        zborRepo.save(zbor);
        System.out.println("Zborurile din baza de date:");
        for(Zbor z:zborRepo.findAll())
            System.out.println(z);

       }
}
