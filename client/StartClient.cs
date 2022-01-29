using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using model;
using model.validators;
using networking;
using services;
using System.Configuration;


namespace client
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            string ip = ConfigurationManager.AppSettings["IP"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            
            IServices server = new ChatServerProxy(ip, port);
            Controller ctrl=new Controller(server);
            Login win=new Login(ctrl);
            Application.Run(win);
        }
    }
}