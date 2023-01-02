using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class PersonalAccount : Account
    {
        //fields
        Card card = new Card(123);

        public PersonalAccount(float SocialNumber, Banken bank):base(bank) //derived constructor från Account
        {
            setBankNumber((int)SocialNumber);
            Random random = new Random();
            float nmr = random.Next(1000000, 9999999);
            card = new Card(nmr);
        }

        //getters
        public Card getCard()
        { 
            return card;
        }
    }
}
