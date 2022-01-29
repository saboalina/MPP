using System;
using System.Collections.Generic;
using System.Data;
using model;
using log4net;

namespace persistence
{
    public class AgentDBRepository : IAgentRepository
    {
        private static readonly ILog log = LogManager.GetLogger("AgentDbRepository");
        
        public AgentDBRepository()
        {
            log.Info("Creating AgentDbRepository");
        }
        
        public Employee FindOne(int id)
        {
            return null;
        }

        public IEnumerable<Employee> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public Employee findByUsernamePassword(string username, string password)
        {
            log.InfoFormat("Entering findOne with value {0}", username);
            IDbConnection con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select id, username, password from Employee where username=@username and password=@password";
                IDbDataParameter paramUsername = comm.CreateParameter();
                paramUsername.ParameterName = "@username";
                paramUsername.Value = username;
                comm.Parameters.Add(paramUsername);
                IDbDataParameter paramPassword = comm.CreateParameter();
                paramPassword.ParameterName = "@password";
                paramPassword.Value = password;
                comm.Parameters.Add(paramPassword);

                using (var dataR = comm.ExecuteReader())
                {
                    if (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String usernameV = dataR.GetString(1);
                        String passwordV = dataR.GetString(2);
                        Employee agent = new Employee()
                        {
                            ID = idV,
                            Username = usernameV,
                            Password = passwordV
                        };
                        log.InfoFormat("Exiting findOne with value {0}", agent);
                        return agent;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }
    }
}