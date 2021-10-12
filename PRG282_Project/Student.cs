using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG282_Project
{
    class Student
    {
        private string name;
        private string surname;
        private string course;
        private DateTime doB;
        private char gender;
        private string phoneNumber;
        private string address;
        private List<string> modulecodes;

        public Student() { }

        public Student(string name, string surname, string course, DateTime doB, char gender, string phoneNumber, string address, List<string> modulecodes)
        {
            this.Name = name;
            this.Surname = surname;  
            this.Course = course;
            this.DoB = doB;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.Address = address;
            this.Modulecodes = modulecodes;
        }

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Course { get => course; set => course = value; }
        public DateTime DoB { get => doB; set => doB = value; }
        public char Gender { get => gender; set => gender = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Address { get => address; set => address = value; }
        public List<string> Modulecodes { get => modulecodes; set => modulecodes = value; }

        public override string ToString()
        {
            string modules="";
            foreach (var item in this.Modulecodes)
            {
                modules += string.Format("\n{0}",item.ToString());
            }
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
                this.Name,this.Surname,this.Course,this.DoB,this.DoB.ToString(),this.Gender,this.PhoneNumber,this.Address,modules);
        }
    }
}
