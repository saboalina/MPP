using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fightagency;
using model;
using ServiceException = services.ServiceException;

namespace client
{
    public partial class Login : Form
    {
        private Controller ctrl;
        private Proxy.Client client;
        private int port;
        private Main main;
        
        public Login(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }
        
        internal void Set(Proxy.Client client, int port, Main main)
        {
            this.client = client;
            this.port = port;
            this.main = main;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            try
            {
                ctrl.login(username, password);
                ctrl.addObserver(port);
                //MessageBox.Show("Login succeded");
                main.Text = "Main window for " + username;
                
                main.Show();
                this.Hide();
            }catch(Exception ex)
            {
                MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }

}