using PRG282_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRG282_Assignment_GUI
{
    
    public partial class frmCreate : Form
    {
        DataHandler data = new DataHandler();
        public frmCreate()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmCreate_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            label4.BackColor = System.Drawing.Color.Transparent;
            label5.BackColor = System.Drawing.Color.Transparent;
            label6.BackColor = System.Drawing.Color.Transparent;
            label7.BackColor = System.Drawing.Color.Transparent;
            label8.BackColor = System.Drawing.Color.Transparent;
            label9.BackColor = System.Drawing.Color.Transparent;
            data.Connect();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            List<string> modules = new List<string>();
            //gets checked items from the modules list and adds it to a seperate list
            for (int i = 0; i < clbModules.Items.Count; i++)
            {
                if (clbModules.GetItemChecked(i))
                    modules.Add((i + 1).ToString());
            }

            DateTime date;
            if (!DateTime.TryParse(txtDoB.Text, out date))
                date = DateTime.Now;

            data.CreateNew(txtName.Text, txtSurname.Text, "Some Course", date, cmbGender.SelectedItem.ToString()[0], txtPhone.Text, txtAddress.Text, modules);
        }
    }
}
