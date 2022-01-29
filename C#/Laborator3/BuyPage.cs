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
    public partial class BuyPage : Form
    {
        Service service;
        Zbor zbor;
        public BuyPage(Service service, Zbor zbor)
        {
            this.service = service;
            this.zbor = zbor;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String numeClient = textBox1.Text;
            String numeTuristi = textBox2.Text;
            String adresaClient = textBox3.Text;
            int nrLocuri = int.Parse(textBox4.Text);
            int zborId = zbor.getId();
            Bilet bilet = new Bilet(numeClient, numeTuristi, adresaClient, nrLocuri, zborId);
            
            IEnumerable<Bilet> bilete = service.findAllBilete();
            int i = bilete.ToList().Count;
            bilet.id = i + 1;

            //label5.Text = bilet.getId() + "/" + bilet.numeTuristi;
            
            service.addBilet(bilet);
        }

        private void BuyPage_Load(object sender, EventArgs e)
        {

        }
    }
}
