// using System.Collections.Generic;
// using System.Data;
// using AgentieDeTurism.domain;
// using AgentieDeTurism.domain.validators;
// using log4net;
// using tasks.repository;
//
// namespace AgentieDeTurism.repository
// {
//     public class RezervareDBRepository : IRezervareRepository
//     {
//         private static readonly ILog log = LogManager.GetLogger("RezervareDbRepository");
//         
//         public RezervareDBRepository()
//         {
//             log.Info("Creating RezervareTaskDbRepository");
//         }
//         
//         public Rezervare FindOne(int id)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public IEnumerable<Rezervare> FindAll()
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public void Save(Rezervare entity)
//         {
//             log.InfoFormat("Entering save with value {0}", entity);
//             var con = DBUtils.getConnection();
//
//             using (var comm = con.CreateCommand())
//             {
//                 comm.CommandText = "insert into Rezervari(numeClient, nrTelefon, nrBilete, idExcursie) values (@numeClient, @nrTelefon, @nrBilete, @idExcursie)";
//
//                 IDbDataParameter paramNume = comm.CreateParameter();
//                 paramNume.ParameterName = "@numeClient";
//                 paramNume.Value = entity.NumeClient;
//                 comm.Parameters.Add(paramNume);
//
//                 IDbDataParameter paramNrTel = comm.CreateParameter();
//                 paramNrTel.ParameterName = "@nrTelefon";
//                 paramNrTel.Value = entity.NrTelefon;
//                 comm.Parameters.Add(paramNrTel);
//
//                 IDbDataParameter paramNrBilete= comm.CreateParameter();
//                 paramNrBilete.ParameterName = "@nrBilete";
//                 paramNrBilete.Value = entity.NrBilete;
//                 comm.Parameters.Add(paramNrBilete);
//
//                 IDbDataParameter paramIdExcursie = comm.CreateParameter();
//                 paramIdExcursie.ParameterName = "@idExcursie";
//                 paramIdExcursie.Value = entity.Excursie.ID;
//                 comm.Parameters.Add(paramIdExcursie);
//
//                 var result = comm.ExecuteNonQuery();
//                 if (result == 0)
//                 {
//                     log.InfoFormat("Exiting save with value {0}", null);
//                     throw new ValidationException("No task added !");
//                 }
//                 else
//                 {
//                     log.InfoFormat("Exiting save with value {0}", entity);
//                 }
//                     
//             }
//         }
//     }
// }