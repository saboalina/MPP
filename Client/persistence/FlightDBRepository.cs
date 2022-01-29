using System;
using System.Collections.Generic;
using System.Data;
using fightagency;
using model;
using log4net;
using model.validators;

namespace persistence
{
    public class FlightDBRepository : FlightRepository
    {
        private static readonly ILog log = LogManager.GetLogger("FlightDBRepository");
        
        public FlightDBRepository()
        {
            log.Info("Creating FlightDBRepository");
        }
        
        public Flight FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> FindAll()
        {
            log.Info("Entering findAll");
            IDbConnection con = DBUtils.getConnection();
            IList<Flight> flights = new List<Flight>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Flight";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String destination = dataR.GetString(1);
                        String airport = dataR.GetString(2);
                        String departureDate = dataR.GetString(3);
                        float price = dataR.GetFloat(4);
                        int availableSeats = dataR.GetInt32(5);
                        Flight flight = new Flight()
                        {
                            Id = idV,
                            Destination = destination,
                            Airport = airport,
                            DepartureDate = departure,
                            DepartureTime = de,
                            AvailableSeats = availableSeats
                        };
                        flights.Add(flight);
                    }
                }
            }
            
            log.InfoFormat("Exiting findAll with value {0}", flights);
            return flights;
        }

        public void Save(Flight entity)
        {
            throw new NotImplementedException();
        }

        public List<Flight> FindByNameAndTime(string name)
        {
            //log.InfoFormat("Entering findByNameAndTime with values {0} {1} {2}", name, min.ToString("HH:mm:ss"), max.ToString("HH:mm:ss"));
            IDbConnection con = DBUtils.getConnection();
            List<Flight> flights = new List<Flight>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Flight where destination=@name";
                
                IDbDataParameter paramName = comm.CreateParameter();
                paramName.ParameterName = "@name";
                paramName.Value = name;
                comm.Parameters.Add(paramName);
                // IDbDataParameter paramMin = comm.CreateParameter();
                // paramMin.ParameterName = "@min";
                // paramMin.Value = min.ToString("HH:mm:ss");
                // comm.Parameters.Add(paramMin);
                // IDbDataParameter paramMax = comm.CreateParameter();
                // paramMax.ParameterName = "@max";
                // paramMax.Value = max.ToString("HH:mm:ss");
                // comm.Parameters.Add(paramMax);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String destination = dataR.GetString(1);
                        String airport = dataR.GetString(2);
                        DateTime departure = DateTime.Parse(dataR.GetString(3));
                        float price = dataR.GetFloat(4);
                        int availableSeats = dataR.GetInt32(5);
                        Flight flight = new Flight()
                        {
                            ID = idV,
                            Destination = destination,
                            Airport = airport,
                            Departure = departure,
                            Price = price,
                            AvailableSeats = availableSeats
                        };
                        flights.Add(flight);
                    }
                }
            }
            
            log.InfoFormat("Exiting findByNameAndTime with values {0}", flights);
            return flights;
        }

        public void update(int id, int availableSeats)
        {
            log.InfoFormat("Entering update with value {0}", id);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Flight set availableSeats = @availableSeats where id = @id";

                IDbDataParameter paramAvailableSeats = comm.CreateParameter();
                paramAvailableSeats.ParameterName = "@availableSeats";
                paramAvailableSeats.Value = availableSeats;
                comm.Parameters.Add(paramAvailableSeats);

                IDbDataParameter paramId = comm.CreateParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting update with value {0}", null);
                    throw new ValidationException("No task updated !");
                }
                else
                {
                    log.InfoFormat("Exiting save with value {0}", id);
                }
                    
            }
        }
    }
}