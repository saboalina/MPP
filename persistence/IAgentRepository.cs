using System;
using System.Collections.Generic;
using model;

namespace persistence
{
    public interface IAgentRepository : IRepository<int, Employee>
    {
        Employee findByUsernamePassword(String username, String password);
    }
}