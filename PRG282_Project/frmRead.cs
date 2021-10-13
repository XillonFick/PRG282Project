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
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
