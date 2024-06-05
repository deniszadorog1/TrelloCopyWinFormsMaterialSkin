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

using TrelloCopyWinForms.Models.TableModels;
using TrelloCopyWinForms.Models.DataBase;
using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Models.Enums;

namespace TrelloCopyWinForms.Windows.CreateTableWindow
{
    public partial class CreateTable : MaterialForm
    {
        private List<Image> _images = new List<Image>();
        private string _pathToBackGroundImages = string.Empty;

        private User _user;
        public CreateTable(User chosenUser)
        {
            _user = chosenUser;
            InitializeComponent();

            RenameBGImages();
            InitBGImagesInList();

        }
        private void RenameBGImages()
        {
            const int maxImageNameLength = 32;
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string imageDirectory = baseDirectoryInfo.Parent.Parent.FullName;
            string imagePath = Path.Combine(imageDirectory, "Images");
            _pathToBackGroundImages = Path.Combine(imagePath, "BackgroundTable");

            string[] fileNames = Directory.GetFiles(_pathToBackGroundImages);

            foreach (string filePath in fileNames)
            {
                string pathToPic = Path.Combine(_pathToBackGroundImages, filePath);
                string fileExtension = GetFileExtension(pathToPic);
                string fileName = GetFileName(filePath);

                if (fileName.Contains(".jpg") ||
                     fileName.Contains(".png") ||
                     fileName.Contains(".jpeg"))
                {
                    if (fileName.Length <= maxImageNameLength)
                    {
                        string newName = Guid.NewGuid().ToString();
                        newName += fileExtension;

                        string newPath = Path.Combine(_pathToBackGroundImages, newName);

                        File.Move(pathToPic, newPath);
                    }
                }
            }
        }
        private void InitBGImagesInList()
        {
            string[] fileNames = Directory.GetFiles(_pathToBackGroundImages);

            foreach (string filePath in fileNames)
            {
                string fileName = GetFileName(filePath);
                string pathToPic = Path.Combine(_pathToBackGroundImages, filePath);

                if (fileName.Contains(".jpg") ||
                     fileName.Contains(".png") ||
                     fileName.Contains(".jpeg"))
                {
                    _images.Add(Image.FromFile(pathToPic));
                    _images.Last().Tag = fileName;
                }
            }
        }
        private string GetFileExtension(string filePath)
        {
            const char devider = '.';
            string res = string.Empty;
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                if (filePath[i] == devider)
                {
                    res += filePath[i];
                    res = new string(res.Reverse().ToArray());

                    return res;
                }
                res += filePath[i];
            }
            return res;
        }
        private string GetFileName(string filePath)
        {
            string fileName = string.Empty;
            char cros = '\\';
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                if (filePath[i] == cros)
                {
                    fileName = new string(fileName.Reverse().ToArray());
                    return fileName;
                }
                fileName += filePath[i];
            }
            return fileName;
        }
        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void CreateBut_Click(object sender, EventArgs e)
        {
            if (TableNameBox.Text == string.Empty || ChosenBG.BackColor == Color.Empty)
            {
                MessageBox.Show("Smth went wrong");
                return;
            }

            Table newTable = new Table(new List<TableTask>(), TableNameBox.Text, ChosenBG.BackColor);

            DBUsage.InsertColor(ChosenBG.BackColor.R, ChosenBG.BackColor.G, ChosenBG.BackColor.B);
            DBUsage.InsertTable(newTable);
            newTable.Id = DBUsage.GetTableLastId();

            newTable.UserInTable.Add(_user);
            DBUsage.InsertUserTables(newTable, _user, AccountType.Admin);

            newTable.Id = DBUsage.GetTableLastId();
            Close();
        }
        private void ChooseBGBut_Click(object sender, EventArgs e)
        {
            tableBgColor.ShowDialog();

            if (tableBgColor.Color != Color.Empty)
            {
                ChosenBG.BackColor = tableBgColor.Color;
            }
        }
    }
}
