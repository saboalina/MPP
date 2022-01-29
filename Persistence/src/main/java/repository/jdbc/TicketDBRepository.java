package repository.jdbc;

import domain.Ticket;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import repository.TicketRepository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class TicketDBRepository implements TicketRepository {

    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public TicketDBRepository(Properties props) {
        logger.info("Initializing CarsDBRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }

    @Override
    public Ticket findOne(Integer integer) {
        return null;
    }

    @Override
    public Iterable<Ticket> findAll() {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Ticket> list_ticket = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Ticket")) {
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    int ticketId = result.getInt("TicketId");
                    String clientName = result.getString("ClientName");
                    String touristsName =  result.getString("TouristsName");
                    String clientAddress = result.getString("ClientAddress");
                    int noSeats = result.getInt("NoSeats");
                    int flightId = result.getInt("FlightId");
                    Ticket ticket = new Ticket(clientName, touristsName, clientAddress, noSeats, flightId);
                    ticket.setId(ticketId);
                    list_ticket.add(ticket);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit(list_ticket);
        return list_ticket;
    }

    @Override
    public Ticket save(Ticket entity) {
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into Ticket (TicketId, ClientName, TouristsName, ClientAddress, NoSeats, FlightId) values (?,?,?,?,?,?)")){
            preStmt.setInt(1, entity.getId());
            preStmt.setString(2, entity.getClientName());
            preStmt.setString(3, entity.getTouristsName());
            preStmt.setString(4, entity.getClientAddress());
            preStmt.setInt(5, entity.getNoSeats());
            preStmt.setInt(6, entity.getFlightId());
            int result = preStmt.executeUpdate();
            logger.trace("Saved {} instances", result);
        } catch (SQLException ex) {
            logger.error(ex);
            System.err.println("Error DB " + ex);
        }
        logger.traceExit();
        return entity;
    }


}
