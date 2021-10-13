﻿using System;
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

        string connectionString = "Server=(local); Initial Catalog= PRG282_Project_Database; Integrated Security = SSPI";

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
                //if password is passed then it is assumed that the user is registered and checks
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
        public DataTable Read()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("spGetStudents", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }
        public DataTable getModules(string StudentID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("spGetStudentModules", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand.Parameters.AddWithValue("@ID",StudentID);
            
            DataTable table = new DataTable();

            adapter.Fill(table);
            con.Close(); 
            return table;
        }

        public DataTable Search(string StudentID)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("spSearchStudent", connect);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand.Parameters.AddWithValue("@ID", int.Parse(StudentID));

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public void CreateNew(string name, string surname, string course, DateTime doB, char gender, string phoneNumber, string address, List<string> modulecodes)
        {
            using (connect)
            {
                SqlCommand cmd = new SqlCommand("spAddStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                //Subject to change based on how db has been set up
                //modules would liekley have to be passed as a Table and inserted into the modules table by the Stored Proc
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                //cmd.Parameters.AddWithValue("", course);  Not course column exists yet
                cmd.Parameters.AddWithValue("@DOB", doB);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                cmd.Parameters.AddWithValue("@Phone", address);
                //cmd.Parameters.AddWithValue("@Adress", modulecodes);

                foreach (string moduleID in modulecodes)
                {
                    string moduleCode;
                    string moduleName;
                    string moduleDescription;
                    switch (moduleID)
                    {
                        case "1":

                        default:
                            break;
                    }
                }
            }

        }

        public void Update(int studID, string name, string surname, DateTime doB, string gender, string phoneNumber, string address)
        {
            string iName = "StudentName= StudentName";
            string iSurname = "StudentSurname= StudentSurname";
            string iDOB = "DOB = DOB";
            string iGender = "Gender = Gender";
            string iPhone = "Phone = Phone";
            string iAdress = "Adress = Adress";


            if (string.IsNullOrEmpty(name) == false)
            {
                iName = string.Format("StudentName= {0}", name);
            }
            if (string.IsNullOrEmpty(surname) == false)
            {
                iSurname = string.Format("StudentSurname= {0}", name);
            }
            if (string.IsNullOrEmpty(doB.ToString()) == false)
            {
                iDOB = string.Format("DOB = {0}", doB) ;
            }
            if (string.IsNullOrEmpty(gender.ToString()) == false)
            {
                iGender = string.Format("Gender = {0}", gender.ToString());
            }
            if (string.IsNullOrEmpty(phoneNumber) == false)
            {
                iPhone = string.Format("Phone = {0}", phoneNumber);
            }
            if (string.IsNullOrEmpty(address) == false)
            {
                iAdress = string.Format("Adress = {0}", address);
            }


            using (connect)
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", studID);
                cmd.Parameters.AddWithValue("@Name", iName);
                cmd.Parameters.AddWithValue("@Surname", iSurname);
                cmd.Parameters.AddWithValue("@DOB", iDOB);
                cmd.Parameters.AddWithValue("@Gender", iGender);
                cmd.Parameters.AddWithValue("@Phone", iPhone);
                cmd.Parameters.AddWithValue("@Address", iAdress);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteStudent(int studID)
        {
            using (connect)
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", studID);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
