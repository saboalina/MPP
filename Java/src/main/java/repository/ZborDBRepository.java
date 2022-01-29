package repository;

import domain.Zbor;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

import java.io.IOException;
import java.sql.*;
import java.time.LocalDate;
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
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Zboruri where idZbor=?")) {
            preStmt.setInt(1, integer);
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int idZbor=result.getInt("idZbor");
                    String destinatie = result.getString("Destinatie");
                    //LocalDateTime dateTime=result.getDate("dataSiOraPlecarii").toLocalDate().atTime();
                    LocalDate dataSiOraPlecarii = result.getDate("dataSiOraPlecarii").toLocalDate();
                    String aeroport = result.getString("Aeroport");
                    int nrLocuriDisponibile=result.getInt("nrLocuriDisponibile");
                    Zbor zbor = new Zbor(destinatie,dataSiOraPlecarii,aeroport,nrLocuriDisponibile);
                    zbor.setId(idZbor);
                    return zbor;
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
    public Iterable<Zbor> findAll() {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Zbor> zboruri = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Zboruri")) {
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int idZbor=result.getInt("idZbor");
                    String destinatie = result.getString("Destinatie");
                    //LocalDateTime dateTime=result.getDate("dataSiOraPlecarii").toLocalDate().atTime();
                    LocalDate dataSiOraPlecarii = result.getDate("dataSiOraPlecarii").toLocalDate();
                    String aeroport = result.getString("Aeroport");
                    int nrLocuriDisponibile=result.getInt("nrLocuriDisponibile");
                    Zbor zbor = new Zbor(destinatie,dataSiOraPlecarii,aeroport,nrLocuriDisponibile);
                    zbor.setId(idZbor);
                    if (zbor.getNrLocuriDisponibile()>0)
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
            preStmt.setDate(3, Date.valueOf(entity.getDataSiOraPlecarii()));
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

    public List<Zbor> filterByAeroport(String destinatie, LocalDate data) {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Zbor> zboruri = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Zboruri where destinatie = ?")) {
            preStmt.setString(1, destinatie);
            //preStmt.setDate(2, Date.valueOf(data));
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int idZbor=result.getInt("idZbor");
                    String destinatie1 = result.getString("Destinatie");
                    LocalDate dataSiOraPlecarii = result.getDate("dataSiOraPlecarii").toLocalDate();
                    String aeroport = result.getString("Aeroport");
                    int nrLocuriDisponibile=result.getInt("nrLocuriDisponibile");
                    Zbor zbor = new Zbor(destinatie1,dataSiOraPlecarii,aeroport,nrLocuriDisponibile);
                    zbor.setId(idZbor);
                    if (zbor.getNrLocuriDisponibile()>0)
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

    public Zbor update(Zbor zbor) {
        logger.traceEntry("Update Flight {} ",zbor);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("update Zboruri set NrLocuriDisponibile=? where IdZbor=?")){
            preparedStatement.setInt(1,zbor.getNrLocuriDisponibile());
            preparedStatement.setInt(2,zbor.getId());
            int result = preparedStatement.executeUpdate();
            if(result != 1)
                return zbor;
            logger.trace("Updates {} instances",result);
        }catch (SQLException e){
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit();
        return null;
    }

    /*
    @Override
    public Flight update(Flight entity) {
        logger.traceEntry("Update Flight {} ",entity);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("update Flights set available_seats=? where flightID=?")){
            preparedStatement.setInt(1,entity.getAvailable_seats());
            preparedStatement.setInt(2,entity.getId());
            int result = preparedStatement.executeUpdate();
            if(result != 1)
                return entity;
            logger.trace("Updates {} instances",result);
        }catch (SQLException e){
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit();
        return null;
    }
     */
}
