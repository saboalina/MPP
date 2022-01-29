using Laborator4.domain;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laborator4.repository
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
            IList<Zbor> zboruri = new List<Zbor>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Zboruri";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int zborId = dataR.GetInt32(0);
                        string destinatie = dataR.GetString(1);
                        DateTime dataSiOraPlecarii = dataR.GetDateTime(2);
                        string aeroport = dataR.GetString(3);
                        int nrLocuriDisponibile = dataR.GetInt32(4);
                        Zbor zbor = new Zbor(destinatie, dataSiOraPlecarii, aeroport, nrLocuriDisponibile);
                        zbor.id = zborId;
                        if (zbor.nrLocuriDisponibile>0)
                            zboruri.Add(zbor);
                    }
                }
            }
            return zboruri;
        }


        internal Zbor findOne(object p)
        {
            log.Info("In functia find one");
            IDbConnection con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Zboruri where idZbor=@idZbor";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idZbor";
                paramId.Value = p;
                comm.Parameters.Add(paramId);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int zborId = dataR.GetInt32(0);
                        string destinatie = dataR.GetString(1);
                        DateTime dataSiOraPlecarii = dataR.GetDateTime(2);
                        string aeroport = dataR.GetString(3);
                        int nrLocuriDisponibile = dataR.GetInt32(4);
                        Zbor zbor = new Zbor(destinatie, dataSiOraPlecarii, aeroport, nrLocuriDisponibile);
                        zbor.id = zborId;
                        log.Info("se iese din find one cu o entitate");
                        return zbor;
                    }
                }
            }
            log.Info("se iese din find one cu 0 entitati");
            return null;
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
            IDbConnection con = DBUtils.getConnection();
            //IList<Zbor> zboruri = new List<Zbor>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "update Zboruri set nrLocuriDisponibile=@nrLocuriDisponibile where idZbor=@idZbor";

                var paramNrLocuriDisp = comm.CreateParameter();
                paramNrLocuriDisp.ParameterName = "@nrLocuriDisponibile";
                paramNrLocuriDisp.Value = entity.nrLocuriDisponibile;
                comm.Parameters.Add(paramNrLocuriDisp);

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idZbor";
                paramId.Value = entity.id;
                comm.Parameters.Add(paramId);

                var result = comm.ExecuteNonQuery();

                if (result == 1)
                    System.Console.Write("nu a fost schimbat niciun zbor");
            }
            log.Info("Se iese din functia save:");
            return entity;
        }

        public IEnumerable<Zbor> FilterByDestinatie(String destinatie, DateTime data)
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Zbor> zboruri = new List<Zbor>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Zboruri where destinatie=@destinatie";
                
                var paramDestinatie = comm.CreateParameter();
                paramDestinatie.ParameterName = "@destinatie";
                paramDestinatie.Value = destinatie;
                comm.Parameters.Add(paramDestinatie);

                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int zborId = dataR.GetInt32(0);
                        string destinatie1 = dataR.GetString(1);
                        DateTime dataSiOraPlecarii = dataR.GetDateTime(2);
                        string aeroport = dataR.GetString(3);
                        int nrLocuriDisponibile = dataR.GetInt32(4);
                        Zbor zbor = new Zbor(destinatie1, dataSiOraPlecarii, aeroport, nrLocuriDisponibile);
                        zbor.id = zborId;
                        if (zbor.nrLocuriDisponibile > 0)
                            zboruri.Add(zbor);
                    }
                }
            }
            return zboruri;
        }
    }
}
