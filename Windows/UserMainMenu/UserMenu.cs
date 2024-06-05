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
using TrelloCopyWinForms.Models.Enums;
using TrelloCopyWinForms.Windows.TableWindows.Codes;
using System.Text.RegularExpressions;

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

                    Label label = new Label();
                    label.Dock = DockStyle.Fill;
                    label.Text = _tables[i].Name;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.Click += ChooseTable_Click;
                    label.DoubleClick += EnterTable_DoubleClick;
                    label.ForeColor = GetColorForTableName(panel.BackColor);

                    panel.Controls.Add(label);

                    tempPoint = new Point(AccessableTablesPanel.Width / 2 - panel.Width / 2, tempPoint.Y);
                    panel.Location = tempPoint;
                    AccessableTablesPanel.Controls.Add(panel);
                    tempPoint = new Point(tempPoint.X, tempPoint.Y + panel.Height + _deistanceBetweenTables);
                }
            }
        }
        public Color GetColorForTableName(Color bgColor)
        {
            const double lumCorrection = 0.05;
            double bgLuminance = GetLuminance(bgColor);
            Color black = Color.Black;
            Color white = Color.White;
            double blackLuminance = GetLuminance(black);
            double whiteLuminance = GetLuminance(white);
            double blackContrast = (Math.Max(bgLuminance, blackLuminance) + lumCorrection) /
                (Math.Min(bgLuminance, blackLuminance) + lumCorrection);
            double whiteContrast = (Math.Max(bgLuminance, whiteLuminance) + lumCorrection) /
                (Math.Min(bgLuminance, whiteLuminance) + lumCorrection);

            return (blackContrast > whiteContrast) ? black : white;
        }
        public double GetLuminance(Color color)
        {
            const double maxColorValue = 255.0;

            const double rReturnParamMultipilier = 0.2126;
            const double gReturnParamMultipilier = 0.7152;
            const double bReturnParamMultipilier = 0.0722;

            const double comparationParam = 0.03928;
            const double trueParamDevider = 12.92;
            const double additionInPow = 0.055;
            const double deviderInPow = 1.055;
            const double power = 2.4;

            double r = color.R / maxColorValue;
            double g = color.G / maxColorValue;
            double b = color.B / maxColorValue;

            r = (r <= comparationParam) ? r / trueParamDevider :
                Math.Pow((r + additionInPow) / deviderInPow, power);
            g = (g <= comparationParam) ? g / trueParamDevider :
                Math.Pow((g + additionInPow) / deviderInPow, power);
            b = (b <= comparationParam) ? b / trueParamDevider :
                Math.Pow((b + additionInPow) / deviderInPow, power);

            return rReturnParamMultipilier * r + gReturnParamMultipilier * g + bReturnParamMultipilier * b;
        }
        private List<Table> GetTablesWhichUserCanUse()
        {
            List<Table> res = new List<Table>();
            for (int i = 0; i < _tables.Count; i++)
            {
                if (IfUserContrinsInTable(_tables[i]))
                {
                    res.Add(_tables[i]);
                }
            }
            return res;
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
        private void EnterTable_DoubleClick(object sender, EventArgs e)
        {
            Table chosenTable = _tables[(int)ChosenTablePanel.Tag];

            Hide();
            TableWindow window = new TableWindow(chosenTable, _chosenUser, GetTablesWhichUserCanUse());
            window.ShowDialog();
            Show();

            _tables = GetTablesWhichUserCanUse();
            ClearChosenTablePanel();
            FillTablesList();
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

            //Compare old password
            if (LoginCorBox.Text != string.Empty && EmailCorBox.Text != string.Empty &&
                OldPassCorBox.Text != string.Empty && NewPasCorBox.Text != string.Empty &&

                DBUsage.ComparePassHashes(_chosenUser.Login, OldPassCorBox.Text) && 
                EmailValidation())
            {
                //Assign param
                string oldUserLogin = _chosenUser.Login;
                _chosenUser.Login = LoginCorBox.Text;
                _chosenUser.Email = EmailCorBox.Text;
                _chosenUser.Password = NewPasCorBox.Text;
                //Init correction in db
                DBUsage.UpdateUser(oldUserLogin, _chosenUser);

                FillUserInfoPage();

                MessageBox.Show("Changed!", "Success!");
                return;
            }
            else if(LoginCorBox.Text != string.Empty && EmailCorBox.Text != string.Empty &&
                !DBUsage.IfUserParamsExistInDB(LoginCorBox.Text, EmailCorBox.Text) &&
                EmailValidation())
            {
                string oldUserLogin = _chosenUser.Login;

                _chosenUser.Login = LoginCorBox.Text;
                _chosenUser.Email = EmailCorBox.Text;

                DBUsage.UpdateUser(oldUserLogin, _chosenUser);

                FillUserInfoPage();

                MessageBox.Show("Changed!", "Success!");
                return;
            }
            else if(LoginCorBox.Text != string.Empty && !DBUsage.IfUserLoginParamExistInDB(LoginCorBox.Text) &&  
                _chosenUser.Email == EmailCorBox.Text)
            {
                string oldUserLogin = _chosenUser.Login;
                _chosenUser.Login = LoginCorBox.Text;

                DBUsage.UpdateUser(oldUserLogin, _chosenUser);

                FillUserInfoPage();

                MessageBox.Show("Changed!", "Success!");
                return;
            }
            else if(_chosenUser.Login == LoginCorBox.Text && _chosenUser.Email == EmailCorBox.Text &&
                DBUsage.ComparePassHashes(_chosenUser.Login, OldPassCorBox.Text))
            {
                string oldUserLogin = _chosenUser.Login;
                _chosenUser.Password = NewPasCorBox.Text;
                DBUsage.UpdateUser(oldUserLogin, _chosenUser);

                FillUserInfoPage();

                MessageBox.Show("Changed!", "Success!");
            }

            MessageBox.Show("Somthing went wrong!", "Mistake!");
        }
        public bool EmailValidation()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(EmailCorBox.Text);
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
            if (ChosenTablePanel.Controls.Count == 0)
            {
                MessageBox.Show("Need to chosoe table");
                return;
            }
            Table chosenTable = _tables[(int)ChosenTablePanel.Tag];

            Hide();
            TableWindow window = new TableWindow(chosenTable, _chosenUser, GetTablesWhichUserCanUse());
            window.ShowDialog();
            Show();

            _tables = GetTablesWhichUserCanUse();
            ClearChosenTablePanel();
            FillTablesList();
        }
        private void AddTableBut_Click(object sender, EventArgs e)
        {
            EnterCode code = new EnterCode(_chosenUser);
            code.ShowDialog();

            if (!(code._table is null))
            {
                _tables = DBUsage.GetAllTables();

                _tables = GetTablesWhichUserCanUse();
                FillTablesList();
            }
        }

    }
}
