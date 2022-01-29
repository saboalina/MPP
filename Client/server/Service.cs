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
    public class Service:MarshalByRefObject, IServices
    {
        private EmployeeRepository employeeRepository;
        private FlightRepository flightRepository;
        private TicketRepository ticketRepository;
        private IValidator<Ticket> ticketValidator;
        private readonly IDictionary<String, IObserver> loggedEmployees;

        public Service(EmployeeRepository employeeRepository, 
            FlightRepository flightRepository, 
            TicketRepository ticketRepository, 
            IValidator<Ticket> ticketValidator)
        {
            this.employeeRepository = employeeRepository;
            this.flightRepository = flightRepository;
            this.ticketRepository = ticketRepository;
            this.ticketValidator = ticketValidator;
            loggedEmployees = new Dictionary<String, IObserver>();
        }

        public void LogIn(Employee employee, IObserver client)
        {
            Employee userOk = employeeRepository.findByUsernamePassword(employee.Username, employee.Password);
            if (userOk!=null){
                if(loggedEmployees.ContainsKey(employee.Username))
                    throw new ServiceException("Employee already logged in.");
                loggedEmployees[employee.Username]= client;
            }else
                throw new ServiceException("Authentication failed.");
        }

        public void LogOut(Employee employee, IObserver client)
        {
            IObserver localClient=loggedEmployees[employee.Username];
            if (localClient==null)
                throw new ServiceException("Employee "+employee.Username+" is not logged in.");
            loggedEmployees.Remove(employee.Username);
        }

        public IEnumerable<Flight> FindAllFlights() 
        {
            return flightRepository.FindAll();
        }
        
        public List<Flight> FindByNameAndTimeExcursie(String name) {
            return flightRepository.FindByNameAndTime(name);
        }
        
        public void AddTicket(String clientName, String touristsName, int noSeats, Flight flight) 
        {
            if (noSeats > flight.AvailableSeats)
                throw new ServiceException("No more available seats!");
            Ticket ticket = new Ticket()
            {
                ClientName = clientName,
                TouristsName = touristsName,
                NoSeats = noSeats,
                Flight = flight
            };
            try 
            {
                ticketValidator.Validate(ticket);
            } 
            catch (ValidationException e) 
            {
                throw new ServiceException(e.Message);
            }
            ticketRepository.Save(ticket);
            flightRepository.update(flight.ID, flight.AvailableSeats - noSeats);
            flight.AvailableSeats -= noSeats;
            ticket.Flight = flight;
            NotifyTicketAdded(ticket);
        }
        
        private void NotifyTicketAdded(Ticket ticket){
            Console.WriteLine("notify ticket added ");
            foreach(IObserver client in loggedEmployees.Values){
                Task.Run(() => client.ticketAdded(ticket));
            }
        }

        public override object InitializeLifetimeService()
        {
            return null;
        }
    }
}