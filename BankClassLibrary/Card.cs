using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClassLibrary
{
    public class Card 
    {
        //fields

        float cardNumber;

        public Card(float cardNumber) // constructor för kortet
        { 
            this.cardNumber = cardNumber;
        }

        //getter

        public float getCardNumber()
        { 
            return cardNumber;
        }
    }
}
