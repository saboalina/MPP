using System;
using System.Collections.Generic;
using System.Data;
using fightagency;
using model;
using log4net;

namespace persistence
{
    public class EmployeeDBRepository : EmployeeRepository
    {
        private static readonly ILog log = LogManager.GetLogger("EmployeeDBRepository");
        
        public EmployeeDBRepository()
        {
            log.Info("Creating EmployeeDBRepository");
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
                comm.CommandText = "select username, password, name from Employee where username=@username and password=@password";
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
                        String usernameV = dataR.GetString(0);
                        String passwordV = dataR.GetString(1);
                        String nameV = dataR.GetString(2);
                        Employee employee = new Employee()
                        {
                            Username = usernameV,
                            Password = passwordV,
                            Name = nameV
                        };
                        log.InfoFormat("Exiting findOne with value {0}", employee);
                        return employee;
                    }
                }
            }
            log.InfoFormat("Exiting findOne with value {0}", null);
            return null;
        }
    }
}