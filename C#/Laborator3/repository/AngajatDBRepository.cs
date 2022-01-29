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
    public class AngajatDBRepository : IAngajatRepository
    {
        private static readonly ILog log = LogManager.GetLogger("AngajatDbRepository");

        public AngajatDBRepository()
        {
            log.Info("Se creeaza AngajatDBRepository");
        }

        public IEnumerable<Angajat> FindAll()
        {

            IDbConnection con = DBUtils.getConnection();
            IList<Angajat> Angajats = new List<Angajat>();
            
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "select * from Angajati";
                using (var dataR = comm.ExecuteReader())
                {
                    while (dataR.Read())
                    {
                        string username = dataR.GetString(0);
                        string nume = dataR.GetString(1);
                        string prenume = dataR.GetString(2);
                        string parola = dataR.GetString(3);
                        Angajat Angajat = new Angajat(nume, prenume, parola);
                        Angajat.id = username;
                        Angajats.Add(Angajat);
                    }
                }
            }
            return Angajats;
        }

        public Angajat Save(Angajat entity)
        {
            log.Info("In functia save:");
            var con = DBUtils.getConnection();
            using (var comm = con.CreateCommand())
            {
                comm.CommandText = "insert into Angajati values (@idAngajat, @nume, @prenume, @parola)";

                var paramId = comm.CreateParameter();
                paramId.ParameterName = "@idAngajat";
                paramId.Value = entity.id;
                comm.Parameters.Add(paramId);

                var paramNume = comm.CreateParameter();
                paramNume.ParameterName = "@nume";
                paramNume.Value = entity.nume;
                comm.Parameters.Add(paramNume);

                var paramPrenume = comm.CreateParameter();
                paramPrenume.ParameterName = "@prenume";
                paramPrenume.Value = entity.prenume;
                comm.Parameters.Add(paramPrenume);

                var paramParola = comm.CreateParameter();
                paramParola.ParameterName = "@parola";
                paramParola.Value = entity.parola;
                comm.Parameters.Add(paramParola);

                var result = comm.ExecuteNonQuery();
                if (result == 0)
                    System.Console.Write("Niciun angajat nu a fost adaugat!");
            }

            log.Info("Se iese din functia save");
            return entity;
        }

        public Angajat Update(Angajat entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
