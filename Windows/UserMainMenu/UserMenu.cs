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
using MaterialSkin.Controls;

using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Models.DataBase;
using TrelloCopyWinForms.Windows.CreateTableWindow;
using TrelloCopyWinForms.Models.TableModels;

namespace TrelloCopyWinForms.Windows.UserMainMenu
{
    public partial class UserMenu : MaterialForm
    {
        private User _chosenUser = null;
        private List<Table> _tables = DBUsage.GetAllTables();
        public UserMenu(User user)
        {
            _chosenUser = user;
            InitializeComponent();

            InitBaseParams();
        }
        private void InitBaseParams()
        {
            FillUserInfoPage();
            InitEyeImage();
            FillCorrectionBoxes();
        }
        private void FillTablesList()
        {
            Size accessTableSize = new Size(100, 100);
            for(int i = 0; i < _tables.Count; i++)
            {
                if (IfUserContrinsInTable(_tables[i]))
                {
                    Panel panel = new Panel();
                    panel.Size = accessTableSize;
                    //etc

                }
            }
        }
        public bool IfUserContrinsInTable(Table table)
        {
            for(int i = 0; i < table.UserInTable.Count; i++)
            {
                if (table.UserInTable[i].Id == _chosenUser.Id) return true;
            }
            return false;
        }

        private void FillUserInfoPage()
        {
            LoginInfo.Text = _chosenUser.Login;
            EmailInfo.Text = _chosenUser.Email;
        }
        private void InitEyeImage()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string imageDirectory = baseDirectoryInfo.Parent.Parent.FullName;
            string imagePath = Path.Combine(imageDirectory, "Images");
            string facePath = Path.Combine(Path.Combine(imagePath, "CorrectAccount"), "Eye.png");
            NewPassEyeImg.Image = Image.FromFile(facePath);
            OldPassEyeImg.Image = Image.FromFile(facePath);
        }
        private void FillCorrectionBoxes()
        {
            LoginCorBox.Text = _chosenUser.Login;
            EmailCorBox.Text = _chosenUser.Email;
        }
        private void CorrectBut_Click(object sender, EventArgs e)
        {
            if (LoginCorBox.Text == "" || EmailCorBox.Text == "" ||
                OldPassCorBox.Text == "" || NewPasCorBox.Text == "")
            {
                MessageBox.Show("Somthing went wrong!", "Mistake!");
                return;
            }
            
            //Compare old password
            if(DBUsage.ComparePassHashes(_chosenUser.Login, OldPassCorBox.Text))
            {
                //Assign param
                string oldUserLogin = _chosenUser.Login;
                _chosenUser.Login = LoginCorBox.Text;
                _chosenUser.Email = _chosenUser.Email;
                _chosenUser.Password = NewPasCorBox.Text;
                //Init correction in db
                DBUsage.UpdateUser(oldUserLogin, _chosenUser);

                LoginInfo.Text = _chosenUser.Login;
                EmailInfo.Text = _chosenUser.Email;

                MessageBox.Show("Changed!", "Success!");
                return;
            }
            MessageBox.Show("Somthing went wrong!", "Mistake!");
        }

        private void NewPasEyeImg_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox picBox)
            {
                if (picBox.Name == "NewPassEyeImg")
                {
                    NewPasCorBox.Password = !NewPasCorBox.Password;
                }
                else if (picBox.Name == "OldPassEyeImg")
                {
                    OldPassCorBox.Password = !OldPassCorBox.Password;
                }
            }
        }

        private void CreateTableTab_Click(object sender, EventArgs e)
        {

        }

        private void CreateTableBut_Click(object sender, EventArgs e)
        {

            Hide();
            CreateTable create = new CreateTable();
            create.ShowDialog();
            Show();

        }
    }
}
