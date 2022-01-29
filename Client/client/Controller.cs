using System;
using System.Collections;
using System.Collections.Generic;
using client.client;
using fightagency;
using model;
using services;

namespace client
{
    public class Controller
    {
        public event EventHandler<UserEventArgs> updateEvent;
        private readonly Proxy.Client server;
        private Employee currentEmployee;

        public Controller(Proxy.Client server)
        {
            this.server = server;
            currentEmployee = null;
        }
        
        public void ticketAdded(List<Flight> flights)
        {
            UserEventArgs userArgs=new UserEventArgs(UserEvent.NewTicket, flights);
            Console.WriteLine("Ticket added");
            OnUserEvent(userArgs);
        }
        
        protected virtual void OnUserEvent(UserEventArgs e)
        {
            if (updateEvent == null) return;
            updateEvent(this, e);
            Console.WriteLine("Update Event called");
        }

        public void addObserver(int port)
        {
            server.addObserver(port);
        }

        public void login(String username, String password)
        {
            Employee employee = new Employee()
            {
                Username = username,
                Password = password
            };
            server.login(employee);
            Console.WriteLine("Login succeded...");
            currentEmployee = employee;
            Console.WriteLine("Current user {0}", employee);
        }
        
        public void logout(int port)
        {
            Console.WriteLine("Ctrl logout");
            server.logout(port);
            currentEmployee = null;
        }

        public List<Flight> getAllFlights()
        {
            return server.getAllFlights();
        }

        public List<Flight> getAllExcursieNameTime(String destination, String date)
        {
            return server.filter(destination, date);
        }

        public void addTicket(int ticketid, String clientName, String touristsName, String clientAddress, int noSeats, int flightId)
        {
            Ticket ticket = new Ticket()
            {
                Id = ticketid,
                ClientName = clientName,
                TouristsName = touristsName,
                ClientAddress = clientAddress,
                NoSeats = noSeats,
                FlightId = flightId
            };
            server.addTicket(ticket);
            server.notifyServer();
        }
    }
}