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
            loadData(); // lada ner alla users från en .txt
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login(minBank)); // vi vill starta med Login sidan

        }

        static void loadData()//läs in användarna 
        {
            minBank = BankClassLibrary.FileHandler.ReadFile(BankClassLibrary.FileHandler.FileName);
        }
    }
}
