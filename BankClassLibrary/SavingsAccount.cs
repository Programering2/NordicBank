using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class SavingsAccount:Account
    {

        float Intrest;
        bool TransferLock;
        float LockTime;

        public SavingsAccount(Banken bank):base(bank) //derived constructor
        { 
        }

        public void setTransferLock(bool shouldbeLocked)
        { 
            this.TransferLock = shouldbeLocked;
        }

        //getters

        //setters
        public void setIntrest(float intrest)
        {
            this.Intrest = intrest; 
        }
    }
}
