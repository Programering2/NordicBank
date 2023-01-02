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
    public partial class Login : Form
    {

        //fields
        BankClassLibrary.Banken myBank = new BankClassLibrary.Banken();

        public Login(BankClassLibrary.Banken bank)
        {
            InitializeComponent();
            myBank = bank;  

        }

        private void label5_Click(object sender, EventArgs e) //link label clicked
        {
            this.Hide();
            Signup signup = new Signup(myBank);
            signup.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //när login klickas på
        {
           int tempSocialNumber = int.Parse(this.textBox2.Text);
            int tempPincode = 0;
            if (this.textBox1.Text.Length > 0)
            {
                tempPincode = int.Parse(this.textBox1.Text);
            }

            if (myBank.CheckUserInformation(tempSocialNumber, tempPincode)) //om textbox informationerna matchar 
            {
                myBank.setActiveUser(tempSocialNumber); //vi ger banken nyckeln till den aktiva användaren
                DashBoard dashBoard = new DashBoard(myBank);
                this.Hide();
                dashBoard.Show();
            }



        }


        //getters

    }
}
