using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

using TrelloCopyWinForms.Models.TableModels;
using TrelloCopyWinForms.Models.Enums;
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;
using System.IO;

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class CoverAction : MaterialForm
    {
        private SubTask _subTask;

        private string _bgImagesPath = "";
        private List<Image> _bgImages = new List<Image>();

        public CoverAction(SubTask subTask)
        {
            _subTask = subTask;
            InitializeComponent();
            InitDefaultParams();

            InitBGFilePath();
            InitBGImagesInList();
            FillImages();
        }
        public void InitDefaultParams()
        {
            FullSizeTypeRadio.Checked = false;
            PartSizeRadio.Checked = false;
            if (_subTask is null || _subTask.Cover is null) return;
            if(!(_subTask.Cover.BGColor is null))
            {
                BgPanel.BackColor = (Color)_subTask.Cover.BGColor;
            }
            if(!(_subTask.Cover.Type is null))
            {
                if(_subTask.Cover.Type == CoverType.FullSizeCover)
                {
                    FullSizeTypeRadio.Checked = true;
                }
                else
                {
                    PartSizeRadio.Checked = true;
                }
            }
        }
        private void BackBut_Click(object sender, EventArgs e)
        {
/*            _subTask.Cover.Type = (_subTask.Cover.BGImage is null && _subTask.Cover.BGColor is null) ? null : 
                FullSizeTypeRadio.Checked ? CoverType.FullSizeCover : CoverType.PartSizeCover;*/
            if(_subTask.Cover.BGImage is null && _subTask.Cover.BGColor is null)
            {
                _subTask.Cover.Type = null;
            }
            else if (FullSizeTypeRadio.Checked)
            {
                _subTask.Cover.Type = CoverType.FullSizeCover;
            }
            else 
            {
                _subTask.Cover.Type = CoverType.PartSizeCover;
            }

            Close();
        }

        private void AddColorBut_Click(object sender, EventArgs e)
        {
            ChooseColor.ShowDialog();

            if (ChooseColor.Color != Color.Empty)
            {
                BgPanel.BackColor = ChooseColor.Color;
                BgPanel.BackgroundImage = null;
            }

            _subTask.Cover = new Cover(ChooseColor.Color);
            _subTask.Cover.Type = FullSizeTypeRadio.Checked ? CoverType.FullSizeCover : CoverType.PartSizeCover;
        }
        private void ClearCoverBut_Click(object sender, EventArgs e)
        {
            BgPanel.BackColor = SystemColors.Control;
            BgPanel.BackgroundImage = null;
            _subTask.Cover = null;
            MessageBox.Show("Cleared!", "Success");
        }
        public void FillImages()
        {
            ImagesPanel.Controls.Clear();
            const int distBetweenImages = 5;
            Point loc = new Point(0, distBetweenImages);
            for(int i = 0; i < _bgImages.Count; i++)
            {
                PictureBox box = new PictureBox();
                box.Image = _bgImages[i];
                box.Location = loc;
                box.Size = new Size(ImagesPanel.Width - 20, 150);
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.Click += ChooseBGImage_Click;

                ImagesPanel.Controls.Add(box);

                loc = new Point(loc.X, loc.Y + box.Height + distBetweenImages);
            }
        }
        private void ChooseBGImage_Click(object sender, EventArgs e)
        {
            if(sender is PictureBox picBox)
            {
                BgPanel.BackColor = Color.Empty;
                BgPanel.BackgroundImage = picBox.Image;

                _subTask.Cover = new Cover(new CoverImageAttributes(BgPanel.BackgroundImage, BgPanel.BackgroundImage.Tag.ToString()));
            }
        }
        private void CoverAction_Load(object sender, EventArgs e)
        {

        }

        private void AddImageBut_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg; *.jpeg; *.png)|*.jpg; *.jpeg; *.png|All files (*.*)|*.*",
                Title = "Open an image file"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                if (!CheckForFileType(filePath))
                {
                    MessageBox.Show("Incorrect file Type!");
                    return;
                }
                ReplaceImage(filePath);

                InitBGImagesInList();
                FillImages();

                //RenameBGImages();
            }
        }

        private void RenameBGImages()
        {
            string[] fileNames = Directory.GetFiles(_bgImagesPath);

            foreach (string filePath in fileNames)
            {
                string fileExtension = Path.GetExtension(filePath);
                string fileName = Path.GetFileName(filePath);

                if (fileExtension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    fileExtension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    fileExtension.Equals(".png", StringComparison.OrdinalIgnoreCase))
                {

                    if (fileName.Length <= 32)
                    {
                        string newName = Guid.NewGuid().ToString() + fileExtension;
                        string newPath = Path.Combine(_bgImagesPath, newName);

                        // Перемещаем файл
                        File.Move(filePath, newPath);
                    }
                }
            }
        }
        public void ReplaceImage(string filePath)
        {      
            string fileName = GetFileName(filePath);

            string fileExtension = Path.GetExtension(filePath);
            string newName = Guid.NewGuid().ToString() + fileExtension;     
            string filePathNewImage = Path.Combine(_bgImagesPath, newName);

            File.Copy(filePath, filePathNewImage);
        }
        private bool CheckForFileType(string fileName)
        {
            return (fileName.Contains(".jpg") ||
                     fileName.Contains(".png") ||
                     fileName.Contains(".jpeg"));
        }
        public void InitBGFilePath()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string imageDirectory = baseDirectoryInfo.Parent.Parent.FullName;
            string imagePath = Path.Combine(imageDirectory, "Images");
            _bgImagesPath = Path.Combine(imagePath, "BackgroundTable");
        }
        private void InitBGImagesInList()
        {
            _bgImages.Clear();
            string[] fileNames = Directory.GetFiles(_bgImagesPath);

            foreach (string filePath in fileNames)
            {
                string fileName = GetFileName(filePath);
                string pathToPic = Path.Combine(_bgImagesPath, filePath);

                if (fileName.Contains(".jpg") ||
                     fileName.Contains(".png") ||
                     fileName.Contains(".jpeg"))
                {
                    _bgImages.Add(Image.FromFile(pathToPic));
                    _bgImages.Last().Tag = pathToPic;
                }
            }
        }
        private string GetFileName(string filePath)
        {
            string fileName = "";
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
        private void BackgroundPanel_Paint(object sender, PaintEventArgs e)
        {
            if (BgPanel.BackgroundImage != null)
            {
                e.Graphics.DrawImage(BgPanel.BackgroundImage, new Rectangle(0, 0, BgPanel.Width, BgPanel.Height));
            }
        }
    }
}
