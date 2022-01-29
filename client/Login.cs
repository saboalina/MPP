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
using model;
using ServiceException = services.ServiceException;

namespace client
{
    public partial class Login : Form
    {
        private Controller ctrl;
        public Login(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            String user = usernameTextbox.Text;
            String pass = passwordTextbox.Text;
            try
            {
                ctrl.login(user, pass);
                //MessageBox.Show("Login succeded");
                Main mainWin = new Main(ctrl);
                mainWin.Text = "Main window for " + user;
                mainWin.Show();
                this.Hide();
            }catch(Exception ex)
            {
                MessageBox.Show(this, "Login Error " + ex.Message/*+ex.StackTrace*/, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

    }
}