using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using client.client;
using fightagency;
using services;
using Thrift.Server;
using Thrift.Transport;

namespace client
{
    public partial class Main : Form
    {
        private readonly Controller ctrl;
        private int port;
        private readonly IList<Flight> flights;
        private IList<Flight> filtered;
        private Login login;
        private TSocket socket;
        private TServer server;
        
        public Main(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            flights = ctrl.getAllFlights();
            excursiiTable.DataSource = flights;
            ctrl.updateEvent += employeeUpdate;
        }
        
        internal void Set(int portN, Login login, TSocket socket, TServer server)
        {
            this.port = portN;
            this.login = login;
            this.socket = socket;
            this.server = server;
        }
        
        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Window closing "+e.CloseReason);
             if (e.CloseReason == CloseReason.UserClosing)
             {
                 ctrl.logout(port);
                 server.Stop();
                 socket.Close();
                 Application.Exit();
             }
        }

        private void initCautareTable()
        {
            String destination = obiectivTuristicTextbox.Text;
            
            DateTime dd = dateTimePicker1.Value;
            String dateFormat = dd.Date.ToString("yyyy-MM-dd");
            filtered = ctrl.getAllExcursieNameTime(destination, dateFormat);
            cautareTable.DataSource=filtered;
            
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            ctrl.logout(port);
            ctrl.updateEvent -= employeeUpdate;
            socket.Close();
            server.Stop();
            Application.Exit();
        }

        private void cautaBtn_Click(object sender, EventArgs e)
        {
            cautareTable.Rows.Clear();
            initCautareTable();
        }


        private void rezervaBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Random rd = new Random();
                int ticketid = rd.Next(100,1000);
                Flight selectedFlight = (Flight) cautareTable.SelectedRows[0].DataBoundItem;
                String clientName = numeClientTextbox.Text;
                String touristsName = telefonTextbox.Text;
                String clientAddress = textBox1.Text;
                int noSeats = (int) nrBileteNumeric.Value;
                ctrl.addTicket(ticketid, clientName, touristsName, clientAddress, noSeats, selectedFlight.Id);
                
                MessageBox.Show("You bought a ticket!");
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You need to select a flight!");
            }
            
            String destination = obiectivTuristicTextbox.Text;
            
            DateTime dd = dateTimePicker1.Value;
            String dateFormat = dd.Date.ToString("yyyy-MM-dd");
            filtered = ctrl.getAllExcursieNameTime(destination, dateFormat);
            cautareTable.DataSource=filtered;
        }

        public void employeeUpdate(object sender, UserEventArgs e)
        {
            var x = this.Handle;
            if (e.UserEventType == UserEvent.NewTicket)
            {
                List<Flight> flights = (List<Flight>)e.Data;
                excursiiTable.BeginInvoke(new UpdateTableCallback(this.UpdateTable), new object[]{flights});
            }
        }
        
        public delegate void UpdateTableCallback(IList<Flight> flights);

        private void UpdateTable(IList<Flight> flights)
        {
            excursiiTable.DataSource = null;
            excursiiTable.Rows.Clear();
            excursiiTable.DataSource = flights;
        }

        private void cautareTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void excursiiTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}