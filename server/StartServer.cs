using model;
using model.validators;
using System.Configuration;

namespace server
{
    using System;
    using System.Net.Sockets;
    using System.Threading;
    using persistence;
    using services;
    using networking;
    using ServerTemplate;
    namespace chat
    {
        using server;
        class StartServer
        {
            static void Main(string[] args)
            {
                
                IAgentRepository userRepo=new AgentDBRepository();
                IExcursieRepository excursieRepository=new ExcursieDBRepository();
                IRezervareRepository rezervareRepository = new RezervareDBRepository();
                IValidator<Ticket> rezVal = new RezervareValidator();
                IServices serviceImpl = new Service(userRepo, excursieRepository, rezervareRepository, rezVal);

                string ip = ConfigurationManager.AppSettings["IP"];
                int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
                
                SerialServer server = new SerialServer(ip, port, serviceImpl);
                server.Start();
                Console.WriteLine("Server started ...");
                Console.ReadLine();
            
            }
        }

        public class SerialServer: ConcurrentServer 
        {
            private IServices server;
            private ChatClientWorker worker;
            public SerialServer(string host, int port, IServices server) : base(host, port)
            {
                this.server = server;
                Console.WriteLine("SerialChatServer...");
            }
            protected override Thread createWorker(TcpClient client)
            {
                worker = new ChatClientWorker(server, client);
                return new Thread(new ThreadStart(worker.run));
            }
        }
    
    }

}