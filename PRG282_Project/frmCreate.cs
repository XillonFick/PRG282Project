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

            string errorMessage = "Default Error Message";
            try
            {
                if (String.IsNullOrEmpty(txtName.Text))
                {
                    errorMessage = "Please enter a valid name";
                    throw new Exception();
                }

                if (String.IsNullOrEmpty(txtSurname.Text))
                {
                    errorMessage = "Please enter a valid surname";
                    throw new Exception();
                }

                if (String.IsNullOrEmpty(txtDoB.Text))
                {
                    errorMessage = "Please enter a valid Date of Birth";
                    throw new Exception();
                }

                if (String.IsNullOrEmpty(cmbGender.Text))
                {
                    errorMessage = "Please choose a valid gender";
                    throw new Exception();
                }
                else if (string.IsNullOrEmpty(cmbGender.Text))
                {
                    errorMessage = "Gender must be male or female";
                    throw new Exception();
                }

                if (String.IsNullOrEmpty(txtPhone.Text) || txtPhone.Text.Length != 10)
                {
                    errorMessage = "Please enter a valid phone number that is exactly 10 digits long";
                    throw new Exception();
                }
                else if (!int.TryParse(txtPhone.Text, out int number))
                {
                    errorMessage = "Phone number must be a a valid integer number";
                    throw new Exception();
                }

                if (String.IsNullOrEmpty(txtAddress.Text))
                {
                    errorMessage = "Please enter a valid address";
                    throw new Exception();
                }

                if (modules.Count <= 0)
                {
                    errorMessage = "Must select atleast 1 module";
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime date;
            if (!DateTime.TryParse(txtDoB.Text, out date))
                date = DateTime.Now;

            data.CreateNew(txtName.Text, txtSurname.Text, "Some Course", date, cmbGender.SelectedItem.ToString()[0], txtPhone.Text, txtAddress.Text, modules);
            txtName.Text = "";
            txtSurname.Text = "";
            txtDoB.Text = "";
            cmbGender.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";

            for (int i = 0; i < clbModules.Items.Count; i++)
                clbModules.SetItemChecked(i, false);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMain main = new frmMain();
            this.Close();
            main.Show();
        }
    }
}
