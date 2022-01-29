using System;
using System.Windows.Forms;
using services;
using System.Collections;
using System.Runtime.Remoting.Channels;
using Hashtable=System.Collections.Hashtable;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Threading;
using fightagency;
using flightagency;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport;


namespace client
{
    
    internal class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            // BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
            // serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            // BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            // IDictionary props = new Hashtable();
            //
            // props["port"] = 0;
            // TcpChannel channel = new TcpChannel(props, clientProv, serverProv);
            // ChannelServices.RegisterChannel(channel, false);
            
            // Login w=new Login(ctrl);
            // Application.Run (w);
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            
            TSocket socket = new TSocket("localhost", 9090);
            var protocol = new TBinaryProtocol(socket);
            var client = new Proxy.Client(protocol);
            Controller ctrl=new Controller(client);
            socket.Open();

            Login login = new Login(ctrl);
            Main main = new Main(ctrl);

            var mainWindowControllerImplementation = new MainWindowControllerImpl(ctrl);
            var processor = new MainWindowController.Processor(mainWindowControllerImplementation);

            int port = 55555 + new Random().Next() % 10;
            //int port = 55556;
            TServerTransport transport = new TServerSocket(port);
            TServer server = new TThreadPoolServer(processor, transport);

            login.Set(client, port, main);
            login.Text = "Client on port " + port;
            main.Set(port, login, socket, server);
            main.Text = "Client on port " + port;

            Thread thread = new Thread(new ThreadStart(server.Serve));
            thread.Start();

            Application.Run(login);
        }
    }
}