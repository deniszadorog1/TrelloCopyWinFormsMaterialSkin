using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TrelloCopyWinForms.Models.Enums;
using TrelloCopyWinForms.Models.TableModels;
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;
using TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs;


namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows
{
    public partial class SubTaskMenu : MaterialForm
    {
        private SubTask _subTask;
        private Table _table;

        private Point _startNameLoc = new Point(10, 70);


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
        private const int _distanceBetweenMainBlocks = 10;
        private const int _distanceBetweenSubBlocks = 5;


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
            InsertPanelsInForm();
            InitZeroSizeForControls();

            InitPanelsSize();
            InitLocationForBlocks();
            InitControls();

            InitBordersForEveryPanel();

            InitMenuButtons();
        }

        private void InitControls()
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

            //Name Label
            Label nameLabel = new Label();
            nameLabel.Text = _subTask.Name;
            nameLabel.Font = new Font("Times New Roman", 16);
            nameLabel.AutoSize = true;

            _namePanel.Controls.Add(nameLabel);
            _namePanel.BorderStyle = BorderStyle.FixedSingle;


            //Flags trello
            InitFlags();

            //Init Date
            InitDeadLine();

            //Description
            InitDescroption();

            //Check lists
            InitCheckLists();

            //Init History
        }
        public void InitDescription()
        {
            _historyPanel.Controls.Clear();

            //Label of Name action
            //Button to show History of changing
            //text box for comment 
            //Label with text

        }
        public void InitDescroption()
        {
            _descriptionPanel.Location = new Point(_deadlinePanel.Location.X, _deadlinePanel.Location.Y + _deadlinePanel.Height + _distanceBetweenMainBlocks);
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
        }

        public void InitDeadLine()
        {
            const int borderDist = 5;
            Size boxSize = new Size(30, 30);
            _deadlinePanel.Controls.Clear();
            _deadlinePanel.BorderStyle = BorderStyle.FixedSingle;

            _deadlinePanel.Location = new Point(_flagPanel.Location.X, _flagPanel.Location.Y + _flagPanel.Height + _distanceBetweenMainBlocks);

            if (_subTask.DeadLine is null) return;
            //Init start - end + check

            MaterialCheckbox box = new MaterialCheckbox();
            box.AutoSize = false;
            box.Size = boxSize;
            box.Text = "";
            box.Location = new Point(borderDist, borderDist);

            Label printLB = new Label();
            printLB.BorderStyle = BorderStyle.FixedSingle;

            printLB.Text = _subTask.DeadLine.PrintString;
            printLB.Location = new Point(box.Location.X + box.Width + borderDist, box.Location.Y + borderDist);
            printLB.Size = new Size(_deadlinePanel.Width - box.Width - borderDist * 2, box.Height);


            _deadlinePanel.Size = new Size(_deadlinePanel.Width, box.Height + borderDist * 2);

            _deadlinePanel.Controls.Add(box);
            _deadlinePanel.Controls.Add(printLB);

            InitLocationForBlocks();

        }

        public void InitCheckLists()
        {
            const int distanceFromBorders = 5;
            const int checkBoxSizeParam = 30;
            const int deleteButtonWidth = 75;

            _checlListsPanel.Controls.Clear();
            _checlListsPanel.Size = new Size(_checlListsPanel.Width, 50);

            if (_subTask.CheckLists.Count <= 0) return;
            Label checkListsLB = new Label();
            checkListsLB.Text = "Check Lists";
            checkListsLB.Font = new Font("Times New Roman", 16);

            _checlListsPanel.Controls.Add(checkListsLB);

            Control lastControl = null;

            Point tempLoc = new Point(checkListsLB.Location.X, checkListsLB.Location.Y + checkListsLB.Height + _distanceBetweenSubBlocks);
            for (int i = 0; i < _subTask.CheckLists.Count; i++)
            {
                Panel panel = new Panel();
                panel.Name = _subTask.CheckLists[i].Name;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.AutoSize = false;
                panel.Size = new Size(_flagPanel.Width - distanceFromBorders * 2, 0);
                panel.Location = tempLoc;


                Label checkListName = new Label();
                checkListName.Location = new Point(distanceFromBorders, distanceFromBorders);
                checkListName.Text += _subTask.CheckLists[i].Name;
                checkListName.Font = new Font("Times new Roman", 14);
                panel.Controls.Add(checkListName);
                panel.Size = new Size(panel.Width, panel.Height + checkListName.Height + _distanceBetweenSubBlocks);

                MaterialButton deleteCheckList = new MaterialButton();
                deleteCheckList.Text = "Delete";
                deleteCheckList.AutoSize = false;
                deleteCheckList.Size = new Size(deleteButtonWidth, checkListName.Height);
                deleteCheckList.Location = new Point(panel.Width - deleteCheckList.Width - distanceFromBorders, checkListName.Location.Y);
                deleteCheckList.Click += DeleteCheckList_Click;
                panel.Controls.Add(deleteCheckList);
                panel.Size = new Size(panel.Width, panel.Height + deleteCheckList.Height + _distanceBetweenSubBlocks);


                MaterialProgressBar progressBar = new MaterialProgressBar();
                progressBar.Location = new Point(checkListName.Location.X, checkListName.Location.Y + checkListName.Height + distanceFromBorders);
                progressBar.Size = new Size(deleteCheckList.Location.X - checkListName.Location.X, 5);
                progressBar.Maximum = 100;

                panel.Controls.Add(progressBar);

                panel.Size = new Size(panel.Width, panel.Height + progressBar.Height + _distanceBetweenSubBlocks);


                Point caseLoc = new Point();
                for (int j = 0; j < _subTask.CheckLists[i].Cases.Count; j++)
                {
                    lastControl = panel.Controls[panel.Controls.Count - 1];

                    Panel listCase = new Panel();
                    listCase.BorderStyle = BorderStyle.FixedSingle;
                    listCase.Size = new Size(progressBar.Width, 0);
                    listCase.Location = new Point(lastControl.Location.X,
                        lastControl.Location.Y + lastControl.Height + _distanceBetweenSubBlocks);

                    MaterialCheckbox box = new MaterialCheckbox();
                    box.Text = "";
                    box.Size = new Size(checkBoxSizeParam, checkBoxSizeParam);
                    box.CheckedChanged += CaseIsDoneOrNotDone_CheckedChanged;

                    listCase.Controls.Add(box);

                    MaterialLabel lb = new MaterialLabel();
                    lb.BorderStyle = BorderStyle.FixedSingle;
                    lb.Text = _subTask.CheckLists[i].Cases[j].Name;
                    lb.AutoSize = false;
                    lb.Location = new Point(deleteCheckList.Location.Y + deleteCheckList.Width / 2, checkListName.Location.X);

                    listCase.Size = new Size(listCase.Width, lb.Height + box.Height);

                    listCase.Controls.Add(lb);
                    panel.Controls.Add(listCase);

                    panel.Size = new Size(panel.Width, panel.Height + listCase.Height + _distanceBetweenSubBlocks);

                }

                lastControl = panel.Controls[panel.Controls.Count - 1];

                //Add AddElement button
                MaterialButton addElement = new MaterialButton();
                addElement.Text = "Add Element";
                addElement.AutoSize = false;
                addElement.Size = new Size(panel.Width / 3, lastControl.Size.Height / 2);
                addElement.Location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + _distanceBetweenBlocks);
                addElement.Click += AddCase_Click;

                panel.Controls.Add(addElement);

                panel.Size = new Size(panel.Width, panel.Height + addElement.Height + _distanceBetweenSubBlocks);

                _checlListsPanel.Size = new Size(_checlListsPanel.Width, _checlListsPanel.Height + panel.Height + _distanceBetweenBlocks);
                tempLoc = new Point(tempLoc.X, tempLoc.Y + panel.Height + _distanceBetweenBlocks);

                _checlListsPanel.Controls.Add(panel);
            }
        }
        private void CaseIsDoneOrNotDone_CheckedChanged(object sender, EventArgs e)
        {
            Panel checkList = (Panel)((MaterialCheckbox)sender).Parent.Parent;
            Panel caseInCheckList = (Panel)((MaterialCheckbox)sender).Parent;

            //Get progress bar 
            MaterialProgressBar progressBar = GetProgressBarFromPanel(checkList);
            if (progressBar is null) throw new Exception("Couldnt get a prgress bar");


            Label checkListNameLB = GetLabelFromPanel(checkList);
            Label caseNameLB = GetLabelFromPanel(caseInCheckList);

            //Change case check Value in listCheck 
            _subTask.CheckCheckSignForCase(checkListNameLB.Text, caseNameLB.Text);

            int amountOfCases = _subTask.GetAmountOfCasesOfCheckBox(checkListNameLB.Text, caseNameLB.Text);
            int amountOfTurnedCheckCases = _subTask.GetAmountOfTurnedOnCasesOfCheckBox(checkListNameLB.Text, caseNameLB.Text);

            double percent = (double)amountOfTurnedCheckCases / amountOfCases * 100;

            progressBar.Value = (int)percent;

        }



        public MaterialProgressBar GetProgressBarFromPanel(Panel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is MaterialProgressBar)
                {
                    return (MaterialProgressBar)panel.Controls[i];
                }
            }
            return null;
        }
        private void AddCase_Click(object sender, EventArgs e)
        {
            //GetCheckListPanel 
            Panel checkListPanel = (Panel)((MaterialButton)sender).Parent;

            Label checkListName = GetLabelFromPanel(checkListPanel);
            if (checkListName is null) throw new Exception("Cant find checkList name");

            AddCase newCase = new AddCase(_subTask, _subTask.GetCheckListByName(checkListName.Text));
            newCase.ShowDialog();

            InitCheckLists();
        }
        public Label GetLabelFromPanel(Panel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is Label)
                {
                    return (Label)panel.Controls[i];
                }
            }
            return null;
        }

        private void DeleteCheckList_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                Control control = button.Parent; //CheckList Panel

                bool deleteRes = _subTask.DeleteCheckListByName(control.Name);
                if (!deleteRes)
                {
                    MessageBox.Show("Smth went wrong!", "Mistake!");
                    return;
                }
                InitCheckLists();
            }
        }

        public void InitFlags()
        {

            _flagPanel.Size = new Size(_flagPanel.Width, 0);
            _flagPanel.BorderStyle = BorderStyle.FixedSingle;
            _flagPanel.Location = new Point(10, _menuPanel.Location.Y);
            Size baseFlagSize = new Size(50, 40);
            Point loc = new Point(_distBetweenFlagsInPanel, _distBetweenFlagsInPanel);
            _flagPanel.Controls.Clear();

            if (_subTask.Flags.Count <= 0) return;

            _flagPanel.Size = new Size(_flagPanel.Width, baseFlagSize.Width + _distBetweenFlagsInPanel * 2);

            _flagPanel.AutoSize = false;
            bool transferCheck = false;
            for (int i = 0; i < _subTask.Flags.Count; i++)
            {
                transferCheck = false;

                Panel panel = new Panel();

                panel.BackColor = _subTask.Flags[i].FlagColor;
                panel.AutoSize = false;
                panel.Size = baseFlagSize;

                Label flagText = new Label();
                flagText.Text = _subTask.Flags[i].FlagTag;
                flagText.Dock = DockStyle.Fill;
                flagText.TextAlign = ContentAlignment.MiddleCenter;

                panel.Controls.Add(flagText);
                if (i > 1) (loc, transferCheck) = CheckIfNeedToTransferFlag(panel, loc);
                panel.Location = loc;

                UpdateFlagPanelHeight(transferCheck, baseFlagSize.Height);
                _flagPanel.Controls.Add(panel);

                if (i == 0) loc = new Point(loc.X + panel.Width + _distBetweenFlagsInPanel, loc.Y);
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

            InitLocationForBlocks();

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
            const int borderDistance = 5;
            Size butSize = new Size(_menuPanel.Width - distanceBetweenButtons * 2, 35);

            Point loc = new Point(_menuPanel.Width - butSize.Width - borderDistance, 0);

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
                    but.Click += AddDeadLine;
                }
                else if ((SubTaskButType)i == SubTaskButType.Attachment)
                {

                }
                else if ((SubTaskButType)i == SubTaskButType.Cover)
                {

                }
            }
        }
        private void AddDeadLine(object sender, EventArgs e)
        {
            AddDeadLine deadLine = new AddDeadLine();
            deadLine.ShowDialog();

            _subTask.DeadLine = deadLine._deadLine;

            InitDeadLine();
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

            InitCheckLists();

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


            Point tempLoc = _startNameLoc;
            for (int i = 0; i < (int)SubTaskTypes.ButMenu; i++)
            {
                Control control = GetPanelByType((SubTaskTypes)i);

                if (!(control.Tag is null) && control.Tag.ToString() == SubTaskTypes.Name.ToString())
                {
                    control.Location = tempLoc;
                    tempLoc = new Point(tempLoc.X, tempLoc.Y + control.Height + _distanceBetweenMainBlocks);
                }
                else if (control.Height != 0 || control.Controls.Count == 0)
                {
                    control.Location = tempLoc;
                    tempLoc = new Point(tempLoc.X, tempLoc.Y + control.Height + _distanceBetweenMainBlocks);
                }
            }
            _menuPanel.Location = new Point(this.Size.Width - _menuPanel.Width - _distanceBetweenBlocks, _namePanel.Location.Y + _namePanel.Height * 2);
        }
        private int IfSubTaskHasCheckLists()
        {
            return _subTask.CheckLists.Count == 0 ? 0 : _distanceBetweenMainBlocks;
        }
        private int IfSubTaskDoesntHaveFlags()
        {
            return _subTask.Flags.Count == 0 ? 0 : _distanceBetweenMainBlocks;
        }
        private int IfSubTaskContainsSmth(object smth)
        {
            return smth is null ? 0 : _distanceBetweenMainBlocks;
        }

        private void InitPanelsSize()
        {
            _namePanel.AutoSize = false;
            _namePanel.Size = new Size(_namePanelWidth, _onePointInNamePanelHeight * _subTask.GetTransfersAmount());

            _menuPanel.Size = new Size(200, 350);


            int rightPanelsWidth = this.Width - _menuPanel.Width - _distanceBetweenBlocks * 3;

            _flagPanel.Size = new Size(rightPanelsWidth, 0);
            _deadlinePanel.Size = new Size(rightPanelsWidth, 0);
            _descriptionPanel.Size = new Size(rightPanelsWidth, 150);
            _checlListsPanel.Size = new Size(rightPanelsWidth, 0);
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
        private void InitZeroSizeForControls()
        {
            for (int i = 0; i <= (int)SubTaskTypes.ButMenu; i++)
            {
                Control control = GetPanelByType((SubTaskTypes)i);

                if (!(control.Tag is null) && control is Panel panel)
                {
                    panel.AutoSize = false;
                    panel.Size = new Size(0, 0);
                }
            }
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
