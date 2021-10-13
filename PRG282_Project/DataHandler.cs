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

        string connectionString = "Server=(local); Initial Catalog= PRG282_Project_Database; Integrated Security = SSPI";

        FileHandler filer = new FileHandler();

        SqlConnection connect;

        public void Connect()
        {
            connect = new SqlConnection(connectionString);
            connect.Open();
        }

        private void SetModuleDefaults(string moduleIndex, out string moduleCode, out string moduleName, out string moduleDescription)
        {
            switch (moduleIndex)
            {
                case "1":
                    moduleCode = "MAT281";
                    moduleName = "Mathematics 281";
                    moduleDescription = "Mathematics description";
                    break;
                case "2":
                    moduleCode = "STA281";
                    moduleName = "Statistics 281";
                    moduleDescription = "Statistics description";
                    break;
                case "3":
                    moduleCode = "PRG281";
                    moduleName = "Programming 281";
                    moduleDescription = "Programming description";
                    break;
                case "4":
                    moduleCode = "DBD281";
                    moduleName = "Database Design 281";
                    moduleDescription = "Database development is fun!";
                    break;
                case "5":
                    moduleCode = "NWD281";
                    moduleName = "Network Design 281";
                    moduleDescription = "Network development is fun!";
                    break;
                default:
                    moduleCode = "MAT281";
                    moduleName = "Mathematics 281";
                    moduleDescription = "Mathematics description";
                    break;
            }
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
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("spSearchStudent", con);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand.Parameters.AddWithValue("@ID", int.Parse(StudentID));

            DataTable table = new DataTable();

            adapter.Fill(table);

            return table;
        }

        public void CreateNew(string name, string surname, string course, DateTime doB, char gender, string phoneNumber, string address, List<string> modulecodes)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spAddStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //Subject to change based on how db has been set up
                //modules would liekley have to be passed as a Table and inserted into the modules table by the Stored Proc
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Surname", surname);
                //cmd.Parameters.AddWithValue("", course);  Not course column exists yet
                cmd.Parameters.AddWithValue("@DOB", doB);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                cmd.Parameters.AddWithValue("@Address", address);
                //cmd.Parameters.AddWithValue("@Adress", modulecodes);
                cmd.ExecuteNonQuery();

                SqlCommand Newcmd = new SqlCommand("spGetNewlyAddedStudent", con);
                Int32 id = (Int32)Newcmd.ExecuteScalar();

                foreach (string moduleID in modulecodes)
                {
                    string moduleCode;
                    string moduleName;
                    string moduleDescription;
                    string resourceLink = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                    SetModuleDefaults(moduleID, out moduleCode, out moduleName, out moduleDescription);

                    SqlCommand moduleCmd = new SqlCommand("spAddModuleToStudent", con);
                    moduleCmd.CommandType = CommandType.StoredProcedure;
                    moduleCmd.Parameters.AddWithValue("@ID", id);
                    moduleCmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
                    moduleCmd.Parameters.AddWithValue("@ModuleName", moduleName);
                    moduleCmd.Parameters.AddWithValue("@ModuleDescription", moduleDescription);
                    moduleCmd.Parameters.AddWithValue("@ResourceLinks", resourceLink);

                    moduleCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student Added Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }

        public void Update(int studID, string name, string surname, DateTime doB, string gender, string phoneNumber, string address, List<string> modulecodes)
        {
            string iName = "StudentName";
            string iSurname = "StudentSurname";
            string iDOB = "DOB";
            string iGender = "Gender";
            string iPhone = "Phone";
            string iAdress = "Adress";


            if (string.IsNullOrEmpty(name) == false)
            {
                //iName = string.Format("StudentName= {0}", name);
                iName = name;
            }
            if (string.IsNullOrEmpty(surname) == false)
            {
                //iSurname = string.Format("StudentSurname= {0}", name);
                iSurname = surname;
            }
            if (string.IsNullOrEmpty(doB.ToString()) == false)
            {
                //iDOB = string.Format("DOB = {0}", doB) ;
                //iDOB = doB;
            }
            if (string.IsNullOrEmpty(gender.ToString()) == false)
            {
                //iGender = string.Format("Gender = {0}", gender.ToString());
                iGender = gender;
            }
            if (string.IsNullOrEmpty(phoneNumber) == false)
            {
                //iPhone = string.Format("Phone = {0}", phoneNumber);
                iPhone = phoneNumber;
            }
            if (string.IsNullOrEmpty(address) == false)
            {
                //iAdress = string.Format("Adress = {0}", address);
                iAdress = address;
            }


            using (connect)
            {
                // Updating the students table with the new data
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("spUpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", studID);
                cmd.Parameters.AddWithValue("@Name", iName);
                cmd.Parameters.AddWithValue("@Surname", iSurname);
                cmd.Parameters.AddWithValue("@DOB", doB);
                cmd.Parameters.AddWithValue("@Gender", iGender);
                cmd.Parameters.AddWithValue("@Phone", iPhone);
                cmd.Parameters.AddWithValue("@Address", iAdress);

                cmd.ExecuteNonQuery();

                // removing the existing modules assigned to the student
                SqlCommand deleteCmd = new SqlCommand("spRemoveStudentModules", con);
                deleteCmd.CommandType = CommandType.StoredProcedure;
                deleteCmd.Parameters.AddWithValue("@ID", studID);
                deleteCmd.ExecuteNonQuery();

                // Assigning the selected modules to the student
                foreach (string moduleID in modulecodes)
                {
                    string moduleCode;
                    string moduleName;
                    string moduleDescription;
                    string resourceLink = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
                    SetModuleDefaults(moduleID, out moduleCode, out moduleName, out moduleDescription);

                    SqlCommand moduleCmd = new SqlCommand("spAddModuleToStudent", con);
                    moduleCmd.CommandType = CommandType.StoredProcedure;
                    moduleCmd.Parameters.AddWithValue("@ID", studID);
                    moduleCmd.Parameters.AddWithValue("@ModuleCode", moduleCode);
                    moduleCmd.Parameters.AddWithValue("@ModuleName", moduleName);
                    moduleCmd.Parameters.AddWithValue("@ModuleDescription", moduleDescription);
                    moduleCmd.Parameters.AddWithValue("@ResourceLinks", resourceLink);

                    moduleCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Student Successfully Updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DeleteStudent(int studID)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("spDeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ID", studID);
            cmd.ExecuteNonQuery();

        }
    }
}
