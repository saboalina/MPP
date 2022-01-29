package repository;

import domain.Bilet;
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

public class BiletDBRepository implements BiletRepository{

    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public BiletDBRepository(Properties props) {
        logger.info("Initializing CarsDBRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }

    @Override
    public Bilet findOne(Integer integer) {
        return null;
    }

    @Override
    public Iterable<Bilet> findAll() {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Bilet> bilete = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Bilet")) {
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int idBilet=result.getInt("idBilet");
                    String numeClient = result.getString("NumeClient");
                    String numeTuristi =  result.getString("NumeTuristi");
                    String adresaClient = result.getString("AdresaClient");
                    int nrLocuri=result.getInt("nrLocuri");
                    int zborId=result.getInt("zborId");
                    Bilet bilet = new Bilet(numeClient, numeTuristi, adresaClient,nrLocuri, zborId);
                    bilet.setId(idBilet);
                    bilete.add(bilet);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit(bilete);
        return bilete;
    }

    @Override
    public Bilet save(Bilet entity) {
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into Bilet (idBilet, NumeClient, NumeTuristi, AdresaClient, nrLocuri, zborId) values (?,?,?,?,?,?)")){
            preStmt.setInt(1, entity.getId());
            preStmt.setString(2, entity.getNumeClient());
            preStmt.setString(3, entity.getNumeTuristi());
            preStmt.setString(4, entity.getAdresaClient());
            preStmt.setInt(5, entity.getNrLocuri());
            preStmt.setInt(6, entity.getZborId());
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
    public Bilet delete(Integer integer) throws IOException {
        return null;
    }

}
