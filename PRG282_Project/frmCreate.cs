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
            List<string> modules = new List<string>();
            //gets checked items from the modules list and adds it to a seperate list
            for (int i = 0; i <  clbModules.CheckedItems.Count; i++)
            {
                modules.Add((i+1).ToString());
            }

            
        }
    }
}
