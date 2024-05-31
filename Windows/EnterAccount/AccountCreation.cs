using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Models.DataBase;

namespace TrelloCopyWinForms.Windows.EnterAccount
{
    public partial class AccountCreation : MaterialForm
    {
        public AccountCreation()
        {
            InitializeComponent();
        }
        private void CreateBut_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text == "" || EmailBox.Text == "")
            {
                MessageBox.Show("You didnt enter the login!", "Mistake!");
            }
            else if (EmailBox.Text == "")
            {
                MessageBox.Show("Email doesnt enter!", "Mistake!");
            }
            else if (!DBUsage.IfUserParamsExistInDB(LoginBox.Text, EmailBox.Text))
            {
                DBUsage.InserUser(new User(LoginBox.Text, EmailBox.Text, PasswordBox.Text));
                MessageBox.Show("Created!", "Success!");
                return;
            }
            else MessageBox.Show("login or email is Exist!", "Mistake!");
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ShowHidePass_Click(object sender, EventArgs e)
        {
            PasswordBox.Password = !PasswordBox.Password;

            ShowHidePass.Text = PasswordBox.Password ? "show password" : "hide password";
        }
    }
}
