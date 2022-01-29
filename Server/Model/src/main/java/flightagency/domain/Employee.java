package flightagency.domain;

import java.io.Serializable;

public class Employee extends Entity<String> implements Serializable {

    private String name, password;

    public Employee(String name, String password) {
        this.name = name;
        this.password = password;
    }

    public Employee(String username) {
        super();
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "Employee{" +
                "name='" + name + '\'' +
                ", password='" + password + '\'' +
                '}';
    }
}
