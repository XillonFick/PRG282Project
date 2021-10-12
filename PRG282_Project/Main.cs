using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PRG282_Assignment_GUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            frmRead read = new frmRead();

            read.Show();
            this.Hide();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmDelete del = new frmDelete();

            del.Show();
            this.Hide();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmUpdate upd = new frmUpdate();

            upd.Show();
            this.Hide();

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCreate cre = new frmCreate();

            cre.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmLogin log = new frmLogin();
            this.Close();
            log.Show();
        }
    }
}
