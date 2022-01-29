using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using model;
using model.validators;
using persistence;
using services;

namespace server
{
    public class Service : IServices
    {
        private IAgentRepository agentRepository;
        private IExcursieRepository excursieRepository;
        private IRezervareRepository rezervareRepository;
        private IValidator<Ticket> rezervareValidator;
        private readonly IDictionary<String, IObserver> loggedClients;

        public Service(IAgentRepository agentRepository, IExcursieRepository excursieRepository, IRezervareRepository rezervareRepository, IValidator<Ticket> rezervareValidator)
        {
            this.agentRepository = agentRepository;
            this.excursieRepository = excursieRepository;
            this.rezervareRepository = rezervareRepository;
            this.rezervareValidator = rezervareValidator;
            loggedClients = new Dictionary<String, IObserver>();
        }

        public void LogIn(Employee agent, IObserver client)
        {
            Employee userOk = agentRepository.findByUsernamePassword(agent.Username, agent.Password);
            if (userOk!=null){
                if(loggedClients.ContainsKey(agent.Username))
                    throw new ServiceException("User already logged in.");
                loggedClients[agent.Username]= client;
            }else
                throw new ServiceException("Authentication failed.");
        }

        public void LogOut(Employee agent, IObserver client)
        {
            IObserver localClient=loggedClients[agent.Username];
            if (localClient==null)
                throw new ServiceException("User "+agent.Username+" is not logged in.");
            loggedClients.Remove(agent.Username);
        }

        public IEnumerable<Excursie> FindAllExcursie() 
        {
            return excursieRepository.FindAll();
        }
        
        public List<Excursie> FindByNameAndTimeExcursie(String name) {
            return excursieRepository.FindByNameAndTime(name);
        }
        
        public void AddRezervare(String numeClient, String nrTelefon, int nrBilete, Excursie excursie) 
        {
            if (nrBilete > excursie.AvailableSeats)
                throw new ServiceException("Nu sunt destule locuri disponibile!");
            Ticket rezervare = new Ticket()
            {
                ClientName = numeClient,
                TouristsName = nrTelefon,
                NoSeats = nrBilete,
                Excursie = excursie
            };
            try 
            {
                rezervareValidator.Validate(rezervare);
            } 
            catch (ValidationException e) 
            {
                throw new ServiceException(e.Message);
            }
            rezervareRepository.Save(rezervare);
            excursieRepository.update(excursie.ID, excursie.AvailableSeats - nrBilete);
            excursie.AvailableSeats -= nrBilete;
            rezervare.Excursie = excursie;
            NotifyRezervareAdded(rezervare);
        }
        
        private void NotifyRezervareAdded(Ticket rezervare){
            Console.WriteLine("notify rezervare added ");
            foreach(IObserver client in loggedClients.Values){
                Task.Run(() => client.rezervareAdded(rezervare));
            }
        }
    }
}