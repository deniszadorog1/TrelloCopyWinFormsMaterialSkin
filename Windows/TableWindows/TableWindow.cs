﻿using System;
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
using TrelloCopyWinForms.Windows.TableWindows.CreateTaskWindow;
using TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows;
using TrelloCopyWinForms.Models.Enums;
using TrelloCopyWinForms.Models.DataBase;
using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Windows.CreateTableWindow;
using TrelloCopyWinForms.Windows.TableWindows.Codes;
using System.IO;

namespace TrelloCopyWinForms.Windows.TableWindows
{
    public partial class TableWindow : MaterialForm
    {
        private Table _table;
        private User _user;
        private List<Table> _tables;

        private MaterialButton _addTaskBut = new MaterialButton();
        private const string _addTaskButName = "AddTaskBut";

        private const int _taskBoxWidth = 250;
        private const int _upperBorderDistance = 10;
        private const int _distanceBetweenSubTasks = 10;
        private const int _distanceBetweenSubTaskName = 5;

        private const string _addSubTaskButName = "AddSubTask";
        private const string _taskName = "TaskName";

        private bool _addTaskEventCorrection = true;

        private FlagsViewOnTableWindowType _type = FlagsViewOnTableWindowType.Line;

        private Image _emptyStar;
        private Image _fullStar;

        public TableWindow(Table table, User user, List<Table> tables)
        {
            _table = table;
            _user = user;
            _tables = tables;
            _user.Type = DBUsage.GetUserTypeForTable(_table.Id, _user.Id);
            DBUsage.InsertFavStatusForTables(_user, _tables);

            InitializeComponent();

            InitStartPaths();

            TablePanel.AllowDrop = true;
            TablePanel.BackColor = (Color)_table.BgColor;

            InitTable();
            CreateLeftPanel();
        }
        public void CreateLeftPanel()
        {
            LeftTablesPanel.Controls.Clear();

            Point loc = new Point(_distanceBetweenSubTaskName, _distanceBetweenSubTasks);
            Size starSize = new Size(30, 30);
            const int tablePanelHeight = 50;

            SortTablesByFavs();

            for (int i = 0; i < _tables.Count; i++)
            {
                Panel tablePanel = new Panel();
                tablePanel.BorderStyle = BorderStyle.FixedSingle;
                tablePanel.Tag = _tables[i].Id;
                tablePanel.Location = loc;
                tablePanel.Size = new Size(LeftTablesPanel.Width -
                    _distanceBetweenSubTasks * 2, tablePanelHeight);
                tablePanel.Click += ChangeTable_Click;

                PictureBox tableColor = new PictureBox();
                tableColor.BorderStyle = BorderStyle.FixedSingle;
                tableColor.BackColor = (Color)_tables[i].BgColor;
                tableColor.Size = new Size(tablePanelHeight / 2, tablePanelHeight / 2);
                tableColor.Location = new Point(_distanceBetweenSubTaskName / 2,
                    tablePanel.Height / 2 - tableColor.Height / 2);
                tablePanel.Controls.Add(tableColor);

                PictureBox starBox = new PictureBox();
                starBox.Tag = _tables[i].Id;
                starBox.BorderStyle = BorderStyle.FixedSingle;
                starBox.Size = starSize;
                starBox.SizeMode = PictureBoxSizeMode.StretchImage;
                starBox.Click += ChangeFavType_Click;
                starBox.Location = new Point(tablePanel.Width - starBox.Width, 0);
                starBox.Image = _tables[i].FavStatus == FavoriteType.Favorite ? _fullStar : _emptyStar;
                tablePanel.Controls.Add(starBox);

                Label label = new Label();
                label.AutoSize = false;
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Text = _tables[i].Name;
                label.Location = new Point(tableColor.Location.X + tableColor.Width, 0);
                label.Size = new Size(tablePanel.Width - tableColor.Width -
                    starBox.Width - _distanceBetweenSubTaskName * 2, tablePanel.Height);
                label.Click += ChangeTable_Click;
                tablePanel.Controls.Add(label);

                LeftTablesPanel.Controls.Add(tablePanel);

                loc = new Point(loc.X, loc.Y + tablePanel.Height + _distanceBetweenSubTasks);
            }
        }
        public void SortTablesByFavs()
        {
            List<Table> res = new List<Table>();

            res.AddRange(_tables.Where(x => x.FavStatus == FavoriteType.Favorite).ToList());
            res.AddRange(_tables.Where(x => x.FavStatus == FavoriteType.Usual).ToList());

            _tables = res;
        }
        private void ChangeFavType_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox picBox)
            {
                Table table = _tables.Find(x => x.Id == (int)picBox.Tag);

                table.FavStatus = table.FavStatus == FavoriteType.Favorite ? FavoriteType.Usual : FavoriteType.Favorite;

                DBUsage.UpdateFavStatus(_user.Id, table.Id, table.FavStatus == FavoriteType.Favorite ? true : false);
                CreateLeftPanel();
            }
        }
        private void InitStartPaths()
        {
            DirectoryInfo baseDirectoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string imageDirectory = baseDirectoryInfo.Parent.Parent.FullName;
            string imagePath = Path.Combine(imageDirectory, "Images");
            string strasDisrctory = Path.Combine(imagePath, "FavStars");

            string emptyStarPath = Path.Combine(strasDisrctory, "emptyStar.png");
            _emptyStar = Image.FromFile(emptyStarPath);

            string fullStarPath = Path.Combine(strasDisrctory, "fullStar.png");
            _fullStar = Image.FromFile(fullStarPath);
        }
        private void ChangeTable_Click(object sender, EventArgs e)
        {
            if(sender is Label lb)
            {
                sender = lb.Parent;
            }

            if (sender is Panel panel)
            {
                Table table = _tables.Find(x => x.Id == (int)((Panel)sender).Tag);

                _table = table;
                InitTable();
                _user.Type = DBUsage.GetUserTypeForTable(table.Id, _user.Id);
            }
        }
        public void InitTable()
        {
            const int deviderInQuoters = 4;
            const int addSubTaskWidthMultiplier = 3;
            const int addSubTaskHeightMultiplier = 10;

            TablePanel.Controls.Clear();

            TablePanel.BackColor = (Color)_table.BgColor;

            _table.SortTaskByPlaceingOnTable();
            for (int i = 0; i < _table.Tasks.Count; i++)
            {
                MaterialListBox taskBox = CreateTaskPanel(_table.Tasks[i].Name);
                TablePanel.Controls.Add(taskBox);

                _table.Tasks[i].SortSubTaskForPlaceing();
                Point loc = new Point(GetLabelFormMaterialListBox(taskBox).Location.X,
                    taskBox.Location.Y + taskBox.Height + _distanceBetweenSubTasks);
                for (int j = 0; j < _table.Tasks[i].SubTasks.Count; j++)
                {
                    Panel newSubTask = CreateSubTask(_table.Tasks[i].SubTasks[j], taskBox);
                    newSubTask.Tag = _table.Tasks[i].SubTasks[j].UniqueIndex;

                    newSubTask.MouseDown += SubTask_MouseDown;
                    newSubTask.DragOver += SubTask_DragOver;
                    newSubTask.DragEnter += SubTask_DragEnter;

                    newSubTask.Click -= EnterSubTaskMenu_Click;
                    newSubTask.Click += EnterSubTaskMenu_Click;
                    taskBox.Controls.Add(newSubTask);

                    newSubTask.Location = loc;

                    loc = new Point(loc.X, loc.Y + newSubTask.Height + _distanceBetweenSubTasks);
                    taskBox.Height += newSubTask.Height + _distanceBetweenSubTasks;
                }
                //init add subtask button
                MaterialButton but = new MaterialButton();
                but.Text = "Add new subTask";
                but.Name = _addSubTaskButName;
                but.Tag = taskBox.Name;
                but.AutoSize = false;
                but.Size = new Size(_taskBoxWidth / deviderInQuoters * addSubTaskWidthMultiplier, _taskBoxWidth / addSubTaskHeightMultiplier);
                but.Location = new Point(_distanceBetweenSubTasks, taskBox.Height - _distanceBetweenSubTasks - but.Height);
                but.Click += AddSubTask_Click;

                but.Location = loc;
                taskBox.Height += but.Height + _distanceBetweenSubTasks * 2;

                taskBox.Controls.Add(but);
            }
            //init add task button
            _addTaskBut.Text = "Add new task";
            _addTaskBut.Name = _addTaskButName;
            _addTaskBut.Click -= AddTask_Click;
            _addTaskBut.Click += AddTask_Click;

            _addTaskBut.Location = new Point(0, _upperBorderDistance);
            TablePanel.Controls.Add(_addTaskBut);
        }
        public Label GetLabelFormMaterialListBox(MaterialListBox box)
        {
            for (int i = 0; i < box.Controls.Count; i++)
            {
                if (box.Controls[i] is Label)
                {
                    return (Label)box.Controls[i];
                }
            }
            throw new InvalidOperationException("Cant find label with such name");
        }
        private void EnterSubTaskMenu_Click(object sender, EventArgs e)
        {
            if (_user.Type == AccountType.Viewer) return;

            Control subTaskControl = (Control)sender;
            if (!(sender is Panel) || ((Control)sender).Tag is null) subTaskControl = subTaskControl.Parent;

            int subTaskUniqueIndex = int.Parse(((Panel)subTaskControl).Tag.ToString());

            Control control = ((Panel)subTaskControl).Parent;
            Control taskNameLb = GetLabelNameFromPanel(control);

            Control subTaskNameLB = GetLabelNameFromPanel(((Panel)subTaskControl));
            string deleteTransfersSubName = RemoveTransfers(subTaskNameLB.Text);

            SubTaskMenu subTaskMenu = new SubTaskMenu(_table.GetSubTask(taskNameLb.Text, deleteTransfersSubName,
                subTaskUniqueIndex), _table, _table.GetTaskByName(taskNameLb.Text), _user);
            subTaskMenu.ShowDialog();

            InitTable();
        }
        public string RemoveTransfers(string text)
        {
            string res = string.Empty;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != '\n')
                {
                    res += text[i];
                }
            }
            return res;
        }
        private void AddTask_Click(object sender, EventArgs e)
        {
            if (_user.Type == AccountType.Viewer) return;
            if (!_addTaskEventCorrection) return;

            CreateTask create = new CreateTask();
            create.ShowDialog();

            if (create._task is null) return;
            if (!_table.IfTaskIsExist(create._task.Name))
            {

                _table.AddTask(create._task.Name);
                InsertTaskInTableDB(_table.Tasks.Last());

                _addTaskEventCorrection = false;
                InitTable();
                _addTaskEventCorrection = true;
                return;
            }
            MessageBox.Show("task with is name is already exist!");
        }
        public void InsertTaskInTableDB(TableTask task)
        {
            task.PlaceingTableId = _table.Tasks.Count;
            task.TableId = _table.Id;
            DBUsage.InsertTask(task);
            task.Id = DBUsage.GetTaskLastId();
        }
        private MaterialListBox CreateTaskPanel(string taskName)
        {
            const int taskBoxWidthDistBetwennMultiplier = 3;
            const int taskBoxHeightDistBetwennMultiplier = 3;

            MaterialListBox taskBox = new MaterialListBox();
            taskBox.Name = taskName;
            taskBox.BorderColor = Color.Black;
            taskBox.ShowBorder = true;

            //Add task name
            Label name = new Label();
            name.AutoSize = true;
            name.Text = DevideStringInRows(taskName);
            name.Location = new Point(_distanceBetweenSubTasks, _distanceBetweenSubTasks);
            name.Name = _taskName;
            name.Click += RenameTask_Click;
            name.BorderStyle = BorderStyle.FixedSingle;
            taskBox.Controls.Add(name);

            taskBox.Size = new Size(_taskBoxWidth + _distanceBetweenSubTasks * taskBoxWidthDistBetwennMultiplier,
            name.Height + _distanceBetweenSubTasks * taskBoxHeightDistBetwennMultiplier);

            taskBox.AllowDrop = true;

            taskBox.MouseDown += TaskPanel_MouseDown;
            taskBox.DragOver += TaskPanel_DragOver;
            taskBox.DragDrop += TaskPanel_DragDrop;
            taskBox.DragEnter += TaskPanel_DragEnter;

            return taskBox;
        }
        private void TaskPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is MaterialListBox)) return;
            MaterialListBox box = sender as MaterialListBox;

            if (e.Button == MouseButtons.Left)
            {
                box.DoDragDrop(box, DragDropEffects.Move);
            }
        }
        private void TaskPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void TaskPanel_DragDrop(object sender, DragEventArgs e)
        {
            //if sender is Panel(subTask) //handle 
            if (!((Panel)e.Data.GetData(typeof(Panel)) is null))
            {
                Panel subTaskPan = (Panel)e.Data.GetData(typeof(Panel));
                Point dropLocation = ((MaterialListBox)sender).PointToClient(new Point(e.X, e.Y));

                Control from = subTaskPan.Parent;
                ReassingDraggedTask(from, (MaterialListBox)sender, subTaskPan, dropLocation);

                _table.UpdateSUbTasksInDB();
                return;
            }
            //if Panel dropped on anouther Panel => swap them
            //sender - place(or control) where we dropped
            MaterialListBox panel = (MaterialListBox)e.Data.GetData(typeof(MaterialListBox)); //that was dragged
            if (panel is null) return;

            //Swap tables in logic 
            SwapTableInLogic(panel, (MaterialListBox)sender);

            _table.UpdateTasks();
            InitTable();
        }
        public void SwapTableInLogic(MaterialListBox first, MaterialListBox second)
        {
            Label firstNameLB = GetLabelFormMaterialListBox(first);
            Label secondNameLB = GetLabelFormMaterialListBox(second);

            _table.SwapTwoTasks(firstNameLB.Text, secondNameLB.Text);
        }
        private void TaskPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void RenameTask_Click(object sender, EventArgs e)
        {
            if (sender is Label taskName)
            {
                TableTask resTask = _table.GetTaskByName(taskName.Text);
                if (resTask is null) return;

                RenameTask rename = new RenameTask(resTask, _table.Tasks);
                rename.ShowDialog();

                DBUsage.UpdateTask(resTask);

                InitTable();
            }
        }
        private Control GetLabelNameFromPanel(Control panel)
        {
            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i] is Label)
                {
                    return panel.Controls[i];
                }
            }
            return null;
        }
        private void AddSubTask_Click(object sender, EventArgs e)
        {
            CreateSubTask create = new CreateSubTask();
            create.ShowDialog();

            if (create._subTaskName == string.Empty) return;

            SubTask subTask = _table.AddSubTask(((Button)sender).Tag.ToString(), create._subTaskName);
            subTask.TaskId = _table.GetTaskByName(((Button)sender).Tag.ToString()).Id;

            InsertSubTaskInDB(subTask);

            InitTable();
        }
        private void InsertSubTaskInDB(SubTask subTask)
        {
            DBUsage.InsertSubTask(subTask);
            subTask.Id = DBUsage.GetSubTasksLastId();
        }
        private void SubTask_MouseDown(object sender, MouseEventArgs e)
        {
            if (_user.Type == AccountType.Viewer) return;
            if (!(sender is Panel)) return;
            Panel box = sender as Panel;

            if (e.Button == MouseButtons.Left)
            {
                box.DoDragDrop(box, DragDropEffects.Move);
            }
        }
        private void SubTask_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void SubTask_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Panel)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        public void ReassingDraggedTask(Control from, Control into, Panel draggedPanel, Point droppedPosition)
        {
            //GetTask name drgging from 
            Control gettingFromLB = GetLabelNameFromPanel(from);
            //GetTask name drgging where
            Control draggingIntoLB = GetLabelNameFromPanel(into);

            //define position
            int newSubTaskPosition =
                GetNewPositionInDraggedTaskPanel(droppedPosition, (MaterialListBox)into);

            Control subTaskNameLB = GetLabelNameFromPanel(draggedPanel);

            if (from.Name == into.Name)
            {
                _table.MoveSubTaskInSameTask(gettingFromLB.Text, subTaskNameLB.Text, int.Parse(draggedPanel.Tag.ToString()), newSubTaskPosition);
            }
            else
            {
                _table.MoveSubTaskToAnoutherTask(gettingFromLB.Text, draggingIntoLB.Text, subTaskNameLB.Text, int.Parse(draggedPanel.Tag.ToString()), newSubTaskPosition);
            }
            InitTable();
        }
        public int GetNewPositionInDraggedTaskPanel(Point droppedPoint, MaterialListBox newTaskBox)
        {
            int lastpanelIndex = -1;
            for (int i = 0; i < newTaskBox.Controls.Count; i++)
            {
                if (!(newTaskBox.Controls[i] is Button) &&
                    !(newTaskBox.Controls[i] is Label) &&
                    !(newTaskBox.Controls[i] is MaterialScrollBar))
                {
                    lastpanelIndex = GetSubTasksBySubTaskPanek((Panel)newTaskBox.Controls[i]).UniqueIndex;
                    if (droppedPoint.Y < newTaskBox.Controls[i].Location.Y + newTaskBox.Controls[i].Height)
                    {
                        return lastpanelIndex;
                    }
                }
            }
            return lastpanelIndex != -1 ? lastpanelIndex : 0;
        }
        public SubTask GetSubTasksBySubTaskPanek(Panel subTaskPanel)
        {
            Control taskName = GetLabelNameFromPanel(subTaskPanel.Parent);
            Control subTaskNameLB = GetLabelNameFromPanel(subTaskPanel);

            return _table.GetSubTask(taskName.Text, subTaskNameLB.Text,
                int.Parse(subTaskPanel.Tag.ToString()));
        }
        private Panel CreateSubTask(SubTask subTaskOBJ, Control taskToAddSubTask)
        {
            Panel subTask = new Panel();
            subTask.Name = subTaskOBJ.Name;
            subTask.Size = new Size(taskToAddSubTask.Width - _distanceBetweenSubTasks * 2, 0);
            subTask.AutoSize = false;
            subTask.BorderStyle = BorderStyle.FixedSingle;
            BackColor = SystemColors.ControlLight;

            //Cover
            PictureBox coverBox = GetSubTaskCoverPictureBox(subTask, subTaskOBJ);
            subTask.Controls.Add(coverBox);

            coverBox.Click -= EnterSubTaskMenu_Click;
            coverBox.Click += EnterSubTaskMenu_Click;

            //Name
            Label nameLabel = InitNameLBInSUbTasksaPanel(subTask, subTaskOBJ, coverBox.Location.Y + subTask.Height);
            subTask.Controls.Add(nameLabel);

            nameLabel.Click -= EnterSubTaskMenu_Click;
            nameLabel.Click += EnterSubTaskMenu_Click;

            //Flags
            Panel flgsPanel = InitFlags(subTask, subTaskOBJ);
            if (!(flgsPanel is null)) subTask.Controls.Add(flgsPanel);

            //Other stuf attribs
            return subTask;
        }

        public Panel InitFlags(Panel subTaskPanel, SubTask subTask)
        {
            const int flagPanelHeightLineType = 10;
            const int flagPanelHeightFullType = 40;
            const int flagWidth = 60;
            const int flagLineHeight = 10;
            const int flagWholeHeight = 40;
            const int checkForZero = 0;
            Size lineFlagSize = new Size(flagWidth, flagLineHeight);
            Size wholeFlagSize = new Size(flagWidth, flagWholeHeight);

            Panel flagsPanel = new Panel();

            flagsPanel.Click -= EnterSubTaskMenu_Click;
            flagsPanel.Click += EnterSubTaskMenu_Click;

            int panelHeight = _type == FlagsViewOnTableWindowType.Line ?
                flagPanelHeightLineType : flagPanelHeightFullType;
            panelHeight += _distanceBetweenSubTaskName * 2;

            flagsPanel.Size = new Size(subTaskPanel.Width, panelHeight);

            flagsPanel.BorderStyle = BorderStyle.FixedSingle;

            if (subTask.Flags.Count == 0) return null;

            Point loc = new Point(_distanceBetweenSubTaskName, _distanceBetweenSubTaskName);
            for (int i = 0; i < subTask.Flags.Count; i++)
            {
                Panel oneFlagPanel = new Panel();
                oneFlagPanel.BackColor = subTask.Flags[i].FlagColor;
                oneFlagPanel.Size = lineFlagSize;

                oneFlagPanel.Click += ChecngeFlagsViewType_Click;

                if (_type == FlagsViewOnTableWindowType.Whole)
                {
                    oneFlagPanel.Size = wholeFlagSize;

                    if (subTask.Flags[i].FlagTag != string.Empty)
                    {
                        Label flagTag = new Label();
                        flagTag.Location = new Point(0, 0);
                        flagTag.Text = subTask.Flags[i].FlagTag;
                        flagTag.Font = new Font("Times New Roman", 12);
                        flagTag.TextAlign = ContentAlignment.MiddleLeft;
                        flagTag.ForeColor = subTask.Flags[i].ForColor;

                        flagTag.Click += ChecngeFlagsViewType_Click;

                        Size textSize = TextRenderer.MeasureText(flagTag.Text, flagTag.Font, 
                            new Size(flagTag.Width, 0), TextFormatFlags.WordBreak);

                        if (textSize.Width > oneFlagPanel.Width)
                        {
                            oneFlagPanel.Width = flagTag.Width;
                        }
                        oneFlagPanel.Controls.Add(flagTag);
                    }
                }
                if (i == checkForZero)
                {
                    oneFlagPanel.Location = loc;
                }
                else if (loc.X + flagsPanel.Controls[flagsPanel.Controls.Count - 1].Width + 
                    oneFlagPanel.Width + _distanceBetweenSubTaskName * 2 > flagsPanel.Width)
                {
                    loc = new Point(flagsPanel.Controls[0].Location.X, 
                        flagsPanel.Controls[flagsPanel.Controls.Count - 1].Location.Y + 
                        oneFlagPanel.Height + _distanceBetweenSubTaskName * 2);
                    flagsPanel.Height += oneFlagPanel.Height + _distanceBetweenSubTaskName * 2;
                    oneFlagPanel.Location = loc;

                }
                else
                {
                    loc = new Point(loc.X + flagsPanel.Controls[flagsPanel.Controls.Count - 1].Width + 
                        _distanceBetweenSubTaskName, loc.Y);
                    oneFlagPanel.Location = loc;
                }
                flagsPanel.Controls.Add(oneFlagPanel);

            }

            Control control = subTaskPanel.Controls[subTaskPanel.Controls.Count - 1];

            flagsPanel.Location = new Point(subTaskPanel.Location.X, control.Location.Y + control.Height);
            subTaskPanel.Controls.Add(flagsPanel);

            subTaskPanel.Size = new Size(subTaskPanel.Width, subTaskPanel.Height + flagsPanel.Height + _distanceBetweenSubTaskName * 2);

            return flagsPanel;
        }
        private void ChecngeFlagsViewType_Click(object sender, EventArgs e)
        {
            _type = _type == FlagsViewOnTableWindowType.Line ? FlagsViewOnTableWindowType.Whole : FlagsViewOnTableWindowType.Line;

            InitTable();
        }
        public Label InitNameLBInSUbTasksaPanel(Panel subTask, SubTask subTaskOBJ, int yLocToPlace)
        {
            const int transfersCorrcetion = 1;
            const int heightPerOneTransfer = 20;
            string deviderInRows = DevideStringInRows(subTaskOBJ.Name);
            int amountOfTransfers = GetTransfersAmount(deviderInRows);
            

            Label _subTaskName = new Label();
            _subTaskName.AutoSize = true;
            _subTaskName.BorderStyle = BorderStyle.FixedSingle;

            _subTaskName.Text = DevideStringInRows(subTaskOBJ.Name);
            _subTaskName.Location = new Point(_distanceBetweenSubTaskName, yLocToPlace);
            _subTaskName.AutoSize = false;
            _subTaskName.Size = new Size(subTask.Width - _distanceBetweenSubTaskName * 2, 
                heightPerOneTransfer * amountOfTransfers + transfersCorrcetion);

            subTask.Size = new Size(subTask.Width,
                subTask.Height + _subTaskName.Height + _distanceBetweenSubTaskName * 2);

            return _subTaskName;
        }
        public PictureBox GetSubTaskCoverPictureBox(Panel subTask, SubTask subTaskOBJ)
        {
            const int heightBgColorPartTypeCover = 25;
            const int heightBgImagePartTypeCover = 125;

            PictureBox _subTaskCover = new PictureBox();
            _subTaskCover.SizeMode = PictureBoxSizeMode.StretchImage;

            _subTaskCover.Size = new Size(subTask.Width, 0);
            if (!(subTaskOBJ.Cover is null))
            {
                if (subTaskOBJ.Cover.Type == CoverType.PartSizeCover)
                {

                    if (!(subTaskOBJ.Cover.BGColor is null))
                    {
                        _subTaskCover.Height = heightBgColorPartTypeCover;
                        _subTaskCover.BackColor = (Color)subTaskOBJ.Cover.BGColor;
                    }
                    else if (!(subTaskOBJ.Cover.BGImage is null))
                    {
                        _subTaskCover.Height = heightBgImagePartTypeCover;
                        _subTaskCover.Image = subTaskOBJ.Cover.BGImage.Image;
                    }
                }
                else
                {

                    if (!(subTaskOBJ.Cover.BGColor is null)) subTask.BackColor = (Color)subTaskOBJ.Cover.BGColor;
                    else if (!(subTaskOBJ.Cover.BGImage is null)) subTask.BackgroundImage = subTaskOBJ.Cover.BGImage.Image;
                }
                _subTaskCover.Location = new Point(0, 0);
                subTask.Height += _subTaskCover.Height;
            }
            else
            {
                subTask.BackColor = Color.Empty;
            }
            return _subTaskCover;
        }
        private static int GetTransfersAmount(string str)
        {
            int count = 1;
            for (int i = 0; i < str.Length - 1; i++)
            {
                char tempValue = str[i];
                if (str[i] == '\n')
                {
                    count++;
                    i++;
                }
            }
            return count;
        }
        private string DevideStringInRows(string row)
        {
            const int charsInRow = 17;
            string res = string.Empty;

            for (int i = 0; i < row.Length; i++)
            {
                if (i % charsInRow == 0 && i != 0)
                {
                    res += "\n";
                }
                res += row[i];
            }
            return res;
        }
        private void CreateInviteMessBut_Click(object sender, EventArgs e)
        {
            CreateInviteMessage createMessage = new CreateInviteMessage(_table);
            createMessage.ShowDialog();
        }
        private void CreateTableBut_Click(object sender, EventArgs e)
        {
            if (_user.Type == AccountType.Viewer)
            {
                MessageBox.Show("You are viewer");
                return;
            }
            CreateTable create = new CreateTable(_user);
            create.ShowDialog();

            _tables = DBUsage.GetAllTables();

            _tables = GetTablesWhichUserCanUse();
            CreateLeftPanel();
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
        public bool IfUserContrinsInTable(Table table)
        {
            for (int i = 0; i < table.UserInTable.Count; i++)
            {
                if (table.UserInTable[i].Id == _user.Id) return true;
            }
            return false;
        }
        private void EnterCodeBut_Click(object sender, EventArgs e)
        {
            EnterCode code = new EnterCode(_user);
            code.ShowDialog();

            if (!(code._table is null))
            {
                _tables = DBUsage.GetAllTables();
                _tables = GetTablesWhichUserCanUse();
                CreateLeftPanel();
            }
        }
        private void DeleteUsers_Click(object sender, EventArgs e)
        {
            if (_user.Type != AccountType.Admin)
            {
                MessageBox.Show("You are not admin");
                return;
            }
            DeleteUsersFromTable delete = new DeleteUsersFromTable(_table);
            delete.ShowDialog();

            if (!DBUsage.IfUserContainsInTable(_table.Id, _user.Id))
            {
                TablePanel.Controls.Clear();
                TablePanel.BackColor = SystemColors.Control;

                _table.UserInTable = DBUsage.GetUsersForTable(_table.Id);

                _tables = GetTablesWhichUserCanUse();
                CreateLeftPanel();
            }
        }
    }
}
