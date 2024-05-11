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
    }
}
