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
        private TableTask _task;
        private Point _startNameLoc = new Point(5, 5);


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
        private Panel _attachmentsPanel = new Panel();
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
        public SubTaskMenu(SubTask subTask, Table table, TableTask tempTask)
        {
            _subTask = subTask;
            _table = table;
            _task = tempTask;

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

      

            //Cover 
            InitCover();

            //Name
            InitName();

            //Init Particioants
            InitParticipants();

            //Flags
            InitFlags();

            //Init Date
            InitDeadLine();

            //Description
            InitDescription();

            //InitAttachment
            InitAttachments();

            //Check lists
            InitCheckLists();

            //Init History
            InitHistoryComments();
        }
        public void InitName()
        {
            _namePanel.Controls.Clear();
            Label nameLabel = new Label();
            nameLabel.Text = _subTask.Name;
            nameLabel.Font = new Font("Times New Roman", 16);
            nameLabel.AutoSize = false;

            nameLabel.MaximumSize = new Size(_namePanel.Width, 0);
            nameLabel.BorderStyle = BorderStyle.FixedSingle;
            nameLabel.Size = new Size(_namePanel.Width, 40);

            nameLabel.AutoEllipsis = true;
            nameLabel.AutoSize = true;

            nameLabel.Click += ChangeName_Click;
            _namePanel.Controls.Add(nameLabel);
            _namePanel.BorderStyle = BorderStyle.FixedSingle;
            _namePanel.Click += ChangeName_Click;

            if (_namePanel.Height < nameLabel.Height)
            {
                _namePanel.Height = nameLabel.Height + _distanceBetweenBlocks;
            }
            InitLocationForBlocks();
        }
        private void ChangeName_Click(object sender, EventArgs e)
        {
            ChangeName changeName = new ChangeName(_subTask);
            changeName.ShowDialog();

            InitName();
        }
        public void InitParticipants()
        {
            _partisipentsPanel.Controls.Clear();
            _partisipentsPanel.Size = new Size(_partisipentsPanel.Width, 75);

            MaterialLabel panelNameLB = new MaterialLabel();
            panelNameLB.Text = "Particepants";
            panelNameLB.Location = new Point(_distanceBetweenSubBlocks, _distanceBetweenSubBlocks);
            _partisipentsPanel.Controls.Add(panelNameLB);

            _partisipentsPanel.BorderStyle = BorderStyle.FixedSingle;
            Point point = new Point(_distanceBetweenSubBlocks, panelNameLB.Location.Y + panelNameLB.Height + _distanceBetweenSubBlocks);
            for (int i = 0; i < _subTask.UsersIdsInSuBTask.Count; i++)
            {
                string userLogin = _table.GetUserLoginById(_subTask.UsersIdsInSuBTask[i]);
                char firstLetter = userLogin[0]; 

                PictureBox box = new PictureBox();
                box.BorderStyle = BorderStyle.FixedSingle;
                box.Size = new Size(30, 30);
                box.Tag = firstLetter; 
                box.Paint += userCircles_Paint;

                box.Location = point;

                _partisipentsPanel.Controls.Add(box);

                point = new Point(point.X + box.Width + _distanceBetweenBlocks, point.Y);
            }

            InitLocationForBlocks();
        }

        private void userCircles_Paint(object sender, PaintEventArgs e)
        {
            PictureBox box = sender as PictureBox;
            if (box == null) return;

            // Получаем объект Graphics
            Graphics g = e.Graphics;

            // Настройки круга
            int circleDiameter = 25;
            int circleX = (box.Width - circleDiameter) / 2;
            int circleY = (box.Height - circleDiameter) / 2;

            // Рисуем круг
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, circleX, circleY, circleDiameter, circleDiameter);
            }

            // Настройки текста
            string symbol = box.Tag.ToString(); 
            Font font = new Font("Arial", 12, FontStyle.Bold);
            SizeF textSize = g.MeasureString(symbol, font);

            float textX = circleX + (circleDiameter - textSize.Width) / 2;
            float textY = circleY + (circleDiameter - textSize.Height) / 2;

            // Рисуем текст
            using (Brush brush = new SolidBrush(Color.Black))
            {
                g.DrawString(symbol, font, brush, textX, textY);
            }
        }


        public void InitCover()
        {
            const int coverHeight = 90;
            if (_subTask.Cover is null || _subTask.Cover.BGColor is null)
            {
                _coverPanel.Size = new Size(_coverPanel.Width, 0);
                _coverPanel.BackColor = Color.Empty;
                _coverPanel.BackgroundImage = null;
                InitLocationForBlocks();
                return;
            }
            _coverPanel.Size = new Size(_coverPanel.Width, coverHeight);
            _coverPanel.BackColor = (Color)_subTask.Cover.BGColor;

            InitLocationForBlocks();
            _coverPanel.Location = new Point(0, 0);
        }
        public void InitAttachments()
        {
            _attachmentsPanel.Controls.Clear();
            _attachmentsPanel.Size = new Size(_attachmentsPanel.Width, 500);

            //Init main panel name
            Label mainPanelName = new Label();
            mainPanelName.BorderStyle = BorderStyle.FixedSingle;
            mainPanelName.Font = new Font("Timaes new Roman", 16);
            mainPanelName.Text = "Attachments";
            mainPanelName.Location = new Point(_distanceBetweenSubBlocks, _distanceBetweenSubBlocks);
            mainPanelName.AutoSize = false;
            mainPanelName.Size = new Size(150, 30);
            _attachmentsPanel.Controls.Add(mainPanelName);

            int attachmentWidth = _attachmentsPanel.Width / 2 - _distanceBetweenSubBlocks;
            Point attatchLoc = new Point(mainPanelName.Location.X, mainPanelName.Location.Y + mainPanelName.Height + _distanceBetweenSubBlocks);
            for (int i = 0; i < _subTask.Attachments.Count; i++)
            {
                Panel attachmnetPanel = new Panel();
                attachmnetPanel.Tag = _subTask.Attachments[i].UniqueIndex;
                attachmnetPanel.AutoSize = false;
                attachmnetPanel.BorderStyle = BorderStyle.FixedSingle;
                attachmnetPanel.Location = attatchLoc;

                Panel attachmentLinkPanel = new Panel();
                attachmentLinkPanel.BorderStyle = BorderStyle.FixedSingle;
                attachmentLinkPanel.Location = new Point(0, 0);
                attachmentLinkPanel.Size = new Size(attachmentWidth, 10);

                attachmentLinkPanel.BackgroundImage = _table.BGImage;
                attachmentLinkPanel.BackgroundImageLayout = ImageLayout.Stretch;

                Label subTaskLB = new Label();
                subTaskLB.Name = "SubTaskName";
                subTaskLB.Text = _table.GetSubTaskNameByGlobalindex(_subTask.Attachments[i].SubTaskGlobalIndex);
                subTaskLB.AutoSize = false;
                subTaskLB.MaximumSize = new Size(attachmentWidth - _distanceBetweenSubBlocks * 2, 0);
                subTaskLB.Size = new Size(attachmentWidth - _distanceBetweenSubBlocks * 2, 0);
                subTaskLB.BorderStyle = BorderStyle.FixedSingle;

                subTaskLB.Size = new Size(attachmentWidth - _distanceBetweenSubBlocks * 2, subTaskLB.Height);
                subTaskLB.Location = new Point(0, 0);

                subTaskLB.AutoEllipsis = true;
                subTaskLB.AutoSize = true;
                attachmentLinkPanel.Controls.Add(subTaskLB);

                Label taskLB = new Label();
                taskLB.Name = "TaskName";
                taskLB.Text = _table.GetTaskNameWitchContainsSubTaskByGlobalIndex(_subTask.Attachments[i].SubTaskGlobalIndex);
                taskLB.Location = new Point(subTaskLB.Location.X, subTaskLB.Location.Y + subTaskLB.Height + _distanceBetweenSubBlocks);
                attachmentLinkPanel.Controls.Add(taskLB);

                attachmentLinkPanel.Size = new Size(attachmentLinkPanel.Width, subTaskLB.Height + taskLB.Height);
                attachmnetPanel.Controls.Add(attachmentLinkPanel);

                MaterialButton deleteBut = new MaterialButton();
                deleteBut.Tag = _subTask.Attachments[i].SubTaskGlobalIndex;
                deleteBut.Text = "Delete";
                deleteBut.Location = new Point(attachmentLinkPanel.Location.X + _distanceBetweenSubBlocks, attachmentLinkPanel.Location.Y + attachmentLinkPanel.Height + _distanceBetweenSubBlocks);

                deleteBut.Click += DeleteAttachment_Click;


                attachmnetPanel.Controls.Add(deleteBut);
                attachmnetPanel.Size = new Size(attachmnetPanel.Width, attachmentLinkPanel.Height + deleteBut.Height + _distanceBetweenSubBlocks * 2);

                _attachmentsPanel.Controls.Add(attachmnetPanel);

                if (i % 2 != 0)
                {
                    Control getXloc = _attachmentsPanel.Controls[_attachmentsPanel.Controls.Count - 2];
                    Control getYloc = _attachmentsPanel.Controls[_attachmentsPanel.Controls.Count - 1];

                    int yLoc = getYloc.Height > getXloc.Height ? getYloc.Height : getXloc.Height;

                    attatchLoc = new Point(getXloc.Location.X, getYloc.Location.Y + yLoc + _distanceBetweenBlocks);
                }
                else
                {
                    attatchLoc = new Point(attachmnetPanel.Location.X + attachmnetPanel.Width + _distanceBetweenBlocks, attachmnetPanel.Location.Y);
                }
            }
        }
        private void DeleteAttachment_Click(object sender, EventArgs e)
        {
            Panel attachPanel = (Panel)((MaterialButton)sender).Parent;
            Panel panel = GetPanelControlFormPanel(attachPanel);

            Control taskNameLB = GetLabelFromPanelByName(panel, "TaskName");
            Control subTaskNameLB = GetLabelFromPanelByName(panel, "SubTaskName");
            int attachIndex = int.Parse(attachPanel.Tag.ToString());
            int subTaskIndex = int.Parse(((MaterialButton)sender).Tag.ToString());

            _subTask.DeleteAttachmentGyUniqueIndex(attachIndex);

            InitAttachments();
        }
        public Panel GetPanelControlFormPanel(Panel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is Panel)
                {
                    return (Panel)panel.Controls[i];
                }
            }
            throw new Exception("cant find panel Control!");
        }
        public void InitHistoryComments()
        {
            _historyPanel.Size = new Size(_historyPanel.Width, 700);
            _historyPanel.Location = new Point();
            _historyPanel.BorderStyle = BorderStyle.FixedSingle;

            const int _distBetweenBlocks = 5;
            Size commentButSize = new Size(100, 40);
            _historyPanel.Controls.Clear();


            Panel historyHeader = new Panel();
            historyHeader.BorderStyle = BorderStyle.FixedSingle;
            historyHeader.Location = new Point(_distBetweenBlocks, _distBetweenBlocks);
            historyHeader.AutoSize = false;
            historyHeader.Size = new Size(_historyPanel.Width - _distBetweenBlocks * 2, 0);

            //Label of Name action
            MaterialLabel nameLB = new MaterialLabel();
            nameLB.Text = "History action";
            nameLB.Location = new Point(_distBetweenBlocks, _distBetweenBlocks);
            historyHeader.Controls.Add(nameLB);

            //Button to show History of changing
            MaterialButton showHistBut = new MaterialButton();
            showHistBut.AutoSize = false;
            showHistBut.Size = new Size(150, 25);
            showHistBut.Text = "Show history";

            showHistBut.Location = new Point(_historyPanel.Width - showHistBut.Width - _distBetweenBlocks, nameLB.Location.Y);
            historyHeader.Controls.Add(showHistBut);

            MaterialTextBox2 commentBox = new MaterialTextBox2();
            commentBox.Size = new Size(showHistBut.Location.X + showHistBut.Width - _distBetweenBlocks, showHistBut.Height);
            commentBox.Location = new Point(nameLB.Location.X, nameLB.Location.Y + nameLB.Height + _distBetweenBlocks);
            commentBox.MaxLength = 250;
            historyHeader.Controls.Add(commentBox);

            MaterialButton addComment = new MaterialButton();
            addComment.Text = "Add comment";
            addComment.Location = new Point(nameLB.Location.X, commentBox.Location.Y + commentBox.Height + _distBetweenBlocks);
            addComment.Click += AddComment_Click;
            historyHeader.Controls.Add(addComment);

            historyHeader.Height += nameLB.Height + commentBox.Height + addComment.Height + _distBetweenBlocks * 3;
            _historyPanel.Controls.Add(historyHeader);

            Point tempLoc = new Point(historyHeader.Location.X, historyHeader.Location.Y + historyHeader.Height + _distBetweenBlocks);
            for (int i = 0; i < _subTask.Comments.Count; i++)
            {
                Panel commentPanel = new Panel();
                commentPanel.Tag = _subTask.Comments[i].UniqueIndex;
                commentPanel.Size = new Size(historyHeader.Width, commentPanel.Height);
                commentPanel.BorderStyle = BorderStyle.FixedSingle;

                MaterialLabel writer = new MaterialLabel();
                writer.BorderStyle = BorderStyle.FixedSingle;
                writer.Size = new Size(commentPanel.Width, writer.Height);
                writer.Text = "there will be userLogin";
                writer.Location = new Point(0, 0);
                commentPanel.Controls.Add(writer);

                Label comment = new Label();
                comment.Name = "CommentValue";
                comment.Font = new Font("Times new Roman", 14);
                comment.Text = _subTask.Comments[i].Value;
                comment.AutoSize = false;
                comment.MaximumSize = new Size(commentPanel.Width, 0);
                comment.Width = commentPanel.Width;
                comment.Height = 0;

                comment.BorderStyle = BorderStyle.FixedSingle;
                //comment.Size = new Size(commentPanel.Width, comment.Height);
                comment.Location = new Point(writer.Location.X, writer.Location.Y + writer.Height + _distBetweenBlocks);

                comment.AutoSize = true;
                commentPanel.Controls.Add(comment);

                MaterialButton changeComment = new MaterialButton();
                changeComment.AutoSize = false;
                changeComment.Size = commentButSize;
                changeComment.Text = "change comment";
                changeComment.Location = new Point(writer.Location.X, comment.Location.Y + comment.Height + _distBetweenBlocks);
                changeComment.Click += ChangeComment_Click;
                commentPanel.Controls.Add(changeComment);

                MaterialButton deleteBut = new MaterialButton();
                deleteBut.AutoSize = false;
                deleteBut.Size = commentButSize;
                deleteBut.Text = "delete comment";
                deleteBut.Location = new Point(changeComment.Location.X + changeComment.Width + _distBetweenBlocks, changeComment.Location.Y);
                deleteBut.Click += DeleteComment_Click;
                commentPanel.Controls.Add(deleteBut);

                commentPanel.Location = tempLoc;
                commentPanel.Size = new Size(historyHeader.Width, writer.Height + comment.Height + changeComment.Height + _distBetweenBlocks * 3);
                tempLoc = new Point(tempLoc.X, tempLoc.Y + commentPanel.Height + _distBetweenBlocks);

                _historyPanel.Controls.Add(commentPanel);
            }
            for (int i = 0; i < _subTask.History.Count; i++)
            {
                Panel historyPanel = new Panel();
                historyPanel.BorderStyle = BorderStyle.FixedSingle;

                Label writer = new Label();
                writer.BorderStyle = BorderStyle.FixedSingle;
                writer.Text = "there will be userLogin";
                writer.Location = new Point(0, 0);
                historyPanel.Controls.Add(writer);

                Label comment = new Label();
                comment.Text = _subTask.Comments[i].Value;
                comment.Location = new Point(writer.Location.X, writer.Location.Y + writer.Height + _distBetweenBlocks);
                historyPanel.Controls.Add(writer);

                historyPanel.Location = tempLoc;
                tempLoc = new Point(tempLoc.X, tempLoc.Y + historyPanel.Height + _distBetweenBlocks);
                _historyPanel.Controls.Add(historyPanel);
            }

            MainPanel.VerticalScroll.Value = 0;

            InitLocationForBlocks();
        }
        private void ChangeComment_Click(object sender, EventArgs e)
        {
            Panel commentPanel = (Panel)((MaterialButton)sender).Parent;
            int commentIndex = int.Parse(commentPanel.Tag.ToString());
            Control label = GetLabelFromPanelByName(commentPanel, "CommentValue");

            CorrectComment correct = new CorrectComment(_subTask.GetComment(label.Text, commentIndex));
            correct.ShowDialog();

            _subTask.UpdateComment(correct._comment.Value, commentIndex);

            InitHistoryComments();
        }
        private void DeleteComment_Click(object sender, EventArgs e)
        {
            Panel commentPanel = (Panel)((MaterialButton)sender).Parent;
            int commentIndex = int.Parse(commentPanel.Tag.ToString());

            //only Label in that panel is commentvalue label
            Control label = GetLabelFromPanelByName(commentPanel, "CommentValue");

            _subTask.DeleteComment(label.Text, commentIndex);
            InitHistoryComments();
        }
        private Control GetLabelFromPanelByName(Panel panel, string name)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i].Name == name)
                {
                    return panel.Controls[i];
                }
            }
            throw new Exception("Cant find control with such name");
        }
        private void AddComment_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)((MaterialButton)sender).Parent;
            MaterialTextBox2 textBox = GetTextBoxFromPaenl(panel);

            _subTask.AddComment(textBox.Text);

            InitHistoryComments();
        }
        private MaterialTextBox2 GetTextBoxFromPaenl(Panel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is MaterialTextBox2)
                {
                    return (MaterialTextBox2)panel.Controls[i];
                }
            }
            throw new Exception("Couldnt find a materialText box!");
        }
        public void InitDescription()
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
                InitLocationForBlocks();
            };

            _descriptionPanel.Controls.Add(descLB);
            _descriptionPanel.Controls.Add(descTextPanel);
            InitLocationForBlocks();
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
                    listCase.Controls.Add(lb);

                    MaterialButton deleteCaseBut = new MaterialButton();
                    deleteCaseBut.AutoSize = false;
                    deleteCaseBut.Size = new Size(100, 30);
                    deleteCaseBut.Text = "Delete case";
                    deleteCaseBut.Location = new Point(listCase.Width - deleteCaseBut.Width -
                        _distanceBetweenSubBlocks, listCase.Height / 2);
                    deleteCaseBut.Click += DeleteCase_Click;
                    listCase.Controls.Add(deleteCaseBut);

                    listCase.Size = new Size(listCase.Width, lb.Height + box.Height);
                    panel.Controls.Add(listCase);

                    panel.Size = new Size(panel.Width, panel.Height + listCase.Height + _distanceBetweenSubBlocks);
                }

                lastControl = panel.Controls[panel.Controls.Count - 1];
                //Add AddElement button
                MaterialButton addElement = new MaterialButton();
                addElement.Text = "Add Element";
                addElement.AutoSize = false;
                addElement.Size = new Size(panel.Width / 3, (int)(GetMaterialButtonFromPanel(panel).Height * 1.5));
                addElement.Location = new Point(lastControl.Location.X, lastControl.Location.Y + lastControl.Height + _distanceBetweenBlocks);
                addElement.Click += AddCase_Click;

                panel.Controls.Add(addElement);

                panel.Size = new Size(panel.Width, panel.Height + addElement.Height + _distanceBetweenSubBlocks);

                _checlListsPanel.Size = new Size(_checlListsPanel.Width, _checlListsPanel.Height + panel.Height + _distanceBetweenBlocks);
                tempLoc = new Point(tempLoc.X, tempLoc.Y + panel.Height + _distanceBetweenBlocks);

                _checlListsPanel.Controls.Add(panel);
            }
        }
        public MaterialButton GetMaterialButtonFromPanel(Panel panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is MaterialButton)
                {
                    return (MaterialButton)panel.Controls[i];
                }
            }
            throw new Exception("Cant find button");
        }
        private void DeleteCase_Click(object sender, EventArgs e)
        {
            //check list CASE info
            Panel checkListCasePanel = (Panel)((MaterialButton)sender).Parent;
            Label checkListCaseName = GetLabelFromPanel(checkListCasePanel);
            if (checkListCaseName is null) throw new Exception("Cant find checkCASE name");

            //checkLIST info
            Panel checkListPanel = (Panel)((MaterialButton)sender).Parent.Parent;
            Label checkListName = GetLabelFromPanel(checkListPanel);
            if (checkListName is null) throw new Exception("Cant find checkList name");

            _subTask.DeleteSubTask(checkListName.Text, checkListCaseName.Text);
            InitCheckLists();
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
                    but.Click += ParticioanstsAction_Click;
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
                    but.Click += AddDeadLine_Click;
                }
                else if ((SubTaskButType)i == SubTaskButType.Attachment)
                {
                    but.Click += AddAttachment_Click;
                }
                else if ((SubTaskButType)i == SubTaskButType.Cover)
                {
                    but.Click += AddCover_Click;
                }
            }
        }
        private void ParticioanstsAction_Click(object sender, EventArgs e)
        {
            ParticipantsAction partAction = new ParticipantsAction(_subTask, _table);
            partAction.ShowDialog();

            InitParticipants();
        }
        private void AddCover_Click(object sender, EventArgs e)
        {
            CoverAction coverAction = new CoverAction(_subTask);
            coverAction.ShowDialog();

            InitCover();
        }
        private void AddAttachment_Click(object sender, EventArgs e)
        {
            AddAttachment addAtt = new AddAttachment(_table, _subTask, _task);
            addAtt.ShowDialog();

            InitAttachments();
        }
        private void AddDeadLine_Click(object sender, EventArgs e)
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
                Control control = GetMainPanelByType((SubTaskTypes)i);
                if (control is null) throw new Exception("Counl not find panel with type. It cant be");

                control.Location = new Point(control.Location.X, control.Location.Y + heightMove);

                control.Invalidate();
            }
        }
        private Control GetMainPanelByType(SubTaskTypes type)
        {
            for (int i = 0; i < MainPanel.Controls.Count; i++)
            {
                if (!(MainPanel.Controls[i].Tag is null) && MainPanel.Controls[i].Tag.ToString() == type.ToString())
                {
                    return MainPanel.Controls[i];
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
                Control control = GetMainPanelByType((SubTaskTypes)i);

                if(!(control.Tag is null) && control.Tag.ToString() == SubTaskTypes.Cover.ToString())
                {
                    control.Location = new Point(0, 0);
                    tempLoc = new Point(tempLoc.X, tempLoc.Y + control.Height + _distanceBetweenMainBlocks);
                }
                else if (!(control.Tag is null) && control.Tag.ToString() == SubTaskTypes.Name.ToString())
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
            int yButMenuLoc = _namePanel.Location.Y + _namePanel.Height * 2;
            _menuPanel.Location = new Point(this.Size.Width - _menuPanel.Width - _distanceBetweenMainBlocks * 3, yButMenuLoc);
        }
        private void InitPanelsSize()
        {
            _namePanel.AutoSize = false;
            _namePanel.Size = new Size(this.Width - 30, _onePointInNamePanelHeight * _subTask.GetTransfersAmount());

            _menuPanel.Size = new Size(200, 350);

            int rightPanelsWidth = this.Width - _menuPanel.Width - 15 - _distanceBetweenBlocks * 3;

            _coverPanel.Size = new Size(this.Width - 30, 0);
            _partisipentsPanel.Size = new Size(rightPanelsWidth, 0);
            _flagPanel.Size = new Size(rightPanelsWidth, 0);
            _deadlinePanel.Size = new Size(rightPanelsWidth, 0);
            _descriptionPanel.Size = new Size(rightPanelsWidth, 150);
            _attachmentsPanel.Size = new Size(rightPanelsWidth, 0);
            _checlListsPanel.Size = new Size(rightPanelsWidth, 0);
            _historyPanel.Size = new Size(rightPanelsWidth, 0);
        }
        private void InsertPanelsInForm()
        {
            MainPanel.Controls.Add(_coverPanel);
            MainPanel.Controls.Add(_namePanel);
            MainPanel.Controls.Add(_partisipentsPanel);
            MainPanel.Controls.Add(_flagPanel);
            MainPanel.Controls.Add(_deadlinePanel);
            MainPanel.Controls.Add(_descriptionPanel);
            MainPanel.Controls.Add(_attachmentsPanel);
            MainPanel.Controls.Add(_checlListsPanel);
            MainPanel.Controls.Add(_historyPanel);

            MainPanel.Controls.Add(_menuPanel);
        }
        private void InitZeroSizeForControls()
        {
            for (int i = 0; i <= (int)SubTaskTypes.ButMenu; i++)
            {
                Control control = GetMainPanelByType((SubTaskTypes)i);

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
            _attachmentsPanel.Tag = SubTaskTypes.Adition;
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
            _attachmentsPanel.BorderStyle = BorderStyle.FixedSingle;
            _checlListsPanel.BorderStyle = BorderStyle.FixedSingle;
            _historyPanel.BorderStyle = BorderStyle.FixedSingle;
        }
    }
}
