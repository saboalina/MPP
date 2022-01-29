using System;
using System.Collections.Generic;
using model;

namespace services
{
    public interface IServices
    {
        void LogIn(Employee agent, IObserver client);
        void LogOut(Employee agent, IObserver client);
        IEnumerable<Excursie> FindAllExcursie();
        List<Excursie> FindByNameAndTimeExcursie(String name);
        void AddRezervare(String numeClient, String nrTelefon, int nrBilete, Excursie excursie);
    }
}