using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

using TrelloCopyWinForms.Windows.EnterAccount;
using TrelloCopyWinForms.Models.DataBase;
using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Windows.UserMainMenu;
using TrelloCopyWinForms.Models.TableModels;
using TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows;
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;

namespace TrelloCopyWinForms
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            InitFacePic();

            DBUsage.InitConnectionString();
        }
        private void InitFacePic()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string imageDirectory = baseDirectoryInfo.Parent.Parent.FullName;
            string imagePath = Path.Combine(imageDirectory, "Images");
            string facePath = Path.Combine(Path.Combine(imagePath, "LoginPage"), "LoginFace.png");
            FacePic.Image = Image.FromFile(facePath);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NewAccBut_Click(object sender, EventArgs e)
        {
            Hide();
            AccountCreation createAccount = new AccountCreation();
            createAccount.ShowDialog();
            Show();
                     
        }

        private void LoginBut_Click(object sender, EventArgs e)
        {
            //verfy login and hash for password
            if (LoginBox.Text == string.Empty || PasswordBox.Text == string.Empty)
            {
                MessageBox.Show("Smth went wrong!", "Mistake!");
                return;
            }

            User user = DBUsage.GetUserInAuthorization(LoginBox.Text, PasswordBox.Text);

            if(!(user is null))//we can enter in account
            {
                PasswordBox.Text = string.Empty;
                Hide();
                UserMenu menu = new UserMenu(user);
                menu.ShowDialog();
                Show();
                return;
            }
            MessageBox.Show("Smth went wrong!", "Mistake!");
        }
    }
}
