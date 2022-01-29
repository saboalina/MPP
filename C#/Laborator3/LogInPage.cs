using Laborator4.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator4
{
    public partial class LogInPage : Form
    {
        Service service;
        public LogInPage(Service service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String parola = textBox2.Text;
            if (username!=string.Empty && parola != string.Empty
                && service.getAngajat(username, parola)!=null)
            {
                MainPage mainpage = new MainPage(service);
                mainpage.Show();
                //this.Close();
            }
            else
            {
                MessageBox.Show("insucces!");
            }
        }

        private void LogInPage_Load(object sender, EventArgs e)
        {

        }
    }
}
