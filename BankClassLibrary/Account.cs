using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class Account
    {

        //fields
        float balance;
        int BankNumber;
        Banken myBank = new Banken();
        //List()<Trans>

        public Account(Banken bank) //konstruktor för Account 
        {
            this.balance = 100.00f;
            myBank = bank;
            Random random = new Random();
            BankNumber = random.Next(100000, 999999); //här initialiserar vi alla fields
        }

        //Add trans();
        //sort history()

        //getters
        public float getBalance() //getter för balance
        {
            return balance;
        }

        public float getBankNumber() //getter för banknummer
        {
            return BankNumber;
        }

        //setters
        private protected void setBankNumber(int number) //setter för banknummer
        { 
            this.BankNumber = number;
        }

        public void setBalance(int balance) //setter för balance
        { 
            this.balance = balance;
        
        }

        public void AddBalance(float balance) // adera balancen
        {
            this.balance += balance;
        }

        public void subtractBalance(float balance) //subtrahera balance
        {
            this.balance -= balance;
        }
    }
}
