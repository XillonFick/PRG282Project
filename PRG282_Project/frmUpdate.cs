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
    public partial class frmUpdate : Form
    {
        DataHandler handler = new DataHandler();
        public frmUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(txtID.Text, out int ID))
                {
                    if ((DateTime.TryParse(txtDoB.Text, out DateTime date)) || string.IsNullOrEmpty(txtDoB.Text))
                    {
                        handler.Update(ID, txtName.Text, txtSurname.Text, date, cmbGender.Text, txtPhone.Text, txtAddress.Text);
                    }
                    else
                    {
                        throw new InvalidDate();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (InvalidDate)
            {

                MessageBox.Show("Insert Valid DoB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
           
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            handler.Connect();
        }
    }
}
