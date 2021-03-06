using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project
{
    class Student
    {
        private string id;
        private string name;
        private string surname;
 
        private DateTime doB;
        private char gender;
        private string phoneNumber;
        private string address;
        private List<string> modulecodes;

        public Student() { }

        public Student(string name, string surname, DateTime doB, char gender, string phoneNumber, string address, List<string> modulecodes)
        {
            this.Name = name;
            this.Surname = surname;  
          
            this.DoB = doB;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Modulecodes = modulecodes;
        }

        public Student(string id, string name, string surname, DateTime doB, char gender, string phoneNumber, string address, List<string> modulecodes)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
         
            this.doB = doB;
            this.gender = gender;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.modulecodes = modulecodes;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        
        public DateTime DoB { get => doB; set => doB = value; }
        public char Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public List<string> Modulecodes { get => modulecodes; set => modulecodes = value; }
        public string Id { get => id; set => id = value; }

        public override string ToString()
        {
            string modules="";
            foreach (var item in this.Modulecodes)
            {
                modules += string.Format("\n{0}",item.ToString());
            }
            return string.Format("{0},{1},{2},{3},{4},{5},{6}",
                this.Name,this.Surname,this.DoB,this.DoB.ToString(),this.Gender,this.PhoneNumber,this.Address,modules);
        }
    }
}
