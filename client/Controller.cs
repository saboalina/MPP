using System;
using System.Collections;
using System.Collections.Generic;
using client.client;
using model;
using services;

namespace client
{
    public class Controller : IObserver
    {
        public event EventHandler<UserEventArgs> updateEvent;
        private readonly IServices server;
        private Employee currentUser;

        public Controller(IServices server)
        {
            this.server = server;
            currentUser = null;
        }

        public String getAgentUsername()
        {
            return currentUser.Username;
        }
        public void rezervareAdded(Ticket rezervare)
        {
            UserEventArgs userArgs=new UserEventArgs(UserEvent.NewRezervare, rezervare);
            Console.WriteLine("Rezervare added");
            OnUserEvent(userArgs);
        }
        
        protected virtual void OnUserEvent(UserEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }

        public void login(String username, String password)
        {
            Employee agent = new Employee()
            {
                Username = username,
                Password = password
            };
            server.LogIn(agent, this);
            Console.WriteLine("Login succeded...");
            currentUser = agent;
            Console.WriteLine("Current user {0}", agent);
        }
        
        public void logout()
        {
            Console.WriteLine("Ctrl logout");
            server.LogOut(currentUser, this);
            currentUser = null;
        }

        public IEnumerable<Excursie> getAllExcursie()
        {
            return server.FindAllExcursie();
        }

        public List<Excursie> getAllExcursieNameTime(String ob)
        {
            return server.FindByNameAndTimeExcursie(ob);
        }

        public void addRezervare(String numeClient, String nrTelefon, int nrBilete, Excursie excursie)
        {
            Ticket rezervare = new Ticket()
            {
                ClientName = numeClient,
                TouristsName = nrTelefon,
                NoSeats = nrBilete,
                Excursie = excursie
            };
            UserEventArgs userArgs = new UserEventArgs(UserEvent.NewRezervare, rezervare);
            OnUserEvent(userArgs);
            server.AddRezervare(numeClient, nrTelefon, nrBilete, excursie);
        }
    }
}