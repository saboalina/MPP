using System.ComponentModel;
using System.Windows.Forms;

namespace client
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.excursiiTable = new System.Windows.Forms.DataGridView();
            this.logoutBtn = new System.Windows.Forms.Button();
            this.cautareTable = new System.Windows.Forms.DataGridView();
            this.obiectivTuristicTextbox = new System.Windows.Forms.TextBox();
            this.cautaBtn = new System.Windows.Forms.Button();
            this.maxPicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numeClientTextbox = new System.Windows.Forms.TextBox();
            this.telefonTextbox = new System.Windows.Forms.TextBox();
            this.nrBileteNumeric = new System.Windows.Forms.NumericUpDown();
            this.rezervaBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize) (this.excursiiTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.cautareTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.nrBileteNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // excursiiTable
            // 
            this.excursiiTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.excursiiTable.Location = new System.Drawing.Point(52, 80);
            this.excursiiTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.excursiiTable.Name = "excursiiTable";
            this.excursiiTable.RowTemplate.Height = 24;
            this.excursiiTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.excursiiTable.Size = new System.Drawing.Size(936, 193);
            this.excursiiTable.TabIndex = 0;
            this.excursiiTable.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.excursiiTable_RowPrePaint);
            // 
            // logoutBtn
            // 
            this.logoutBtn.ForeColor = System.Drawing.Color.Black;
            this.logoutBtn.Location = new System.Drawing.Point(874, 15);
            this.logoutBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logoutBtn.Name = "logoutBtn";
            this.logoutBtn.Size = new System.Drawing.Size(114, 41);
            this.logoutBtn.TabIndex = 1;
            this.logoutBtn.Text = "Log out";
            this.logoutBtn.UseVisualStyleBackColor = true;
            this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
            // 
            // cautareTable
            // 
            this.cautareTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cautareTable.Location = new System.Drawing.Point(52, 408);
            this.cautareTable.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cautareTable.Name = "cautareTable";
            this.cautareTable.RowTemplate.Height = 24;
            this.cautareTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.cautareTable.Size = new System.Drawing.Size(516, 248);
            this.cautareTable.TabIndex = 4;
            this.cautareTable.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.cautareTable_RowPrePaint);
            // 
            // obiectivTuristicTextbox
            // 
            this.obiectivTuristicTextbox.Location = new System.Drawing.Point(218, 311);
            this.obiectivTuristicTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.obiectivTuristicTextbox.Name = "obiectivTuristicTextbox";
            this.obiectivTuristicTextbox.Size = new System.Drawing.Size(200, 26);
            this.obiectivTuristicTextbox.TabIndex = 5;
            // 
            // cautaBtn
            // 
            this.cautaBtn.Location = new System.Drawing.Point(461, 349);
            this.cautaBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cautaBtn.Name = "cautaBtn";
            this.cautaBtn.Size = new System.Drawing.Size(84, 41);
            this.cautaBtn.TabIndex = 8;
            this.cautaBtn.Text = "Search";
            this.cautaBtn.UseVisualStyleBackColor = true;
            this.cautaBtn.Click += new System.EventHandler(this.cautaBtn_Click);
            // 
            // maxPicker
            // 
            this.maxPicker.CustomFormat = "HH:mm";
            this.maxPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.maxPicker.Location = new System.Drawing.Point(218, 750);
            this.maxPicker.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.maxPicker.Name = "maxPicker";
            this.maxPicker.ShowUpDown = true;
            this.maxPicker.Size = new System.Drawing.Size(178, 26);
            this.maxPicker.TabIndex = 10;
            this.maxPicker.Value = new System.DateTime(2021, 3, 20, 23, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(52, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "Destination:\r\n";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(52, 357);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "Date:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(491, 747);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "Ora sosire:";
            // 
            // numeClientTextbox
            // 
            this.numeClientTextbox.Location = new System.Drawing.Point(784, 339);
            this.numeClientTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numeClientTextbox.Name = "numeClientTextbox";
            this.numeClientTextbox.Size = new System.Drawing.Size(203, 26);
            this.numeClientTextbox.TabIndex = 14;
            // 
            // telefonTextbox
            // 
            this.telefonTextbox.Location = new System.Drawing.Point(785, 476);
            this.telefonTextbox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.telefonTextbox.Name = "telefonTextbox";
            this.telefonTextbox.Size = new System.Drawing.Size(203, 26);
            this.telefonTextbox.TabIndex = 15;
            // 
            // nrBileteNumeric
            // 
            this.nrBileteNumeric.Location = new System.Drawing.Point(783, 538);
            this.nrBileteNumeric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nrBileteNumeric.Maximum = new decimal(new int[] {1000, 0, 0, 0});
            this.nrBileteNumeric.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.nrBileteNumeric.Name = "nrBileteNumeric";
            this.nrBileteNumeric.Size = new System.Drawing.Size(204, 26);
            this.nrBileteNumeric.TabIndex = 16;
            this.nrBileteNumeric.Value = new decimal(new int[] {1, 0, 0, 0});
            // 
            // rezervaBtn
            // 
            this.rezervaBtn.Location = new System.Drawing.Point(619, 613);
            this.rezervaBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rezervaBtn.Name = "rezervaBtn";
            this.rezervaBtn.Size = new System.Drawing.Size(368, 43);
            this.rezervaBtn.TabIndex = 17;
            this.rezervaBtn.Text = "Buy ticket";
            this.rezervaBtn.UseVisualStyleBackColor = true;
            this.rezervaBtn.Click += new System.EventHandler(this.rezervaBtn_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(645, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 29);
            this.label5.TabIndex = 18;
            this.label5.Text = "Cilient name:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(637, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 29);
            this.label6.TabIndex = 19;
            this.label6.Text = "Client address:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(645, 540);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 29);
            this.label7.TabIndex = 20;
            this.label7.Text = "No seats";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(637, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 23);
            this.label8.TabIndex = 21;
            this.label8.Text = "Tourists name:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(783, 408);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(204, 26);
            this.textBox1.TabIndex = 22;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(218, 361);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 26);
            this.dateTimePicker1.TabIndex = 23;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 676);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rezervaBtn);
            this.Controls.Add(this.nrBileteNumeric);
            this.Controls.Add(this.telefonTextbox);
            this.Controls.Add(this.numeClientTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maxPicker);
            this.Controls.Add(this.cautaBtn);
            this.Controls.Add(this.obiectivTuristicTextbox);
            this.Controls.Add(this.cautareTable);
            this.Controls.Add(this.logoutBtn);
            this.Controls.Add(this.excursiiTable);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.Text = "Agentie de Turism";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize) (this.excursiiTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.cautareTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.nrBileteNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.DateTimePicker dateTimePicker1;

        private System.Windows.Forms.TextBox textBox1;

        private System.Windows.Forms.Label label8;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nrBileteNumeric;
        private System.Windows.Forms.TextBox numeClientTextbox;
        private System.Windows.Forms.Button rezervaBtn;
        private System.Windows.Forms.TextBox telefonTextbox;

        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.DateTimePicker maxPicker;

        private System.Windows.Forms.Button cautaBtn;

        private System.Windows.Forms.TextBox obiectivTuristicTextbox;

        private System.Windows.Forms.DataGridView cautareTable;

        private System.Windows.Forms.Button logoutBtn;

        private System.Windows.Forms.DataGridView excursiiTable;

        #endregion
    }
}