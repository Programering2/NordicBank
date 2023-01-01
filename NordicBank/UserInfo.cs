using BankClassLibrary;
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
    public partial class UserInfo : Form
    {
        //fields
        Banken myBank = new Banken();
        public UserInfo(Banken myBank)
        {
            this.myBank = myBank;
            InitializeComponent();
        }

        private void UserInfo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myBank.getUser(myBank.getActiveUserKey()).setName(this.t_name.Text);
            myBank.getUser(myBank.getActiveUserKey()).setPhoneNumber(int.Parse(this.t_phone.Text));
            myBank.getUser(myBank.getActiveUserKey()).setHasLoggedInOnce(true);
            FileHandler.UpdateUser(FileHandler.FileName, myBank);
            Close();
        }
    }
}
