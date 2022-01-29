using System;
using System.Collections.Generic;
using fightagency;
using model;

namespace services
{
    public interface IServices
    {
        void LogIn(Employee employee, IObserver client);
        void LogOut(Employee employee, IObserver client);
        IEnumerable<Flight> FindAllFlights();
        List<Flight> FindByNameAndTimeExcursie(String name);
        void AddTicket(String clientName, String touristsName, int noSeats, Flight flight);
    }
}