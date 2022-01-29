using System;
using System.Collections.Generic;
using System.Data;
using model;
using log4net;
using model.validators;

namespace persistence
{
    public class ExcursieDBRepository : IExcursieRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ExcursieDbRepository");
        
        public ExcursieDBRepository()
        {
            log.Info("Creating ExcursieTaskDbRepository");
        }
        
        public Excursie FindOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Excursie> FindAll()
        {
            log.Info("Entering findAll");
            IDbConnection con = DBUtils.getConnection();
            IList<Excursie> excursii = new List<Excursie>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Excursii";

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int idV = dataR.GetInt32(0);
                        String obiectivTuristic = dataR.GetString(1);
                        String firma = dataR.GetString(2);
                        DateTime ora = DateTime.Parse(dataR.GetString(3));
                        float pret = dataR.GetFloat(4);
                        int nrLocuri = dataR.GetInt32(5);
                        Excursie excursie = new Excursie()
                        {
                            ID = idV,
                            Destination = obiectivTuristic,
                            Airport = firma,
                            Departure = ora,
                            Price = pret,
                            AvailableSeats = nrLocuri
                        };
                        excursii.Add(excursie);
                    }
                }
            }
            
            log.InfoFormat("Exiting findAll with value {0}", excursii);
            return excursii;
        }

        public void Save(Excursie entity)
        {
            throw new NotImplementedException();
        }

        public List<Excursie> FindByNameAndTime(string name)
        {
            //log.InfoFormat("Entering findByNameAndTime with values {0} {1} {2}", name, min.ToString("HH:mm:ss"), max.ToString("HH:mm:ss"));
            IDbConnection con = DBUtils.getConnection();
            List<Excursie> excursii = new List<Excursie>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Excursii where obiectivTuristic=@name";
                
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
                        String obiectivTuristic = dataR.GetString(1);
                        String firma = dataR.GetString(2);
                        DateTime ora = DateTime.Parse(dataR.GetString(3));
                        float pret = dataR.GetFloat(4);
                        int nrLocuri = dataR.GetInt32(5);
                        Excursie excursie = new Excursie()
                        {
                            ID = idV,
                            Destination = obiectivTuristic,
                            Airport = firma,
                            Departure = ora,
                            Price = pret,
                            AvailableSeats = nrLocuri
                        };
                        excursii.Add(excursie);
                    }
                }
            }
            
            log.InfoFormat("Exiting findByNameAndTime with values {0}", excursii);
            return excursii;
        }

        public void update(int id, int nrLocuri)
        {
            log.InfoFormat("Entering update with value {0}", id);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Excursii set nrLocuri = @nrLocuri where id = @id";

                IDbDataParameter paramNrLocuri = comm.CreateParameter();
                paramNrLocuri.ParameterName = "@nrLocuri";
                paramNrLocuri.Value = nrLocuri;
                comm.Parameters.Add(paramNrLocuri);

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