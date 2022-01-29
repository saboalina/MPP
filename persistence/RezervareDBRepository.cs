using System.Collections.Generic;
using System.Data;
using persistence;
using model;
using log4net;
using model.validators;

namespace persistence
{
    public class RezervareDBRepository : IRezervareRepository
    {
        private static readonly ILog log = LogManager.GetLogger("RezervareDbRepository");
        
        public RezervareDBRepository()
        {
            log.Info("Creating RezervareTaskDbRepository");
        }
        
        public Ticket FindOne(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Ticket> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Ticket entity)
        {
            log.InfoFormat("Entering save with value {0}", entity);
            var con = DBUtils.getConnection();

            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Rezervari(numeClient, nrTelefon, nrBilete, idExcursie) values (@numeClient, @nrTelefon, @nrBilete, @idExcursie)";

                IDbDataParameter paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@numeClient";
                paramNume.Value = entity.ClientName;
                comm.Parameters.Add(paramNume);

                IDbDataParameter paramNrTel = comm.CreateParameter();
                paramNrTel.ParameterName = "@nrTelefon";
                paramNrTel.Value = entity.TouristsName;
                comm.Parameters.Add(paramNrTel);

                IDbDataParameter paramNrBilete= comm.CreateParameter();
                paramNrBilete.ParameterName = "@nrBilete";
                paramNrBilete.Value = entity.NoSeats;
                comm.Parameters.Add(paramNrBilete);

                IDbDataParameter paramIdExcursie = comm.CreateParameter();
                paramIdExcursie.ParameterName = "@idExcursie";
                paramIdExcursie.Value = entity.Excursie.ID;
                comm.Parameters.Add(paramIdExcursie);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                {
                    log.InfoFormat("Exiting save with value {0}", null);
                    throw new ValidationException("No task added !");
                }
                else
                {
                    log.InfoFormat("Exiting save with value {0}", entity);
                }
                    
            }
        }
    }
}