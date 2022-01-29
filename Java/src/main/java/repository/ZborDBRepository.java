package repository;

import domain.Zbor;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.io.IOException;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class ZborDBRepository implements ZborRepository {
    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public ZborDBRepository (Properties props) {
        logger.info("Initializing CarsDBRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }

    @Override
    public Zbor findOne(Integer integer) {
        return null;
    }

    @Override
    public Iterable<Zbor> findAll() {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Zbor> zboruri = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Zboruri")) {
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int idZbor=result.getInt("idZbor");
                    String destinatie = result.getString("Destinatie");
                    Date dataSiOraPlecarii =  result.getDate("dataSiOraPlecarii");
                    String aeroport = result.getString("Aeroport");
                    int nrLocuriDisponibile=result.getInt("nrLocuriDisponibile");
                    Zbor zbor = new Zbor(destinatie,dataSiOraPlecarii,aeroport,nrLocuriDisponibile);
                    zbor.setId(idZbor);
                    zboruri.add(zbor);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit(zboruri);
        return zboruri;
    }

    @Override
    public Zbor save(Zbor entity) {
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into Zboruri (IdZbor, Destinatie, dataSiOraPlecarii, Aeroport, NrLocuriDisponibile) values (?,?,?,?,?)")){
            preStmt.setInt(1, entity.getId());
            preStmt.setString(2, entity.getDestinatie());
            preStmt.setDate(3, entity.getDataSiOraPlecarii());
            preStmt.setString(4, entity.getAeroport());
            preStmt.setInt(5, entity.getNrLocuriDisponibile());
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
    public Zbor delete(Integer integer) throws IOException {
        return null;
    }
}
