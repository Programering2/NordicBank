using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class Transaction
    {

        //fields
        float Amount;
        float RecievingTransactionNumber;
        float transmittingTransactionNumber;
        Banken myBank = new Banken();

        public Transaction(float Amount, float RecievingTransactionNumber, float transmittingTransactionNumber, Banken bank) //constructor
        {
            this.Amount = Amount;
            this.RecievingTransactionNumber = RecievingTransactionNumber;
            this.transmittingTransactionNumber = transmittingTransactionNumber;
            this.myBank = bank;
        }

        //getters
        public float getAmount() { return Amount; }
        public float getRecievingTransactionNumber() { return RecievingTransactionNumber; }
        public float getTransmittingTransactionNumber() { return transmittingTransactionNumber; }

        //setters

    }
}
