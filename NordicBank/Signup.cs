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
    public partial class Signup : Form
    {

        BankClassLibrary.Banken myBank = new BankClassLibrary.Banken();
        public Signup(BankClassLibrary.Banken bank)
        {
            InitializeComponent();
            myBank = bank;
        }

        private void Link_Label_Click(object sender, EventArgs e)
        {
          this.Hide();
            Login login = new Login(myBank);
            login.Show();
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void Register_btn_Click(object sender, EventArgs e)
        {
            int tempSocialNumber = int.Parse(textBox2.Text);
            int tempPincode = int.Parse(textBox2.Text);

            if (!myBank.CheckUserInformation(tempSocialNumber, tempPincode))
            {
                myBank.AddUser(tempSocialNumber, tempPincode, 123456789);
                myBank.setActiveUser(tempSocialNumber);
                Login login = new Login(myBank);
                this.Hide();
                login.Show();
            }
        }
    }
}
