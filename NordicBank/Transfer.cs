using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NordicBank
{
    public partial class Transfer : Form
    {
        BankClassLibrary.Banken myBank = new BankClassLibrary.Banken(); 
        int RecievingAccount = 0;
        public Transfer(BankClassLibrary.Banken bank)
        {
            InitializeComponent();
            myBank = bank;
        }

        private void Transfer_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //överför
        {
            int SendingAccount = int.Parse(t_transmitter.Text); //ta in data från textfields
            int Amount = int.Parse(t_Amount.Text);

            if (SendingAccount != RecievingAccount) //man kan inte skicka till samma konto
            {
                if (Amount > 0) //har du mer än 0 kr?
                {
                    if (Amount < myBank.getUser(myBank.getActiveUserKey()).GetPersonalAccount().getBalance()) //du vill skicka mindre än vad du har
                    {

                        BankClassLibrary.Transaction transaction = new BankClassLibrary.Transaction(Amount, RecievingAccount, SendingAccount, myBank); //överföringen godkänd
                        myBank.SubmitTransfer(transaction); //genomför transaktionen
                        ErrorMsg.Text = "ÖÄverföring Lyckades!";
                        ErrorMsg.ForeColor = Color.Green;

                        BankClassLibrary.FileHandler.UpdateUser(BankClassLibrary.FileHandler.FileName, myBank); //överför data

                    }
                    else ErrorMsg.Text = "Du har inte så mycket på ditt konto";
                }
                else ErrorMsg.Text = "Du kan inte överföra negativa summor";

            }
            else ErrorMsg.Text = "Du kan inte överföra till samma konto!";

            //check amount avilable
            //check account is okay
            //if account is a personalAccount display name after enter 
        }

        private void button2_Click(object sender, EventArgs e) //stäng ner
        {
            Close();
        }

        private void T_recievingEnd_Leave(object sender, EventArgs e) //skriver in namnet på banknummret när användaren lämnar textbox med musen
        {
            string owner = "";
            RecievingAccount = int.Parse(T_recievingEnd.Text);
            if (myBank.GetNameOfAccountOwner(int.Parse(T_recievingEnd.Text)).Length > 1)
            {
                T_recievingEnd.Text = myBank.GetNameOfAccountOwner(int.Parse(T_recievingEnd.Text));
            }

        }
    }
}
