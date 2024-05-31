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
using TrelloCopyWinForms.Windows.TableWindows;

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
            FillTablesList();
        }
        private void FillTablesList()
        {
            AccessableTablesPanel.Controls.Clear();
            const int _deistanceBetweenTables = 5;
            Size accessTableSize = new Size(100, 100);
            Point tempPoint = new Point(0, _deistanceBetweenTables);
            for (int i = 0; i < _tables.Count; i++)
            {
                if (IfUserContrinsInTable(_tables[i]))
                {
                    Panel panel = new Panel();
                    panel.Tag = i;
                    panel.Size = accessTableSize;
                    panel.BackColor = _tables[i].BgColor is null ?
                        Color.Transparent : (Color)_tables[i].BgColor;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += ChooseTable_Click;

                    Label label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.Text = _tables[i].Name;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Click += ChooseTable_Click;
                    panel.Controls.Add(label);

                    tempPoint = new Point(AccessableTablesPanel.Width / 2 - panel.Width / 2, tempPoint.Y);
                    panel.Location = tempPoint;
                    AccessableTablesPanel.Controls.Add(panel);
                    tempPoint = new Point(tempPoint.X, tempPoint.Y + panel.Height + _deistanceBetweenTables);
                }
            }
        }
        private void ChooseTable_Click(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                Panel panel = (Panel)label.Parent;
                ReinitChosenTable(panel);
                return;
            }
            ReinitChosenTable((Panel)sender);
        }
        public void ReinitChosenTable(Panel panel)
        {
            ChosenTablePanel.Controls.Clear();

            ChosenTablePanel.BackColor = panel.BackColor;
            ChosenTablePanel.Tag = panel.Tag;
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is Label)
                {
                    Label label = new Label();
                    label.Text = ((Label)panel.Controls[i]).Text;
                    label.Dock = ((Label)panel.Controls[i]).Dock;
                    label.TextAlign = ((Label)panel.Controls[i]).TextAlign;

                    ChosenTablePanel.Controls.Add(label);
                }
            }
        }
        public void ClearChosenTablePanel()
        {
            ChosenTablePanel.Controls.Clear();
            ChosenTablePanel.Tag = null;
            ChosenTablePanel.BackColor = Color.Empty;
        }
        public bool IfUserContrinsInTable(Table table)
        {
            for (int i = 0; i < table.UserInTable.Count; i++)
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
            if (DBUsage.ComparePassHashes(_chosenUser.Login, OldPassCorBox.Text))
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
        private void CreateTableBut_Click(object sender, EventArgs e)
        {
            Hide();
            CreateTable create = new CreateTable(_chosenUser);
            create.ShowDialog();
            Show();

            ClearChosenTablePanel();
            _tables = DBUsage.GetAllTables();
            FillTablesList();
        }

        private void ChooseTableBut_Click(object sender, EventArgs e)
        {
            if(ChosenTablePanel.Controls.Count == 0)
            {
                MessageBox.Show("Need to chosoe table");
                return;
            }

            Table chosenTable = _tables[(int)ChosenTablePanel.Tag];

            Hide();
            TableWindow window = new TableWindow(chosenTable, _chosenUser);
            window.ShowDialog();
            Show();

            ClearChosenTablePanel();
            FillTablesList();
        }

        private void AddTableBut_Click(object sender, EventArgs e)
        {
            string tableTag = EnterTagBox.Text;

            if(tableTag == "")
            {
                MessageBox.Show("Mistake!");
                return;
            }

            Table table = DBUsage.AddTableByTag(tableTag);

            if(table is null)
            {
                MessageBox.Show("No table with such tag");
                return;
            }

            table.UserInTable.Add(_chosenUser);

            table.InitReintTableUsers(_tables);

            DBUsage.InsertUserTables(table, _chosenUser);


            _tables = DBUsage.GetAllTables();
            FillTablesList();
        }
        
    }
}
