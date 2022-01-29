package repository;

import domain.Angajat;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.io.IOException;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class AngajatDBRepository implements AngajatRepository{

    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public AngajatDBRepository(Properties props) {
        logger.info("Initializing CarsDBRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }

    @Override
    public Angajat findOne(String username) {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Angajati where idAngajat=?")) {
            preStmt.setString(1, username);
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    String username1 = result.getString("idAngajat");
                    String nume =  result.getString("Nume");
                    String prenume = result.getString("Prenume");
                    String parola = result.getString("Parola");
                    Angajat angajat = new Angajat(nume, prenume, parola);
                    angajat.setId(username);
                    return angajat;
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit();
        return null;
    }

    @Override
    public Iterable<Angajat> findAll() {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Angajat> angajati = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Angajati")) {
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    String username = result.getString("idAngajat");
                    String nume =  result.getString("Nume");
                    String prenume = result.getString("Prenume");
                    String parola = result.getString("Parola");
                    Angajat angajat = new Angajat(nume, prenume, parola);
                    angajat.setId(username);
                    angajati.add(angajat);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit(angajati);
        return angajati;
    }

    @Override
    public Angajat save(Angajat entity) {
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into Angajati (idAngajat, Nume, Prenume, Parola) values (?,?,?,?)")){
            preStmt.setString(1, entity.getId());
            preStmt.setString(2, entity.getNume());
            preStmt.setString(3, entity.getPrenume());
            preStmt.setString(4, entity.getParola());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances", result);
        } catch (SQLException ex) {
            logger.error(ex);
            System.err.println("Error DB " + ex);
        }
        logger.traceExit();
        return entity;
    }

   @Override
    public Angajat delete(String s) throws IOException {
        return null;
    }
}
