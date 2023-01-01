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
        Dictionary<int,User> users = new Dictionary<int,User>();
        public Banken()
        {
        }

        public void clearDictionary(int key)
        { 
            users.Remove(key);
        }
        public void clearWholeDictionary()
        { 
            users.Clear();
        }
        public void AddUser(int socialNumber, int pinCode, int phoneNumber)
        {
            clearDictionary(socialNumber);
            users.Add(socialNumber, new User(phoneNumber, socialNumber, pinCode, this));
        }
        public void RemoveUser(int socialNumber)
        { 
            users.Remove(socialNumber);
        }
        public bool CheckUserInformation(int SocialNumber, int Pincode)
        {
            if (users.ContainsKey(SocialNumber) && users[SocialNumber].getPincode() == Pincode)
            {
                    return true;
               
            } else return false;
        }

        public string GetNameOfAccountOwner(int accountNumber)
        {
            if (users.ContainsKey(accountNumber))
            {
                return users[accountNumber].getName();
            }
            else return "";
        }

        public void SubmitTransfer(Transaction trans)
        {
            users[(int)trans.getRecievingTransactionNumber()].GetPersonalAccount().AddBalance(trans.getAmount());
            users[(int)trans.getRecievingTransactionNumber()].AddTrans(trans);
            users[(int)trans.getTransmittingTransactionNumber()].GetPersonalAccount().subtractBalance(trans.getAmount());
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
