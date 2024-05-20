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

        //Panel queue
        //Cover optional
        //Name 
        //Paricipants
        //Flags
        //Date
        //Description
        //additionals
        //Check Lists
        //History || comments


        private SubTask _subTask;
        private Table _table;

        private Point _startNameLoc = new Point(10, 70);

        private Panel _coverPanel = new Panel();
        private Panel _namePanel = new Panel();
        private Panel _partisipentsPanel = new Panel();
        private Panel _flagPanel = new Panel();
        private Panel _deadlinePanel = new Panel();
        private Panel _descriptionPanel = new Panel();
        private Panel _aditionsPanel = new Panel();
        private Panel _checlListsPanel = new Panel();
        private Panel _historyPanel = new Panel();

        private Panel _menuPanel = new Panel();


        private const int _namePanelWidth = 500;
        private const int _onePointInNamePanelHeight = 40;

        private const int _distanceBetweenBlocks = 10;

        private const int _distBetweenFlagsInPanel = 5;
        private const int _distanceBetweenMainBlocks = 5;


        List<string> _menuList = new List<string>()
        {
            "Partisipants",
            "Tags",
            "Check-List",
            "Date",
            "Attachment",
            "Cover"
        };
        public SubTaskMenu(SubTask subTask, Table table)
        {
            //_subTaskBox = subTaskBox;
            _subTask = subTask;
            _table = table;

            InitializeComponent();

            InitBaseParams();
        }
        private void InitBaseParams()
        {
            InitTagsForPanl();
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

            //Flags trello
            InitFlags();

            //Check lists
            InitCheckLists();

            //History
        }

        public void InitCheckLists()
        {
            const int distanceFromBorders = 5;
            const int checkBoxSizeParam = 20;

            _checlListsPanel.Controls.Clear();
            _checlListsPanel.Size = new Size(_checlListsPanel.Width, 50);

            if (_subTask.CheckLists.Count <= 0) return;
            Label checkListsLB = new Label();
            checkListsLB.Text = "Check Lists";
            checkListsLB.Font = new Font("Times New Roman", 16);

            _checlListsPanel.Controls.Add(checkListsLB);

            for (int i = 0; i < _subTask.CheckLists.Count; i++)
            {
                Panel panel = new Panel();

                Label checkListName = new Label();
                checkListName.Location = new Point(distanceFromBorders, distanceFromBorders);
                checkListName.Text += _subTask.CheckLists[i].Name;

                MaterialButton deleteCheckList = new MaterialButton();
                deleteCheckList.Text = "Delete";
                deleteCheckList.Location = new Point(panel.Width - deleteCheckList.Width - distanceFromBorders, checkListName.Location.Y);

                MaterialProgressBar progressBar = new MaterialProgressBar();
                progressBar.Location = new Point(checkListName.Location.X, checkListName.Location.Y + checkListName.Height + distanceFromBorders);
                progressBar.Size = new Size(deleteCheckList.Location.X - checkListName.Location.X, 5);

                for(int j = 0; j < _subTask.CheckLists[i].Cases.Count; j++)
                {
                    Panel ListCase = new Panel();

                    MaterialCheckbox box = new MaterialCheckbox();
                    box.Text = "";
                    box.Size = new Size(checkBoxSizeParam, checkBoxSizeParam);
                }

            }


        }

        public void InitFlags()
        {
            _flagPanel.Size = new Size(_flagPanel.Width, 50);
            _flagPanel.BorderStyle = BorderStyle.FixedSingle;
            _flagPanel.Location = new Point(10, 150);

            Size baseFlagSize = new Size(50, 40);
            Point loc = new Point(_distBetweenFlagsInPanel, _distBetweenFlagsInPanel);
            if (_subTask.Flags.Count <= 0) return;
            _flagPanel.Controls.Clear();
            _flagPanel.AutoSize = false;
            bool transferCheck = false;
            for (int i = 0; i < _subTask.Flags.Count; i++)
            {
                transferCheck = false;

                Panel label = new Panel();
                label.Text = _subTask.Flags[i].FlagTag;
                label.BackColor = _subTask.Flags[i].FlagColor;
                label.AutoSize = false;
                label.Size = baseFlagSize;

                if (i > 1) (loc, transferCheck) = CheckIfNeedToTransferFlag(label, loc);

                label.Location = loc;

                UpdateFlagPanelHeight(transferCheck, baseFlagSize.Height);


                _flagPanel.Controls.Add(label);

                if (i == 0) loc = new Point(loc.X + label.Width + _distBetweenFlagsInPanel, loc.Y);
            }

            //Control lastControl = _flagPanel.Controls[_flagPanel.Controls.Count - 1];
            MaterialButton addBut = new MaterialButton();
            addBut.Text = "+";
            addBut.BackColor = SystemColors.Control;
            addBut.AutoSize = false;
            addBut.Size = baseFlagSize;
            (addBut.Location, transferCheck) = CheckIfNeedToTransferFlag(addBut, loc);
            UpdateFlagPanelHeight(transferCheck, baseFlagSize.Height);
            _flagPanel.Controls.Add(addBut);

        }
        public void UpdateFlagPanelHeight(bool ifNeedToTransfer, int statndatFlagPanelHeight)
        {
            if (ifNeedToTransfer)
            {
                _flagPanel.Size = new Size(_flagPanel.Width, _flagPanel.Height + statndatFlagPanelHeight + _distBetweenFlagsInPanel);
                //_descriptionPanel.Location = new Point(_descriptionPanel.Location.X, _descriptionPanel.Location.Y + statndatFlagPanelHeight);
                _flagPanel.BorderStyle = BorderStyle.FixedSingle;

                MakeOneOfThePanelHeightBigger(_flagPanel, statndatFlagPanelHeight + _distanceBetweenBlocks);
            }
        }
        private (Point, bool) CheckIfNeedToTransferFlag(Control newControl, Point tempPoint)
        {
            if (newControl is Button && _flagPanel.Controls.Count <= 1) return (tempPoint, false);

            Control lastControl = _flagPanel.Controls[_flagPanel.Controls.Count - 1];

            //Compare new x point
            if (tempPoint.X + lastControl.Width + newControl.Width + _distBetweenFlagsInPanel > _flagPanel.Width)
            {
                return (new Point(_distBetweenFlagsInPanel,
                    lastControl.Location.Y + newControl.Height + _distBetweenFlagsInPanel), true);
            }
            return (new Point(tempPoint.X + lastControl.Width + _distBetweenFlagsInPanel, tempPoint.Y), false);
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
            for (int i = 0; i <= (int)SubTaskButType.Cover; i++)
            {
                Control but = GetButtonFromMenuList((SubTaskButType)i);

                if ((SubTaskButType)i == SubTaskButType.Partisipants)
                {

                }
                else if ((SubTaskButType)i == SubTaskButType.Tags)
                {
                    but.Click += AddTag_Click;
                }
                else if ((SubTaskButType)i == SubTaskButType.CheckList)
                {
                    but.Click += AddCheckList_Click;
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
            AddSubTaskFlag addFlag = new AddSubTaskFlag(_table.GetAllFlags(), _subTask);
            addFlag.ShowDialog();

            InitFlags();
        }
        private void AddCheckList_Click(object sender, EventArgs e)
        {
            _subTask.CheckLists.Add(new CheckListModel("First check List"));
            _subTask.CheckLists.Last().Cases.Add(new CheckListCase("first"));
            _subTask.CheckLists.Last().Cases.Add(new CheckListCase("second"));

            _subTask.CheckLists.Add(new CheckListModel("Second check List"));
            _subTask.CheckLists.Last().Cases.Add(new CheckListCase("third"));
            _subTask.CheckLists.Last().Cases.Add(new CheckListCase("fourth "));

            CheckListAction addCheckList = new CheckListAction(_table, _subTask);
            addCheckList.ShowDialog();
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

        private void MakeOneOfThePanelHeightBigger(Panel panel, int heightMove)
        {
            SubTaskTypes? panelType = GetTypeByPanel(panel);

            if (panelType is null) throw new Exception("Main panel type tag is null. " +
                "Maybe you gave in method not main panel");

            for (int i = (int)panelType + 1; i < (int)SubTaskTypes.ButMenu; i++)
            {
                Control control = GetPanelByType((SubTaskTypes)i);
                if (control is null) throw new Exception("Counl not find panel with type. It cant be");

                control.Location = new Point(control.Location.X, control.Location.Y + heightMove);


                control.Invalidate();
            }
        }
        private Control GetPanelByType(SubTaskTypes type)
        {
            for (int i = 0; i < Controls.Count; i++)
            {
                if (Controls[i].Tag.ToString() == type.ToString())
                {
                    return Controls[i];
                }
            }
            return null;
        }
        public SubTaskTypes? GetTypeByPanel(Panel panel)
        {
            for (int i = 0; i <= (int)SubTaskTypes.ButMenu; i++)
            {
                if (panel.Tag.ToString() == ((SubTaskTypes)i).ToString())
                {
                    return (SubTaskTypes)i;
                }
            }

            return null;
        }


        private void InitLocationForBlocks()
        {
            _namePanel.Location = _startNameLoc;

            _menuPanel.Location = new Point(this.Size.Width - _menuPanel.Width - _distanceBetweenBlocks, _namePanel.Location.Y + _namePanel.Height * 2);

            _descriptionPanel.Location = new Point(_namePanel.Location.X, 200 + _distanceBetweenMainBlocks);

            _checlListsPanel.Location = new Point(_namePanel.Location.X, _descriptionPanel.Location.Y + _descriptionPanel.Height + _distanceBetweenMainBlocks);
        }
        private void InitPanelsSize()
        {
            _namePanel.AutoSize = false;
            _namePanel.Size = new Size(_namePanelWidth, _onePointInNamePanelHeight * _subTask.GetTransfersAmount());

            _menuPanel.Size = new Size(200, 350);
            //FLAGS - only width, height depends from included flags
            _flagPanel.Size = new Size(this.Width - _menuPanel.Width - _distanceBetweenBlocks * 3, 0);


            _descriptionPanel.Size = new Size(this.Width - _menuPanel.Width - _distanceBetweenBlocks * 3, 150);

            _checlListsPanel.Size = new Size(this.Width - _menuPanel.Width - _distanceBetweenBlocks * 3, 0);
        }
        private void InsertPanelsInForm()
        {
            Controls.Add(_coverPanel);
            Controls.Add(_namePanel);
            Controls.Add(_partisipentsPanel);
            Controls.Add(_flagPanel);
            Controls.Add(_deadlinePanel);
            Controls.Add(_descriptionPanel);
            Controls.Add(_aditionsPanel);
            Controls.Add(_checlListsPanel);
            Controls.Add(_historyPanel);

            Controls.Add(_menuPanel);
        }

        private void InitTagsForPanl()
        {
            _coverPanel.Tag = SubTaskTypes.Cover;
            _namePanel.Tag = SubTaskTypes.Name;
            _partisipentsPanel.Tag = SubTaskTypes.Partisipents;
            _flagPanel.Tag = SubTaskTypes.Flags;
            _deadlinePanel.Tag = SubTaskTypes.DeadLine;
            _descriptionPanel.Tag = SubTaskTypes.Description;
            _aditionsPanel.Tag = SubTaskTypes.Adition;
            _checlListsPanel.Tag = SubTaskTypes.CheckLists;
            _historyPanel.Tag = SubTaskTypes.HistoryComments;
            _menuPanel.Tag = SubTaskTypes.ButMenu;
        }

        private void InitBordersForEveryPanel()
        {
            _namePanel.BorderStyle = BorderStyle.FixedSingle;
            _menuPanel.BorderStyle = BorderStyle.FixedSingle;
            _flagPanel.BorderStyle = BorderStyle.FixedSingle;
            _descriptionPanel.BorderStyle = BorderStyle.FixedSingle;
            _aditionsPanel.BorderStyle = BorderStyle.FixedSingle;
            _checlListsPanel.BorderStyle = BorderStyle.FixedSingle;
            _historyPanel.BorderStyle = BorderStyle.FixedSingle;
        }

    }
}
