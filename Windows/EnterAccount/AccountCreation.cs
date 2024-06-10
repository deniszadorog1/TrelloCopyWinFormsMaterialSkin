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
using System.Text.RegularExpressions;

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

            if (string.IsNullOrWhiteSpace(LoginBox.Text) ||
                string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                ClearBoxes();
                MessageBox.Show("login or email doesnt entered!", "Mistake!");
            }
            else if (!EmailValidation())
            {
                MessageBox.Show("smth wrong with email validation!", "Mistake!");
                return;
            }
            else if (!DBUsage.IfUserParamsExistInDB(LoginBox.Text, EmailBox.Text))
            {
                DBUsage.InserUser(new User(LoginBox.Text, EmailBox.Text, PasswordBox.Text));
                MessageBox.Show("Created!", "Success!");

                ClearBoxes();
                return;
            }
            else MessageBox.Show("login or email is Exist!", "Mistake!");
            ClearBoxes();
        }
        public bool EmailValidation()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(EmailBox.Text, pattern);
        }
        private void ClearBoxes()
        {
            EmailBox.Clear();
            LoginBox.Clear();
            PasswordBox.Clear();
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            Close();
        }
        private void ShowHidePass_Click(object sender, EventArgs e)
        {
            PasswordBox.Password = !PasswordBox.Password;

            ShowHidePass.Text = PasswordBox.Password ? "show password" : "hide password";
        }
    }
}
