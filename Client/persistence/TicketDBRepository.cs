using System.Collections.Generic;
using System.Data;
using fightagency;
using persistence;
using model;
using log4net;
using model.validators;

namespace persistence
{
    public class TicketDBRepository : TicketRepository
    {
        private static readonly ILog log = LogManager.GetLogger("TicketDBRepository");
        
        public TicketDBRepository()
        {
            log.Info("Creating TicketDBRepository");
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
                comm.CommandText = "insert into Ticket(clientName, touristsName, noSeats, flightId) values (@clientName, @touristsName, @noSeats, @flightId)";

                IDbDataParameter paramClientName = comm.CreateParameter();
                paramClientName.ParameterName = "@clientName";
                paramClientName.Value = entity.ClientName;
                comm.Parameters.Add(paramClientName);

                IDbDataParameter paramTouristsName = comm.CreateParameter();
                paramTouristsName.ParameterName = "@touristsName";
                paramTouristsName.Value = entity.TouristsName;
                comm.Parameters.Add(paramTouristsName);

                IDbDataParameter paramNoSeats= comm.CreateParameter();
                paramNoSeats.ParameterName = "@noSeats";
                paramNoSeats.Value = entity.NoSeats;
                comm.Parameters.Add(paramNoSeats);

                IDbDataParameter paramIdFlight = comm.CreateParameter();
                paramIdFlight.ParameterName = "@flightId";
                paramIdFlight.Value = entity.Id;
                comm.Parameters.Add(paramIdFlight);

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