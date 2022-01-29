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
    public class BiletDBRepository : IBiletRepository
    {
        private static readonly ILog log = LogManager.GetLogger("BiletDBRepository");

        public BiletDBRepository()
        {
            log.Info("Se creeaza BiletDBRepository");
        }

        public IEnumerable<Bilet> FindAll()
        {
            IDbConnection con = DBUtils.getConnection();
            IList<Bilet> Bilets = new List<Bilet>();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Bilet";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        int biletId = dataR.GetInt32(0);
                        string nume_client = dataR.GetString(1);
                        string nume_turisti = dataR.GetString(2);
                        string adresa_client = dataR.GetString(3);
                        int nr_locuri = dataR.GetInt32(4);
                        int zborId = dataR.GetInt32(5);
                        Bilet Bilet = new Bilet(nume_client, nume_turisti, adresa_client, nr_locuri, zborId);
                        Bilet.id = biletId;
                        Bilets.Add(Bilet);
                    }
                }
            }
            return Bilets;
        }

        public Bilet Save(Bilet entity)
        {
            log.Info("In functia save:");
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Bilet values (@idBilet, @numeClient, @numeTuristi, @adresaClient, @nrLocuri, @zborId)";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idBilet";
                paramId.Value = entity.id;
                comm.Parameters.Add(paramId);

                var paramClient = comm.CreateParameter();
                paramClient.ParameterName = "@numeClient";
                paramClient.Value = entity.numeClient;
                comm.Parameters.Add(paramClient);

                var paramTouristi = comm.CreateParameter();
                paramTouristi.ParameterName = "@numeTuristi";
                paramTouristi.Value = entity.numeTuristi;
                comm.Parameters.Add(paramTouristi);

                var paramAdresa = comm.CreateParameter();
                paramAdresa.ParameterName = "@adresaClient";
                paramAdresa.Value = entity.adresaClient;
                comm.Parameters.Add(paramAdresa);

                var paramNrLocuri = comm.CreateParameter();
                paramNrLocuri.ParameterName = "@nrLocuri";
                paramNrLocuri.Value = entity.nrLocuri;
                comm.Parameters.Add(paramNrLocuri);


                var paramZborId = comm.CreateParameter();
                paramZborId.ParameterName = "@zborId";
                paramZborId.Value = entity.zborId;
                comm.Parameters.Add(paramZborId);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    System.Console.Write("Nu a fost adaugat niciun bilet");
            }
            log.Info("Se iese din functia save");
            return entity;
        }

        public Bilet Update(Bilet entity)
        {
            //TODO implement method
            throw new System.NotImplementedException();
        }
    }
}
