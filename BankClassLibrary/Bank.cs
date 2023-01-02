using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class Banken
    {
        //fields

        int activeUser; 
        Dictionary<int,User> users = new Dictionary<int,User>(); // directory där varje user binds ihopp med ett personnummer
        public Banken() //constructor
        {
        }

        public void clearDictionary(int key) //en funktion som raderar en användare
        { 
            users.Remove(key);
        }
        public void clearWholeDictionary() //funktion för att rensa hela dictionarie
        { 
            users.Clear();
        }
        public void AddUser(int socialNumber, int pinCode, int phoneNumber) //en function för att lägga till ny användare
        {
            clearDictionary(socialNumber);
            users.Add(socialNumber, new User(phoneNumber, socialNumber, pinCode, this)); //vi lägger till en ny användare i dictionary och binder den med socialnumber
        }
        public void RemoveUser(int socialNumber) // funktion för att ta bort användare
        { 
            users.Remove(socialNumber);
        }
        public bool CheckUserInformation(int SocialNumber, int Pincode) //vi kollar om checkuser information matchar med det som kommer in
        {
            if (users.ContainsKey(SocialNumber)) //finns den?
            {
                if(users[SocialNumber].getPincode() == Pincode)//stämmer koden?
                {

                    return true;
                }
               
            } else return false;
        }

        public string GetNameOfAccountOwner(int accountNumber) //använder accountnumber för att anropa getName på tillhörande user
        {
            if (users.ContainsKey(accountNumber))
            {
                return users[accountNumber].getName();
            }
            else return "";
        }

        public void SubmitTransfer(Transaction trans) //vi tar hand om transfer
        {
            users[(int)trans.getRecievingTransactionNumber()].GetPersonalAccount().AddBalance(trans.getAmount()); //adera saldo
            users[(int)trans.getRecievingTransactionNumber()].AddTrans(trans);
            users[(int)trans.getTransmittingTransactionNumber()].GetPersonalAccount().subtractBalance(trans.getAmount()); //subtrahera saldo
            users[(int)trans.getTransmittingTransactionNumber()].AddTrans(trans);

        }

        //getters 
        public int getActiveUserKey()
        {
            return activeUser;
        }

        public User getUser(int userKey)
        {
                return users[userKey];
        }

        public Dictionary<int, User> getUsers()
        {
            return users;
        }
        
        //setters
        public void setActiveUser(int socialNumber)
        { 
            this.activeUser = socialNumber;
        }
    }
}
