using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using client.client;
using model;
using services;

namespace client
{
    public partial class Main : Form
    {
        private readonly Controller ctrl;
        private readonly List<Excursie> excursiiData;
        private List<Excursie> cautareData;
        
        public Main(Controller ctrl)
        {
            InitializeComponent();
            this.ctrl = ctrl;
            //agentTextbox.Text = ctrl.getAgentUsername();
            excursiiData = ctrl.getAllExcursie().ToList();
            IEnumerable<Excursie> lista = ctrl.getAllExcursie();
            excursiiTable.DataSource = lista;
            // BindingSource bs = new BindingSource();
            // bs.DataSource = excursiiData;
            // excursiiTable.DataSource = bs;
            // excursiiTable.Columns["ID"].Visible = false;
            // excursiiTable.Columns["Ora"].DefaultCellStyle.Format = "HH:mm";
            ctrl.updateEvent += userUpdate;
            /*
             * IEnumerable<Zbor> tabel = service.findAllZboruri();
            dataGridView1.DataSource = tabel;
             */
        }
        
        private void ChatWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("ChatWindow closing "+e.CloseReason);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ctrl.logout();
                Application.Exit();
            }
        }

        private void initCautareTable()
        {
            String nume = obiectivTuristicTextbox.Text;
            cautareData = ctrl.getAllExcursieNameTime(nume);
            IEnumerable<Excursie> lista= ctrl.getAllExcursieNameTime(nume);
            cautareTable.DataSource=lista;
            
        }

        void excursiiTable_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRowCollection rows = excursiiTable.Rows;
            foreach (DataGridViewRow row in rows)
            {
                // if (Convert.ToInt32(row.Cells["NrLocuri"].Value) == 0 && row != rows[rows.Count -1])
                //     row.DefaultCellStyle.BackColor = Color.Red;
            }
        }
        
        void cautareTable_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRowCollection rows = cautareTable.Rows;
            foreach (DataGridViewRow row in rows)
            {
                // if (Convert.ToInt32(row.Cells["NrLocuri"].Value) == 0 && row != rows[rows.Count -1])
                //     row.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            ctrl.logout();
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
                Excursie selectedExcursie = (Excursie) cautareTable.SelectedRows[0].DataBoundItem;
                String client = numeClientTextbox.Text;
                String telefon = telefonTextbox.Text;
                int nrBilete = (int) nrBileteNumeric.Value;
                ctrl.addRezervare(client, telefon, nrBilete, selectedExcursie);
                MessageBox.Show("Success!");
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You need to select a flight!");
            }
        }

        public void userUpdate(object sender, UserEventArgs e)
        {
            if (e.UserEventType == UserEvent.NewRezervare)
            {
                Ticket rezervare = (Ticket)e.Data;
                int indexE = excursiiData.IndexOf(rezervare.Excursie);
                if (indexE > -1)
                {
                    excursiiData[indexE] = rezervare.Excursie;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = excursiiData;
                    // excursiiTable.BeginInvoke(new UpdateTableCallback(this.UpdateTable),
                    //     new Object[] {excursiiTable, bs});
                    excursiiTable.BeginInvoke((Action) delegate { excursiiTable.DataSource = bs; });
                }

                int indexC = cautareData.IndexOf(rezervare.Excursie);
                if (indexC > -1)
                {
                    cautareData[indexC] = rezervare.Excursie;
                    BindingSource bs = new BindingSource();
                    bs.DataSource = cautareData;
                    // cautareTable.BeginInvoke(new UpdateTableCallback(this.UpdateTable),
                    //     new Object[] {cautareTable, bs});
                    cautareTable.BeginInvoke((Action) delegate { cautareTable.DataSource = bs; });
                }
            }
        }
        
        public delegate void UpdateTableCallback(DataGridView list, BindingSource data);

        private void UpdateTable(DataGridView dgv, BindingSource ds)
        {
            dgv.DataSource = null;
            dgv.DataSource = ds;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}