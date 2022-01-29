// using System;
// using System.Collections;
// using System.Collections.Generic;
// using AgentieDeTurism.domain;
// using AgentieDeTurism.domain.validators;
// using AgentieDeTurism.repository;
//
// namespace AgentieDeTurism.service
// {
//     public class Service
//     {
//         private IAgentRepository agentRepository;
//         private IExcursieRepository excursieRepository;
//         private IRezervareRepository rezervareRepository;
//         private IValidator<Rezervare> rezervareValidator;
//
//         public Service(IAgentRepository agentRepository, IExcursieRepository excursieRepository, IRezervareRepository rezervareRepository, IValidator<Rezervare> rezervareValidator)
//         {
//             this.agentRepository = agentRepository;
//             this.excursieRepository = excursieRepository;
//             this.rezervareRepository = rezervareRepository;
//             this.rezervareValidator = rezervareValidator;
//         }
//         
//         public Agent FindByUsernameAndPassword(String username, String password) 
//         {
//             Agent agent = agentRepository.findByUsernamePassword(username, password);
//             if (agent == null)
//                 throw new ServiceException("Datele invalide!");
//             return agent;
//         }
//         
//         public IEnumerable FindAllExcursie() 
//         {
//             return excursieRepository.FindAll();
//         }
//         
//         public List<Excursie> FindByNameAndTimeExcursie(String name, DateTime min, DateTime max) {
//             return excursieRepository.FindByNameAndTime(name, min, max);
//         }
//         
//         public void AddRezervare(String numeClient, String nrTelefon, int nrBilete, Excursie excursie) 
//         {
//             if (nrBilete > excursie.NrLocuri)
//                 throw new ServiceException("Nu sunt destule locuri disponibile!");
//             Rezervare rezervare = new Rezervare()
//             {
//                 NumeClient = numeClient,
//                 NrTelefon = nrTelefon,
//                 NrBilete = nrBilete,
//                 Excursie = excursie
//             };
//             try 
//             {
//                 rezervareValidator.Validate(rezervare);
//             } 
//             catch (ValidationException e) 
//             {
//                 throw new ServiceException(e.Message);
//             }
//             rezervareRepository.Save(rezervare);
//             excursieRepository.update(excursie.ID, excursie.NrLocuri - nrBilete);
//         }
//     }
// }