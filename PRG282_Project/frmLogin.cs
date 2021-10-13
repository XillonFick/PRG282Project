using PRG282_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Assignment_GUI
{
    public partial class frmLogin : Form
    {

        DataHandler handler = new DataHandler();
      
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            handler.Connect();
            label3.BackColor = System.Drawing.Color.Transparent;
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 0, pictureBox1.Height - 0);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (handler.ValidateLogin(txtUsername.Text, txtPassword.Text)== true)
            {
                frmMain main = new frmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect Login Details","Unable to Login",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (handler.ValidateLogin(txtUsername.Text, txtPassword.Text) == true)
                {
                    frmMain main = new frmMain();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Login Details", "Unable to Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            frmRegister reg = new frmRegister();
            reg.Show();
        }
    }
}
