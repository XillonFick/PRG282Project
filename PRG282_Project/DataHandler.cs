using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PRG282_Project
{
    public class DataHandler
    {
        public DataHandler() { }

        string connectionString = "Server=(local); Initial Catalog= ; Integrated Security = SSPI";

        FileHandler filer = new FileHandler();

        SqlConnection connect;

        public void Connect()
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        public bool ValidateLogin(string name, string pass = "")
        {
            if (pass != "")
            {
                //if password is passed then it is assumed that the usser is registered and checks
                //valid login details
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
                //if no password is passed it is assumed that a user is to be registered and 
                //therefore checks if the user already exists to prevent duplicate usernames
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

        public void CreateNew(string name, string surname, string course, DateTime doB, char gender, string phoneNumber, string address, List<string> modulecodes)
        {
            using (connect)
            {
                SqlCommand cmd = new SqlCommand("",connect);
                cmd.CommandType = CommandType.StoredProcedure;
                //Subject to change based on how db has been set up
                //modules would liekley have to be passed as a Table and inserted into the modules table by the Stored Proc
                cmd.Parameters.AddWithValue("", name);
                cmd.Parameters.AddWithValue("",surname);
                cmd.Parameters.AddWithValue("",course);
                cmd.Parameters.AddWithValue("",doB);
                cmd.Parameters.AddWithValue("",gender);
                cmd.Parameters.AddWithValue("",phoneNumber);
                cmd.Parameters.AddWithValue("",address);
                cmd.Parameters.AddWithValue("",modulecodes);
            }

        }
    }
}
