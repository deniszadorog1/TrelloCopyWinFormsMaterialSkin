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
using TrelloCopyWinForms.Windows.TableWindows.CreateTaskWindow;
using TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows;
using TrelloCopyWinForms.Models.Enums;
using TrelloCopyWinForms.Models.DataBase;


namespace TrelloCopyWinForms.Windows.TableWindows
{
    public partial class TableWindow : MaterialForm
    {
        private Table _table;

        private MaterialButton _addTaskBut = new MaterialButton();
        private const string _addTaskButName = "AddTaskBut";

        private const int _taskBoxWidth = 250;
        private const int _taskBoxStartHeight = 150;

        private const int _upperBorderDistance = 10;
        private const int _distanceBetweenTasks = 10;

        private const int _distanceBetweenSubTasks = 10;
        private const int _distanceBetweenSubTaskName = 5;

        private const string _addSubTaskButName = "AddSubTask";
        private const string _taskName = "TaskName";

        private bool _addTaskEventCorrection = true;

        private FlagsViewOnTableWindowType _type = FlagsViewOnTableWindowType.Line;
        public TableWindow(Table table)
        {
            _table = table;
            InitializeComponent();

            TablePanel.AllowDrop = true;

            //InitAddTaskBut();
            InitBackGroundColor();
            //UnusualPanel();

            InitTable();
        }
        public void InitBackGroundColor()
        {
            TablePanel.BackColor = (Color)_table.BgColor;
        }

        public void InitTable()
        {
            TablePanel.Controls.Clear();

            _table.SortTaskByPlaceingOnTable();
            for (int i = 0; i < _table.Tasks.Count; i++)
            {
                MaterialListBox taskBox = CreateTaskPanel(_table.Tasks[i].Name);
                TablePanel.Controls.Add(taskBox);

                _table.Tasks[i].SortSubTaskForPlaceing();
                Point loc = new Point(GetLabelFormMaterialListBox(taskBox).Location.X, taskBox.Location.Y + taskBox.Height + _distanceBetweenSubTasks);
                for (int j = 0; j < _table.Tasks[i].SubTasks.Count; j++)
                {
                    Panel newSubTask = CreateSubTask(_table.Tasks[i].SubTasks[j], taskBox);
                    newSubTask.Tag = _table.Tasks[i].SubTasks[j].UniqueIndex;

                    newSubTask.MouseDown += SubTask_MouseDown;
                    newSubTask.DragOver += SubTask_DragOver;
                    newSubTask.DragEnter += SubTask_DragEnter;
                    newSubTask.DragLeave += SubTask_DragLeave;
                    newSubTask.DragDrop += SubTask_DragDrop;

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
                but.Size = new Size(_taskBoxWidth / 4 * 3, _taskBoxWidth / 10);

                but.Location = new Point(_distanceBetweenSubTasks, taskBox.Height - _distanceBetweenSubTasks - but.Height);
                but.Click += AddSubTask_Click;

                but.Location = loc;
                taskBox.Height += but.Height + _distanceBetweenSubTasks * 2;

                taskBox.Controls.Add(but);


                //init add task button
            }
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
            Control subTaskControl = (Control)sender;
            if (!(sender is Panel) || ((Control)sender).Tag is null) subTaskControl = subTaskControl.Parent;

            int subTaskUniqueIndex = int.Parse(((Panel)subTaskControl).Tag.ToString());

            Control control = ((Panel)subTaskControl).Parent;
            Control taskNameLb = GetLabelNameFromPanel(control);

            Control subTaskNameLB = GetLabelNameFromPanel(((Panel)subTaskControl));
            string deleteTransfersSubName = RemoveTransfers(subTaskNameLB.Text);

            SubTaskMenu subTaskMenu = new SubTaskMenu(_table.GetSubTask(taskNameLb.Text, deleteTransfersSubName,
                subTaskUniqueIndex), _table, _table.GetTaskByName(taskNameLb.Text));
            subTaskMenu.ShowDialog();

            InitTable();
        }

        public string RemoveTransfers(string text)
        {
            string res = "";
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
            MaterialListBox taskBox = new MaterialListBox();
            //taskBox.Size = new Size(_taskBoxWidth, _taskBoxStartHeight);
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

            taskBox.Size = new Size(_taskBoxWidth + _distanceBetweenSubTasks * 3,
            name.Height + _distanceBetweenSubTasks * 3);

            taskBox.AllowDrop = true;

            taskBox.MouseDown += TaskPanel_MouseDown;

            taskBox.DragOver += TaskPanel_DragOver;
            //taskBox.DragLeave += TaskPanel_DragLeave;
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

            if (create._subTaskName == "") return;

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
            if (!(sender is Panel)) return;
            Panel box = sender as Panel;

            if (e.Button == MouseButtons.Left)
            {
                box.DoDragDrop(box, DragDropEffects.Move);
            }
        }
        private void SubTask_DragLeave(object sender, EventArgs e)
        {

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
        private void SubTask_DragDrop(object sender, DragEventArgs e)
        {
            /*//sender - place(or control) where we dropped
            Panel panel = (Panel)e.Data.GetData(typeof(Panel)); //that was dragged
            Point dropLocation = this.PointToClient(new Point(e.X, e.Y));

            //Get task where we are dragged from 
            Control taskPanelGettingFrom = panel.Parent;

            //Get task where we dragging into 
            Control taskPanelInsertingInto = ((Panel)sender).Parent;

            //GetTask name drgging from 
            Control gettingFromLB = GetLabelNameFromPanel(taskPanelGettingFrom);
            //GetTask name drgging where
            Control draggingIntoLB = GetLabelNameFromPanel(taskPanelInsertingInto);

            //define position
            int newSubTaskPosition =
                GetNewPositionInDraggedTaskPanel(dropLocation, (MaterialListBox)taskPanelInsertingInto);

            Control subTaskNameLB = GetLabelNameFromPanel(panel);

            _table.MoveSubTaskToAnoutherTask(gettingFromLB.Text, draggingIntoLB.Text, subTaskNameLB.Text, int.Parse(panel.Tag.ToString()), newSubTaskPosition);


            _table.UpdateSUbTasksInDB();


            InitTable();*/
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
            Panel flgsPanel = InitFlags(subTask, subTaskOBJ, nameLabel.Location.Y + nameLabel.Height);
            if (!(flgsPanel is null)) subTask.Controls.Add(flgsPanel);

            //Other stuf attribs

            return subTask;
        }

        public Panel InitFlags(Panel subTaskPanel, SubTask subTask, int positionToPlace)
        {
            Panel flagsPanel = new Panel();


            flagsPanel.Click -= EnterSubTaskMenu_Click;
            flagsPanel.Click += EnterSubTaskMenu_Click;

            int panelHeight = _type == FlagsViewOnTableWindowType.Line ? 10 : 40;
            panelHeight += _distanceBetweenSubTaskName * 2;

            flagsPanel.Size = new Size(subTaskPanel.Width, panelHeight);

            flagsPanel.BorderStyle = BorderStyle.FixedSingle;

            if (subTask.Flags.Count == 0) return null;

            Point loc = new Point(_distanceBetweenSubTaskName, _distanceBetweenSubTaskName);
            for (int i = 0; i < subTask.Flags.Count; i++)
            {
                Panel oneFlagPanel = new Panel();
                oneFlagPanel.BackColor = subTask.Flags[i].FlagColor;
                oneFlagPanel.Size = new Size(60, 10);

                oneFlagPanel.Click += ChecngeFlagsViewType_Click;

                if (_type == FlagsViewOnTableWindowType.Whole)
                {
                    oneFlagPanel.Size = new Size(60, 40);

                    if (subTask.Flags[i].FlagTag != string.Empty)
                    {
                        Label flagTag = new Label();
                        flagTag.Location = new Point(0, 0);
                        flagTag.Text = subTask.Flags[i].FlagTag;
                        flagTag.Font = new Font("Times New Roman", 12);
                        flagTag.TextAlign = ContentAlignment.MiddleLeft;

                        flagTag.Click += ChecngeFlagsViewType_Click;

                        Size textSize = TextRenderer.MeasureText(flagTag.Text, flagTag.Font, new Size(flagTag.Width, 0), TextFormatFlags.WordBreak);


                        if (textSize.Width > oneFlagPanel.Width)
                        {
                            oneFlagPanel.Width = flagTag.Width;
                        }

                        oneFlagPanel.Controls.Add(flagTag);
                    }
                }

                if (i == 0)
                {
                    oneFlagPanel.Location = loc;
                }
                else if (loc.X + flagsPanel.Controls[flagsPanel.Controls.Count - 1].Width + oneFlagPanel.Width + _distanceBetweenSubTaskName * 2 > flagsPanel.Width)
                {
                    loc = new Point(flagsPanel.Controls[0].Location.X, flagsPanel.Controls[flagsPanel.Controls.Count - 1].Location.Y + oneFlagPanel.Height + _distanceBetweenSubTaskName * 2);
                    flagsPanel.Height += oneFlagPanel.Height + _distanceBetweenSubTaskName * 2;
                    oneFlagPanel.Location = loc;

                }
                else
                {
                    loc = new Point(loc.X + flagsPanel.Controls[flagsPanel.Controls.Count - 1].Width + _distanceBetweenSubTaskName, loc.Y);
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
            string deviderInRows = DevideStringInRows(subTaskOBJ.Name);
            int amountOfTransfers = GetTransfersAmount(deviderInRows);

            Label _subTaskName = new Label();
            _subTaskName.AutoSize = true;
            _subTaskName.BorderStyle = BorderStyle.FixedSingle;

            _subTaskName.Text = DevideStringInRows(subTaskOBJ.Name);
            _subTaskName.Location = new Point(_distanceBetweenSubTaskName, yLocToPlace);
            _subTaskName.AutoSize = false;
            _subTaskName.Size = new Size(subTask.Width - _distanceBetweenSubTaskName * 2, 20 * amountOfTransfers + 1);


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
                    else if(!(subTaskOBJ.Cover.BGImage is null))
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
                //_subTaskCover.Height = heightBgColorPartTypeCover;

                subTask.Height += _subTaskCover.Height;
            }
            else
            {
                subTask.BackColor = Color.Empty;
            }

            return _subTaskCover;
        }
        private void BackgroundPanel_Paint(object sender, PaintEventArgs e)
        {
            if (sender is PictureBox picBox && picBox.BackgroundImage != null)
            {
                e.Graphics.DrawImage(picBox.BackgroundImage, new Rectangle(0, 0, picBox.Width, picBox.Height));
            }
        }
        private void SubTask_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel subTask)
            {
                subTask.BorderStyle = BorderStyle.Fixed3D;
            }
        }
        private void SubTask_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel subTask)
            {
                subTask.BorderStyle = BorderStyle.FixedSingle;
            }
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
            string res = "";

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
        private void BGImage_Click(object sender, EventArgs e)
        {

        }
    }
}
