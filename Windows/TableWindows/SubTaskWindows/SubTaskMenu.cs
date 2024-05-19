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
using TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs;
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;


namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows
{
    public partial class SubTaskMenu : MaterialForm
    {
        private SubTask _subTask;
        private List<Flag> _allFlags;


        private Point _nameLBLoc = new Point(10, 70);
        private Panel _namePanel = new Panel();

        private Point flagsLoc = new Point();
        private Panel _flagPanel = new Panel();

        private Point _descriptionLoc = new Point();
        private Panel _descriptionPanel = new Panel();

        private Point _addsLoc = new Point();
        private Panel _addsPanel = new Panel();

        private Point _checkListsLoc = new Point();
        private Panel _checlListsPanel = new Panel();

        private Point _historyLoc = new Point();
        private Panel _historyPanel = new Panel();

        private Point _menuLoc = new Point();
        private Panel _menuPanel = new Panel();


        private const int _namePanelWidth = 500;
        private const int _onePointInNamePanelHeight = 40;

        private const int _distanceBetweenBlocks = 10;

        List<string> _menuList = new List<string>()
        {
            "Partisipants",
            "Tags",
            "Check-List",
            "Date",
            "Attachment",
            "Cover"
        };
        public SubTaskMenu(SubTask subTask, List<Flag> allFlags)
        {
            //_subTaskBox = subTaskBox;
            _subTask = subTask;
            _allFlags = allFlags;

            InitializeComponent();

            InitBaseParams();
        }
        private void InitBaseParams()
        {
            InitPanelsSize();
            InitLocationForBlocks();
            InitControls();

            InitBordersForEveryPanel();
            InsertPanelsInForm();

            InitMenuButtons();
        }

        private void InitControls()
        {
            //Name Label
            Label nameLabel = new Label();
            nameLabel.Text = _subTask.Name;
            nameLabel.Font = new Font("Times New Roman", 16);
            nameLabel.AutoSize = true;

            _namePanel.Controls.Add(nameLabel);
            _namePanel.BorderStyle = BorderStyle.FixedSingle;
            //Flags


            //Description
            Label descLB = new Label();
            descLB.Text = "Description";
            descLB.Font = new Font("Times New Roman", 16);
            descLB.AutoSize = true;
            descLB.Location = new Point(5, 0);

            MaterialMultiLineTextBox2 descTextPanel = new MaterialMultiLineTextBox2();
            //descTextPanel.ScrollBars = ScrollBars.Vertical;
            descTextPanel.MaxLength = 1000;
            descTextPanel.Location = new Point(descLB.Location.X, descLB.Location.Y + descLB.Height + _distanceBetweenBlocks);
            descTextPanel.Size = new Size(_descriptionPanel.Width - _distanceBetweenBlocks, _descriptionPanel.Height - descLB.Height - _distanceBetweenBlocks * 2);

            descTextPanel.Text = "";

            descTextPanel.TextChanged += (sender, e) =>
            {
                const int oneLineHeight = 45;
                int height = AdjustTextBoxHeight((TextBox)sender);
                if (height < oneLineHeight) return;

                _descriptionPanel.Height = _descriptionPanel.Height - descTextPanel.Height + height;

                descTextPanel.Height = height;
                descTextPanel.Invalidate();
                _descriptionPanel.Invalidate();
            };

            _descriptionPanel.Controls.Add(descLB);
            _descriptionPanel.Controls.Add(descTextPanel);

            //Adds trello

            //Check lists

            //History

        }

        private int AdjustTextBoxHeight(TextBox textBox)
        {
            // Создаем графический объект для измерения высоты текста
            using (Graphics g = textBox.CreateGraphics())
            {
                // Определяем размер текста
                SizeF textSize = g.MeasureString(textBox.Text, textBox.Font, textBox.Width);

                // Устанавливаем высоту текстового поля в соответствии с высотой текста
                return (int)Math.Ceiling(textSize.Height) + textBox.Margin.Vertical + SystemInformation.HorizontalScrollBarHeight;
            }
        }

        private void InitMenuButtons()
        {
            const int distanceBetweenButtons = 10;
            Size butSize = new Size(_menuPanel.Width - distanceBetweenButtons * 2, 35);

            Point loc = new Point(_menuPanel.Width - butSize.Width, 0);

            for (int i = 0; i < _menuList.Count; i++)
            {
                MaterialButton but = new MaterialButton();

                but.Tag = (SubTaskButType)i;
                but.Name = _menuList[i];
                but.Text = _menuList[i];
                but.AutoSize = false;
                but.Size = butSize;
                but.Location = loc;


                _menuPanel.Controls.Add(but);

                loc = new Point(loc.X, loc.Y + but.Height + distanceBetweenButtons);
            }

            InitClicks();

        }

        private void InitClicks()
        {
            for(int i = 0; i <= (int)SubTaskButType.Cover; i++)
            {
                Control but = GetButtonFromMenuList((SubTaskButType)i);

                if((SubTaskButType)i == SubTaskButType.Partisipants)
                {

                }
                else if((SubTaskButType)i == SubTaskButType.Tags)
                {
                    but.Click += AddTag_Click;
                }
                else if ((SubTaskButType)i == SubTaskButType.CheckList)
                {

                }
                else if ((SubTaskButType)i == SubTaskButType.Date)
                {

                }
                else if ((SubTaskButType)i == SubTaskButType.Attachment)
                {

                }
                else if ((SubTaskButType)i == SubTaskButType.Cover)
                {

                }
            }
        }
        private void AddTag_Click(object sender, EventArgs e)
        {
            AddSubTaskFlag addFlag = new AddSubTaskFlag(_allFlags, _subTask);
            addFlag.ShowDialog();
        }
        private Control GetButtonFromMenuList(SubTaskButType type)
        {
            for (int i = 0; i < _menuPanel.Controls.Count; i++)
            {
                if (_menuPanel.Controls[i] is Button &&
                    _menuPanel.Controls[i].Tag.GetType() == typeof(SubTaskButType) &&
                    (SubTaskButType)_menuPanel.Controls[i].Tag == type)
                {
                    return _menuPanel.Controls[i];
                }
            }
            return null;
        }

        private void InitLocationForBlocks()
        {
            _namePanel.Location = _nameLBLoc;

            _menuPanel.Location = new Point(this.Size.Width - _menuPanel.Width - _distanceBetweenBlocks, _namePanel.Location.Y + _namePanel.Height * 2);

            _descriptionPanel.Location = new Point(_nameLBLoc.X, 200);
        }
        private void InitPanelsSize()
        {
            _namePanel.AutoSize = false;
            _namePanel.Size = new Size(_namePanelWidth, _onePointInNamePanelHeight * _subTask.GetTransfersAmount());

            _menuPanel.Size = new Size(200, 350);

            _descriptionPanel.Size = new Size(this.Width - _menuPanel.Width - _distanceBetweenBlocks * 3, 150);
        }
        private void InsertPanelsInForm()
        {
            Controls.Add(_namePanel);
            Controls.Add(_menuPanel);
            Controls.Add(_flagPanel);
            Controls.Add(_descriptionPanel);
            Controls.Add(_addsPanel);
            Controls.Add(_checlListsPanel);
            Controls.Add(_historyPanel);
        }

        private void InitBordersForEveryPanel()
        {
            _namePanel.BorderStyle = BorderStyle.FixedSingle;
            _menuPanel.BorderStyle = BorderStyle.FixedSingle;
            _flagPanel.BorderStyle = BorderStyle.FixedSingle;
            _descriptionPanel.BorderStyle = BorderStyle.FixedSingle;
            _addsPanel.BorderStyle = BorderStyle.FixedSingle;
            _checlListsPanel.BorderStyle = BorderStyle.FixedSingle;
            _historyPanel.BorderStyle = BorderStyle.FixedSingle;
        }

    }
}
