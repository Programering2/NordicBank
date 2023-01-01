using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NordicBank
{
    internal static class Program
    {
        //fields
        static BankClassLibrary.Banken minBank = new BankClassLibrary.Banken();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            loadData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(minBank));

        }

        static void loadData()
        {
            minBank = BankClassLibrary.FileHandler.ReadFile(BankClassLibrary.FileHandler.FileName);
        }
    }
}
