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
            Close();
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
