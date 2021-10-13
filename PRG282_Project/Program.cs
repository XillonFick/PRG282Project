using PRG282_Assignment_GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PRG282_Project
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmDelete());

            
        }
    }
}
