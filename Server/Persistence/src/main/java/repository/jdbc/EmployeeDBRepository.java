package repository.jdbc;

import domain.Employee;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import repository.EmployeeRepository;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class EmployeeDBRepository implements EmployeeRepository {

    private JdbcUtils dbUtils;

    private static final Logger logger= LogManager.getLogger();

    public EmployeeDBRepository(Properties props) {
        logger.info("Initializing CarsDBRepository with properties: {} ",props);
        dbUtils=new JdbcUtils(props);
    }

    @Override
    public Employee findOne(String username) {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Employee where Username=?")) {
            preStmt.setString(1, username);
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    String username1 = result.getString("Username");
                    String name =  result.getString("Name");
                    String password = result.getString("Password");
                    Employee employee = new Employee(username, password, name);
                    return employee;
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
    public Iterable<Employee> findAll() {
        logger.traceEntry();
        Connection con = dbUtils.getConnection();
        List<Employee> list_employee = new ArrayList<>();
        try(PreparedStatement preStmt = con.prepareStatement("select * from Employee")) {
            try(ResultSet result = preStmt.executeQuery()) {
                while (result.next()) {
                    String username = result.getString("Username");
                    String name =  result.getString("Name");
                    String password = result.getString("Password");

                    Employee employee = new Employee(username, password, name);
                    list_employee.add(employee);
                }
            }
        } catch (SQLException e) {
            logger.error(e);
            System.err.println("Error DB " + e);
        }
        logger.traceExit(list_employee);
        return list_employee;
    }

    @Override
    public Employee save(Employee entity) {
        Connection con = dbUtils.getConnection();
        try(PreparedStatement preStmt = con.prepareStatement("insert into Employee (Username, Name, Passwprd) values (?,?,?)")){
            preStmt.setString(1, entity.getUsername());
            preStmt.setString(2, entity.getName());
            preStmt.setString(3, entity.getPassword());
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
