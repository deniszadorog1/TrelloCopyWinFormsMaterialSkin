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

namespace TrelloCopyWinForms.Windows.TableWindows
{
    public partial class TableWindow : MaterialForm
    {
        private Table _table = null;
        private List<Control> _taskControls = new List<Control>();
        private List<List<Control>> _controlsInTasks = new List<List<Control>>();

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


        //private TransparentFlowLayoutPanel TablePanel = new TransparentFlowLayoutPanel();

        public TableWindow(Table table)
        {
            _table = table;
            InitializeComponent();

            TablePanel.AllowDrop = true;

            InitAddTaskBut();
            InitBackGroundColor();
            //UnusualPanel();
        }

        public void UnusualPanel()
        {
            TablePanel.WrapContents = false;
            TablePanel.AutoScroll = true;
            TablePanel.Location = new Point(0, 65);
            TablePanel.Size = new Size(600, Size.Height - 65);

            Controls.Add(TablePanel);


        }
        public void InitBackGroundColor()
        {

            BackgroundImage = _table.BGImage;
            //BGImage.Image = _table.BGImage;
            //BGImage.SendToBack();

            //TablePanel.BackgroundImage = _table.BGImage;

            /*       if (!(_table.BGImage is null))
                   {
                       BGImage.Image = _table.BGImage;
                   }*/
        }
        private void UpdateControlsInTable()
        {
            TablePanel.Controls.Clear();
            for (int i = 0; i < _taskControls.Count; i++)
            {
                //_taskControls[i].BringToFront();
                TablePanel.Controls.Add(_taskControls[i]);
            }
        }
        public void InitAddTaskBut()
        {
            _addTaskBut.Text = "Add new task";
            _addTaskBut.Name = _addTaskButName;
            _addTaskBut.Click += AddTask_Click;
            _addTaskBut.Location = new Point(0, _upperBorderDistance);

            _taskControls.Add(_addTaskBut);
            UpdateControlsInTable();
        }
        private void AddTask_Click(object sender, EventArgs e)
        {
            CreateTask create = new CreateTask();
            create.ShowDialog();

            if (create._task is null) return;
            if (!_taskControls.Any(x => x.Name == create._task.Name))
            {
                AddNewTaskBoxInTable(create._task.Name);
                AddAllControlsForLastTaskInList();
                _table.AddTask(create._task.Name);

                return;
            }
            MessageBox.Show("task with is name is already exist!");
        }
        private void AddAllControlsForLastTaskInList()
        {
            _controlsInTasks.Add(new List<Control>());

            Control control = _taskControls[_taskControls.Count - 2];
            List<Control> lastList = _controlsInTasks.Last();

            for (int i = 0; i < control.Controls.Count; i++)
            {
                lastList.Add(control.Controls[i]);
            }
        }
        private void AddNewTaskBoxInTable(string taskName)
        {
            //Get task box
            MaterialListBox newTaskBox = CreateTaskPanel(taskName);
            //Init new location for new task box
            InitLocationForNewTask(newTaskBox);
            //reassign controls in table
            SwapTwoLastTasksLocsInTable();
        }
        public void SwapTwoLastTasksLocsInTable()
        {
            TablePanel.Controls.RemoveAt(TablePanel.Controls.Count - 1);

            if (_taskControls.Count >= 2)
            {
                TablePanel.Controls.Add(_taskControls[_taskControls.Count - 2]);
                TablePanel.Controls.Add(_taskControls.Last());
            }
        }
        private void InitLocationForNewTask(MaterialListBox newTaskBox)
        {
            //Get last controls
            Control lastControl = _taskControls[_taskControls.Count - 1];
            //Remove addTaskButon from taskList
            _taskControls.RemoveAt(_taskControls.Count - 1);

            //Get last control location
            Point addTaskButLocation = lastControl.Location;

            //init last cont loc to new control
            newTaskBox.Location = addTaskButLocation;
            //Assign new location to add controls Box(last location)

            int lastControlXLock = newTaskBox.Location.X + newTaskBox.Width;
            UpdateTableWidth(lastControlXLock, lastControl, newTaskBox);


            int xLocForLastControl = newTaskBox.Location.X + newTaskBox.Width + _distanceBetweenTasks;
            //TablePanel.Size = new Size(xLocForLastControl + lastControl.Width + _distanceBetweenTasks, TablePanel.Height);

            lastControl.Location = new Point(xLocForLastControl, _upperBorderDistance);
            //lastControl.BringToFront();

            _taskControls.Add(newTaskBox);
            _taskControls.Add(lastControl);

            UpdateControlsInTable();
        }

        private void UpdateTableWidth(int lastControlsWidth, Control lastControl, Control newControl)
        {
            int lastPointInControlLock = lastControlsWidth + lastControl.Width;

            if (TablePanel.Width <= lastPointInControlLock)
            {
                //int differance = lastControlsWidth - TablePanel.Width;
                //Size = new Size(lastPointInControlLock + newControl.Width + _distanceBetweenTasks, Size.Height);
                //TablePanel.Size = new Size(lastPointInControlLock + newControl.Width + _distanceBetweenTasks, TablePanel.Height);
            }
            else
            {

            }
        }
        private MaterialListBox CreateTaskPanel(string taskName)
        {
            MaterialListBox taskBox = new MaterialListBox();
            //taskBox.Size = new Size(_taskBoxWidth, _taskBoxStartHeight);
            taskBox.Name = taskName;

            //Add task name
            Label name = new Label();
            name.AutoSize = true;
            name.Text = DevideStringInRows(taskName);
            name.Location = new Point(_distanceBetweenSubTasks, _distanceBetweenSubTasks);
            name.Name = _taskName;
            name.Click += RenameTask_Click;
            taskBox.Controls.Add(name);


            //Add add subTask button
            MaterialButton but = new MaterialButton();
            but.Text = "Add new subTask";
            but.Name = _addSubTaskButName;
            but.Tag = taskName;
            but.AutoSize = false;
            but.Size = new Size(_taskBoxWidth / 4 * 3, _taskBoxWidth / 10);


            taskBox.Size = new Size(_taskBoxWidth + _distanceBetweenSubTasks * 3,
            name.Height + but.Height + _distanceBetweenSubTasks * 3);

            but.Location = new Point(_distanceBetweenSubTasks, taskBox.Height - _distanceBetweenSubTasks - but.Height);

            but.Click += AddSubTask_Click;

            taskBox.Controls.Add(but);
            taskBox.AllowDrop = true;

            taskBox.MouseDown += TaskPanel_MouseDown;

            taskBox.DragOver += TaskPanel_DragOver;
            //taskBox.DragLeave += TaskPanel_DragLeave;
            taskBox.DragDrop += TaskPanel_DragDrop;
            taskBox.DragEnter += TaskPanel_DragEnter;

            return taskBox;
        }
        private Point dragStartPoint;
        private void TaskPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is MaterialListBox)) return;

            MaterialListBox box = sender as MaterialListBox;

            if (e.Button == MouseButtons.Left)
            {
                dragStartPoint = e.Location;
                box.DoDragDrop(box, DragDropEffects.Move);
            }

            if (box.DoDragDrop(box, DragDropEffects.Move) == DragDropEffects.Move)
            {
                Console.WriteLine("asd");
            }
        }
        private void TaskPanel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        private void TaskPanel_DragLeave(object sender, DragEventArgs e)
        {

        }
        private void TaskPanel_DragDrop(object sender, DragEventArgs e)
        {
            Panel panel = (Panel)e.Data.GetData(typeof(Panel));
            Point dropLocation = this.PointToClient(new Point(e.X, e.Y));
            panel.Location = new Point(dropLocation.X - dragStartPoint.X, dropLocation.Y - dragStartPoint.Y);

            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Move;
            }
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

                Control controlToRename = GetTaskControlByName(resTask.Name);
                Control taskNameLabel = GetLabelNameFromTask(controlToRename);

                RenameTask rename = new RenameTask(resTask, _table.Tasks);
                rename.ShowDialog();

                controlToRename.Name = resTask.Name;
                taskNameLabel.Text = DevideStringInRows(resTask.Name);
                ReassignButtinTag(controlToRename);

                //update control in controls list
                //Update task 
                UpdateTaskControlsLocation(controlToRename);
            }
        }

        private void UpdateTaskControlsLocation(Control task)
        {
            int taskIndex = GetTaskControlIndexByName(task.Name);
            bool check = false;

            for (int i = 0; i < _controlsInTasks[taskIndex].Count; i++)
            {
                if (check)
                {
                    _controlsInTasks[taskIndex][i].Location = new Point(_controlsInTasks[taskIndex][i].Location.X,
                         _controlsInTasks[taskIndex][i - 1].Location.Y + _controlsInTasks[taskIndex][i - 1].Height + _distanceBetweenSubTasks);
                }
                if (task.Controls[i] is Label)
                {
                    check = true;
                }
            }

            Control buttonControl = GetButtonControl(task);
            Control controlBeforeBut = _controlsInTasks[taskIndex][_controlsInTasks[taskIndex].Count - 2];


            buttonControl.Location = new Point(controlBeforeBut.Location.X,
                controlBeforeBut.Location.Y + controlBeforeBut.Height + _distanceBetweenSubTasks);

            task.Height = buttonControl.Location.Y + buttonControl.Height + _distanceBetweenSubTaskName;
        }

        private void ReassignButtinTag(Control control)
        {
            Button but = null;
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is Button)
                {
                    but = (Button)control.Controls[i];
                    break;
                }
            }
            if (but is null) return;

            but.Tag = control.Name;
        }


        private Control GetLabelNameFromTask(Control task)
        {
            for (int i = 0; i < task.Controls.Count; i++)
            {
                if (task.Controls[i] is Label)
                {
                    return task.Controls[i];
                }
            }
            return null;
        }

        private void AddSubTask_Click(object sender, EventArgs e)
        {
            CreateSubTask create = new CreateSubTask();
            create.ShowDialog();

            if (create._subTaskName == "") return;
            Control taskToAddSubTask = GetTaskTOAddSubTask(((Button)sender).Tag.ToString());
            if (taskToAddSubTask is null) return;

            Panel newSubTask = CreateSubTask(create._subTaskName, taskToAddSubTask);
            GetLocationForNewSubTask(newSubTask, taskToAddSubTask);

            //panel Location in task panel
            AddTaskInSubTaskListLits(taskToAddSubTask, newSubTask);

            //Repaint all controls int task panel
            UpdateControlsInTaskPanel(taskToAddSubTask);

            _table.AddSubTask(taskToAddSubTask.Name, create._subTaskName);
        }
        public void AddTaskInSubTaskListLits(Control task, Control subTask)
        {
            int taskIndex = GetTaskControlIndexByName(task.Name);
            if (taskIndex == -1) return;

            Control butControl = GetButtonControl(task);
            _controlsInTasks[taskIndex].RemoveAt(_controlsInTasks[taskIndex].Count - 1);

            _controlsInTasks[taskIndex].Add(subTask);
            _controlsInTasks[taskIndex].Add(butControl);


        }
        public int GetTaskControlIndexByName(string name)
        {
            for (int i = 0; i < _taskControls.Count; i++)
            {
                if (name == _taskControls[i].Name)
                {
                    return i;
                }
            }
            return -1;
        }
        public Control GetTaskControlByName(string name)
        {
            for (int i = 0; i < _taskControls.Count; i++)
            {
                if (_taskControls[i].Name == name)
                {
                    return _taskControls[i];
                }
            }
            return null;
        }
        public void UpdateControlsInTaskPanel(Control taskPanel)
        {
            taskPanel.Controls.Clear();

            List<Control> subTaskControls = _controlsInTasks[GetTaskControlIndexByName(taskPanel.Name)];

            for (int i = 0; i < subTaskControls.Count; i++)
            {
                taskPanel.Controls.Add(subTaskControls[i]);
            }
        }
        private Control GetTaskTOAddSubTask(string butTag)
        {
            for (int i = 0; i < _taskControls.Count; i++)
            {
                if (_taskControls[i].Name == butTag)
                {
                    return _taskControls[i];
                }
            }
            return null;
        }
        private Panel CreateSubTask(string subTaskName, Control taskToAddSubTask)
        {
            string deviderInRows = DevideStringInRows(subTaskName);
            int amountOfTransfers = GetTransfersAmount(deviderInRows);

            Panel subTask = new Panel();

            Label subTaskNameLb = new Label();
            subTaskNameLb.AutoSize = true;
            subTaskNameLb.Text = DevideStringInRows(subTaskName);
            subTaskNameLb.Location = new Point(_distanceBetweenSubTaskName, _distanceBetweenSubTaskName);


            subTask.AutoSize = false;
            subTask.Size = new Size(taskToAddSubTask.Width - _distanceBetweenSubTasks * 2,
                subTaskNameLb.Height * amountOfTransfers + _distanceBetweenSubTasks * 2);

            subTask.BackColor = SystemColors.ControlLight;

            subTask.Controls.Add(subTaskNameLb);

            return subTask;
        }
        private void GetLocationForNewSubTask(Panel newSubTask, Control taskToAddSubTask)
        {
            //get button (which adds new subTask)
            Control butControl = GetButtonControl(taskToAddSubTask);

            //getting Location of this button (this loc is new sbus loc)
            Point butLoc = butControl.Location;

            //Init Location for new subTask
            newSubTask.Location = butLoc;

            //count new loc for button 
            //Y - butLoc.Y, newSubTask.Height + distBetweenSubTasks 
            butControl.Location = new Point(butControl.Location.X,
                butLoc.Y + newSubTask.Height + _distanceBetweenSubTasks);

            //change size for taskPanel
            //Y - taskToAddSubTask.Height + newSubTask.Height + _distanceBetweenSubTasks
            taskToAddSubTask.Size = new Size(taskToAddSubTask.Width,
                taskToAddSubTask.Height + newSubTask.Height + _distanceBetweenSubTasks);
        }
        private Control GetButtonControl(Control taskControl)
        {
            for (int i = 0; i < taskControl.Controls.Count; i++)
            {
                if (taskControl.Controls[i] is Button)
                {
                    return taskControl.Controls[i];
                }
            }
            return null;
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
            const int charsInRow = 15;
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
