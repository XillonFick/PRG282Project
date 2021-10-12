using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Project
{
    public partial class frmRegister : Form
    {
        FileHandler handler = new FileHandler();
        DataHandler DataHandler = new DataHandler();
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (DataHandler.ValidateLogin(txtUsername.Text) == false)
            {

            if (txtPassword.Text == txtConfirmP.Text)
            {
                bool success = handler.Register(txtUsername.Text, txtPassword.Text);
                if (success)
                {
                    MessageBox.Show("Successfully Registered", "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Could not register user", "Register Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Passwords do not Match","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            }
            else
            {
                MessageBox.Show("User already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
