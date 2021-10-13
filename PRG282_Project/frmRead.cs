using PRG282_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRG282_Assignment_GUI
{
    public partial class frmRead : Form
    {
        DataHandler handler = new DataHandler();
      
        public frmRead()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRead_Load(object sender, EventArgs e)
        {

           
            dgvDisplayStudents.DataSource = handler.Read();

        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Close();
            main.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvDisplayStudents.DataSource = handler.Search(txtId.Text);
        }


        private void dgvDisplayStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDisplayStudents.Rows[e.RowIndex];
                dgvModules.DataSource = handler.getModules(row.Cells["StudentNumber"].Value.ToString());
            }
        }

    }
}
