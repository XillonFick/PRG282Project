using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace PRG282_Project
{
    class FileHandler
    {
        public FileHandler() { }

        public List<LoginDetails> GetLogin()
        {
            List<LoginDetails> returnList = new List<LoginDetails>();
            foreach (var item in File.ReadAllLines("Login.txt").ToList())
            {
                string[] items = item.Split(',');
                returnList.Add(new LoginDetails(items[0],items[1]));
            }
            return returnList;
          
        }

        public bool Register(string user, string password)
        {
            try
            {
                string addedUser = String.Format("{0},{1}",user,password);
                List<string> written = new List<string>();
                
                written.Add(addedUser);

                File.AppendAllLines("Login.txt",written);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
