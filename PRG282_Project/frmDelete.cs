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
    public partial class frmDelete : Form
    {
        public frmDelete()
        {
            InitializeComponent();
        }
        DataHandler handler = new DataHandler();
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool valid = int.TryParse(txtStudentID.Text, out int studentID);
                if (valid)
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete studentID :" + studentID.ToString()
                      + " ?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        handler.DeleteStudent(studentID);
                         MessageBox.Show("Student Deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        txtStudentID.Clear();
                    }

                }
                else
                {
                    throw new FormatException();
                }

            }
            catch (FormatException)
            {

                MessageBox.Show("Insert Valid studentNumber", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmDelete_Load(object sender, EventArgs e)
        {
            handler.Connect();
            label1.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
        }
    }
}
