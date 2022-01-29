using System;
using System.Collections.Generic;
using fightagency;
using model;

namespace persistence
{
    public interface EmployeeRepository : Repository<int, Employee>
    {
        Employee findByUsernamePassword(String username, String password);
    }
}