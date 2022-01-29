using Laborator3.domain;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator3.repository
{
    public class ZboruriDBRepository : IZborRepository
    {
        private static readonly ILog log = LogManager.GetLogger("ZborDBRepository");

        public ZboruriDBRepository()
        {
            log.Info("Se creeaza ZborDBRepository");
        }

        public IEnumerable<Zbor> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Zbor> Zbors = new List<Zbor>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Zbor";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int ZborID = dataR.GetInt32(0);
                        string destination = dataR.GetString(1);
                        DateTime departure_date = dataR.GetDateTime(2);
                        string airport = dataR.GetString(3);
                        int available_seats = dataR.GetInt32(4);
                        Zbor Zbor = new Zbor(destination, departure_date, airport, available_seats);
                        Zbor.id = ZborID;
                        Zbors.Add(Zbor);
                    }
                }
            }
            return Zbors;
        }

        public Zbor Save(Zbor entity)
        {
            log.Info("In functia save:");
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText =
                    "insert into Zboruri values (@idZbor, @destinatie, @dataSiOraPlecarii, @aeroport, @nrLocuriDisponibile)";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idZbor";
                paramId.Value = entity.id;
                comm.Parameters.Add(paramId);

                var paramDestinatie = comm.CreateParameter();
                paramDestinatie.ParameterName = "@destinatie";
                paramDestinatie.Value = entity.destinatie;
                comm.Parameters.Add(paramDestinatie);

                var paramData = comm.CreateParameter();
                paramData.ParameterName = "@dataSiOraPlecarii";
                paramData.Value = entity.dataSiOraPlecarii;
                comm.Parameters.Add(paramData);

                var paramAeroport = comm.CreateParameter();
                paramAeroport.ParameterName = "@aeroport";
                paramAeroport.Value = entity.aeroport;
                comm.Parameters.Add(paramAeroport);

                var paramNrLocuriDisp = comm.CreateParameter();
                paramNrLocuriDisp.ParameterName = "@nrLocuriDisponibile";
                paramNrLocuriDisp.Value = entity.nrLocuriDisponibile;
                comm.Parameters.Add(paramNrLocuriDisp);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    System.Console.Write("Niciun zbor nu a fost adaugat");
            }
            log.Info("Se iese din functia save:");
            return entity;
        }

        public Zbor Update(Zbor entity)
        {
            throw new System.NotImplementedException();
        }

    }
}
