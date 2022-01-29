using Laborator4.domain;
using Laborator4.repository;
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
    public partial class MainPage : Form
    {
        Service service;
        public MainPage(Service service)
        {
            this.service = service;

            InitializeComponent();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            IEnumerable<Zbor> tabel = service.findAllZboruri();
            dataGridView1.DataSource = tabel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchPage searchPage = new SearchPage(service);
            searchPage.Show();
        }
    }
}
