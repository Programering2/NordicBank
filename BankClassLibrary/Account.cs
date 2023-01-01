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

        public Account(Banken bank)
        {
            this.balance = 100.00f;
            myBank = bank;
            Random random = new Random();
            BankNumber = random.Next(100000, 999999);
        }

        //Add trans();
        //sort history()

        //getters
        public float getBalance()
        {
            return balance;
        }

        public float getBankNumber()
        {
            return BankNumber;
        }

        //setters
        private protected void setBankNumber(int number)
        { 
            this.BankNumber = number;
        }

        public void setBalance(int balance)
        { 
            this.balance = balance;
        
        }

        public void AddBalance(float balance)
        {
            this.balance += balance;
        }

        public void subtractBalance(float balance)
        {
            this.balance -= balance;
        }
    }
}
