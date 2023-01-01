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
    public partial class DashBoard : Form
    {
        BankClassLibrary.Banken myBank = new BankClassLibrary.Banken();
        private bool isCollapsed;
        public DashBoard(BankClassLibrary.Banken myBank)
        {
            InitializeComponent();
            this.myBank = myBank;
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {
            timer1.Start();
            UpdateDisplay();
            if (!myBank.getUser(myBank.getActiveUserKey()).getHasLoggedInOnce())
            {
                UserInfo uif = new UserInfo(myBank);
                uif.ShowDialog();
                UpdateDisplay();
            }
            else
            {


                BankClassLibrary.FileHandler.UpdateUser(BankClassLibrary.FileHandler.FileName, myBank);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                caret.Image = NordicBank.Properties.Resources.caretUpTrans;
                BetalningDropMenu.Height += 10;
                l_översikt.Visible = false;
                if (BetalningDropMenu.Size == BetalningDropMenu.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                l_översikt.Visible = true;
                caret.Image = NordicBank.Properties.Resources.caretDownTrans;
                BetalningDropMenu.Height -= 10;
                if (BetalningDropMenu.Size == BetalningDropMenu.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }


        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Start();
        }

        private void UpdateDisplay()
        {
            this.P_amount.Text = myBank.getUser(myBank.getActiveUserKey()).GetPersonalAccount().getBalance().ToString() + "Kr";
            this.P_kontoNummer.Text = myBank.getUser(myBank.getActiveUserKey()).GetPersonalAccount().getBankNumber().ToString();
            this.CardName.Text = myBank.getUser(myBank.getActiveUserKey()).GetPersonalAccount().getCard().getCardNumber().ToString();
            this.CardSaldo.Text = myBank.getUser(myBank.getActiveUserKey()).GetPersonalAccount().getBalance().ToString() + "Kr";
            this.name.Text = myBank.getUser(myBank.getActiveUserKey()).getName();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


        private void label22_Click(object sender, EventArgs e) //leaving
        {
            Login login = new Login(myBank);
            Hide();
            login.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            timer1.Start();
            Transfer tForm = new Transfer(myBank);
            tForm.ShowDialog();
            UpdateDisplay();
        }
    }
}
