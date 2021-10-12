using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project
{
    class LoginDetails
    {
        private string userName;
        private string password;

        public  LoginDetails() { }

        public LoginDetails(string userName, string password)
        {
            this.UserName = userName;
            this.Password = password;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
