using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project
{
    public class InvalidDate:Exception
    {
        public InvalidDate() { }
        public InvalidDate(string message):base(message)
        { }
        public InvalidDate(string message,Exception inner) : base(message,inner)
        { }
    }
}
