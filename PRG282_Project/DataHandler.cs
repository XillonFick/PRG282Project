using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG282_Project
{
    public class DataHandler
    {
        public DataHandler() { }

        string connectionString = "Server=(local); Initial Catalog= ; Integrated Security = SSPI";

        FileHandler filer = new FileHandler();

        public bool ValidateLogin(string name, string pass = "")
        {
            if (pass != "")
            {
                try
                {
                    List<LoginDetails> logdetails = filer.GetLogin();

                    foreach (LoginDetails item in logdetails)
                    {
                        if (name == item.UserName && pass == item.Password)
                        {
                            return true;
                        }
                    }
                    return false;

                }
                catch (FormatException)
                {
                    MessageBox.Show("Valid input required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception er)
                {

                    MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                try
                {
                    List<LoginDetails> logdetails = filer.GetLogin();

                    foreach (LoginDetails item in logdetails)
                    {
                        if (name == item.UserName)
                        {
                            return true;
                        }
                    }
                    return false;

                }
                catch (FormatException)
                {
                    MessageBox.Show("Valid User Name input required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception er)
                {

                    MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
           

        }

        public void CreateNew()
        {

        }
    }
}
