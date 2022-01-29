using Laborator4.domain;
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
    public partial class SearchPage : Form
    {

        Service service;
        public SearchPage(Service service)
        {
            this.service = service;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SearchPage_Load(object sender, EventArgs e)
        {
            //IEnumerable<Zbor> tabel = service.findAllZboruri();
            //dataGridView1.DataSource = tabel;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zbor zbor = dataGridView1.CurrentRow.DataBoundItem as Zbor;
            BuyPage buyPage = new BuyPage(service, zbor);
            buyPage.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String destinatie = textBox1.Text;
            DateTime data = dateTimePicker1.Value;
            IEnumerable<Zbor> tabel = service.FilterByDestinatie(destinatie,data);
            dataGridView1.DataSource = tabel;
        }
    }
}
