using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


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
    }
}
