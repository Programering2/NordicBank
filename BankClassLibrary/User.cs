using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class User
    {

        //fields
        bool HasLoggedInOnce;
        float Totalbalance;
        string Name;
        int Phonenumber;
        int SocialNumber;
        int Pincode;
        Banken myBank = new Banken();
        List<Transaction> latestTransfers = new List<Transaction>();
        List<Account> Accounts = new List<Account>();
        PersonalAccount personalAccount;
        public User(int phonenumber, int socialNumber,int pincode, Banken bank)
        {
            Totalbalance = 0;
            this.Phonenumber = phonenumber;
            this.SocialNumber = socialNumber;
            this.Pincode = pincode;
            this.myBank = bank;
            OpenPersonalAccount();
        
        }
        //methods
       public void UpdateBalance()
        {
            float temp = 0;
            foreach (Account a in Accounts)
            { 
            temp += a.getBalance();
            }
            Totalbalance = temp;
        }
        // void UpdateLatestTransfers(Trans) 
        internal void OpenPersonalAccount()
        {
            personalAccount = new PersonalAccount(SocialNumber, myBank);
        }
        public void OpenSavingAccount()
        {
            Accounts.Add(new SavingsAccount(myBank));
        }
        public void OpenAccount()
        {
            Accounts.Add(new Account(myBank));
        }

     


        public void CloseAccount(int Banknumber) //ta bort ett konto
        {
            int temp = -1;

            for (int i = 0; i < Accounts.Count(); i++)
            {
                if (Accounts[i].getBankNumber() == Banknumber)
                { 
                    temp = i;
                }
            }
            if (temp > -1)
            {
                Accounts.Remove(Accounts[temp]);
            }
        }

        //setters

        public void setPhoneNumber(int phonenumber)
        { 
        this.Phonenumber= phonenumber;
        }

        public void setPincode(int pincode)
        { 
           this.Pincode= pincode;
        }

        public void setHasLoggedInOnce(bool hasloggedin)
        { 
            this.HasLoggedInOnce = hasloggedin;
        }

        public void setName(string name)
        { 
            this.Name= name;
        }

        public void AddTrans(Transaction trans)
        { 

            latestTransfers.Add(trans);
        
        }



        //getters
        public Account getAccountByIndex(int index)
        { 
            return Accounts[index];
        }

        public PersonalAccount GetPersonalAccount()
        {
            return personalAccount;
        }

        public int getNumberOfAccounts()
        {
            return Accounts.Count;
        }

        public bool getHasLoggedInOnce()
        {
            return this.HasLoggedInOnce;
        }
        public int getPhoneNumber()
        {
            return this.Phonenumber;
        }

        public int getSocialNumber()
        {
            return this.SocialNumber;
        }

        internal int getPincode()
        {
            return this.Pincode;
        }

        public float getTotalBalance()
        { 
            UpdateBalance();

            return this.Totalbalance;
        }

        public string getName()
        {
            return Name;
        }

    }
}
