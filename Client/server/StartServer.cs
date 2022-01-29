using System.Collections;
using model;
using model.validators;
using System.Configuration;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace server
{
    using System;
    using persistence;
    namespace chat
    {
        using server;
        class StartServer
        {
            static void Main(string[] args)
            {

                
                BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
                serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
                IDictionary props = new Hashtable();

                props["port"] = 55555;
                TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
                ChannelServices.RegisterChannel(channel, false);

                EmployeeRepository employeeRepository=new EmployeeDBRepository();
                FlightRepository flightRepository=new FlightDBRepository();
                TicketRepository ticketRepository = new TicketDBRepository();
                IValidator<Ticket> ticketValidator = new RezervareValidator();
                MarshalByRefObject serviceImpl = new Service(employeeRepository, 
                    flightRepository, ticketRepository, ticketValidator);
           
            
           //var server = new ChatServerImpl();
                RemotingServices.Marshal(serviceImpl, "Chat");
           //RemotingConfiguration.RegisterWellKnownServiceType(typeof(ChatServerImpl), "Chat",
            //    WellKnownObjectMode.Singleton);

            // the server will keep running until keypress.
                Console.WriteLine("Server started ...");
                Console.WriteLine("Press <enter> to exit...");
                Console.ReadLine();
            }
        }
    }
}