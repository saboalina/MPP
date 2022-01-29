package repository.jdbc;

import domain.Flight;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import repository.FlightRepository;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class FlightDBRepository implements FlightRepository {
    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public FlightDBRepository (Properties props) {
        logger.info("Initializing FlightDBRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }

    @Override
    public Flight findOne(Integer integer) {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Flight where FlightId=?")) {
            preStmt.setInt(1, integer);
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int flightId = result.getInt("FlightId");
                    String destination = result.getString("Destination");
                    String departureDate = result.getString("DepartureDate");
                    String departureTime = result.getString("DepartureTime");
                    String airport = result.getString("Airport");
                    int availableSeats = result.getInt("AvailableSeats");
                    Flight flight = new Flight(destination, departureDate, departureTime, airport,availableSeats);
                    flight.setId(flightId);
                    return flight;
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
    public Iterable<Flight> findAll() {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Flight> list_flight = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Flight")) {
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int flightId = result.getInt("FlightId");
                    String destination = result.getString("Destination");
                    String departureDate = result.getString("DepartureDate");
                    String departureTime = result.getString("DepartureTime");
                    String airport = result.getString("Airport");
                    int availableSeats = result.getInt("AvailableSeats");
                    Flight flight = new Flight(destination, departureDate, departureTime, airport,availableSeats);
                    flight.setId(flightId);
                    if (flight.getAvailableSeats()>0)
                        list_flight.add(flight);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit(list_flight);
        return list_flight;
    }

    @Override
    public Flight save(Flight entity) {
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into Flight (FlightId, Destination, DepartureDate, DepartureTime, Airport, AvailableSeats) values (?,?,?,?,?,?)")){
            preStmt.setInt(1, entity.getId());
            preStmt.setString(2, entity.getDestination());
            preStmt.setString(3, entity.getDepartureDate());
            preStmt.setString(4, entity.getDepartureTime());
            preStmt.setString(5, entity.getAirport());
            preStmt.setInt(6, entity.getAvailableSeats());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances", result);
        } catch (SQLException ex) {
            logger.error(ex);
            System.err.println("Error DB " + ex);
        }
        logger.traceExit();
        return entity;
    }


    public List<Flight> filter(String destination, String date) {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Flight> zboruri = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Flight where Destination = ? and DepartureDate = ?")) {
            preStmt.setString(1, destination);
            preStmt.setString(2, date);
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int flightId = result.getInt("FlightId");
                    String destination2 = result.getString("Destination");
                    String departureDate = result.getString("DepartureDate");
                    String departureTime = result.getString("DepartureTime");
                    String airport = result.getString("Airport");
                    int availableSeats = result.getInt("AvailableSeats");
                    Flight flight = new Flight(destination2, departureDate, departureTime, airport,availableSeats);
                    flight.setId(flightId);
                    if (flight.getAvailableSeats()>0)
                        zboruri.add(flight);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit(zboruri);
        return zboruri;
    }

    public void update(Flight entity) {
        logger.traceEntry("Update Flight {} ",entity);
        Connection connection = dbUtils.getConnection();
        try(PreparedStatement preparedStatement = connection.prepareStatement("update Flight set AvailableSeats=? where FlightId=?")){
            preparedStatement.setInt(1,entity.getAvailableSeats());
            preparedStatement.setInt(2,entity.getId());
            int result = preparedStatement.executeUpdate();
            logger.trace("Updates {} instances",result);
        }catch (SQLException e){
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit();
    }

}