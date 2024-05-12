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


namespace TrelloCopyWinForms.Windows.CreateTableWindow
{
    public partial class CreateTable : MaterialForm
    {
        List<Image> _images = new List<Image>();

        private (int, int) _backGroundPicSize = (215, 125);
        private const int _distanceBetweenPossiableBGs = 5;
        public CreateTable()
        {
            InitializeComponent();

            InitBackGroundImages();
            FillImageIn();
        }

        private void FillImageIn()
        {
            int width = BackgroundTypes.Width / 2 - _backGroundPicSize.Item1 / 2;
            int height = 0;
            (int, int) location = (width, height);
            for (int i = 0; i < _images.Count; i++)
            {
                AddPictureBox(_images[i], location);
                location.Item2 += _backGroundPicSize.Item2 + _distanceBetweenPossiableBGs;
            }
        }
        private void AddPictureBox(Image img, (int,int) location)
        {
            PictureBox pic = new PictureBox();
            pic.Size = new Size(_backGroundPicSize.Item1, _backGroundPicSize.Item2);
            pic.Location = new Point(location.Item1, location.Item2);
            pic.Image = img;
            pic.SizeMode = PictureBoxSizeMode.StretchImage;

            pic.Click += ChosePic_Click;

            BackgroundTypes.Controls.Add(pic);
        }

        private void ChosePic_Click(object sender, EventArgs e)
        {
            if(sender is PictureBox pic)
            {
                if(pic.Image is null)
                {

                }
                else
                {
                    ChosenBG.Image = pic.Image;
                }
            }
        }


        private void InitBackGroundImages()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string imageDirectory = baseDirectoryInfo.Parent.Parent.FullName;
            string imagePath = Path.Combine(imageDirectory, "Images");
            string backGroundPath = Path.Combine(imagePath, "BackgroundTable");

            string[] fileNames = Directory.GetFiles(backGroundPath);

            foreach (string filePath in fileNames)
            {
                string pathToPic = Path.Combine(backGroundPath, filePath);
                string fileExtension = GetFileExtension(pathToPic);
                string fileName = GetFileName(filePath);

                if (fileName.Contains(".jpg") ||
                     fileName.Contains(".png") ||
                     fileName.Contains(".jpeg"))
                {
                    _images.Add(Image.FromFile(pathToPic));
                    _images.Last().Tag = fileName;

                    if (fileName.Length <= 32)
                    {
                        string newName = Guid.NewGuid().ToString();
                        newName += fileExtension;

                        File.Move(pathToPic, Path.Combine(backGroundPath, newName));
                    }
                }
            }
        }

        private string GetFileExtension(string filePath)
        {
            string res = "";
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                if (filePath[i] == '.')
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
            string fileName = "";
            char cros = '\\';
            for(int i = filePath.Length - 1; i >= 0; i--)
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
    }
}
