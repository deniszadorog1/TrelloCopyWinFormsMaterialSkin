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
        private void TaskPanel_DragLeave(object sender, DragEventArgs e)
        {

        }
        private void TaskPanel_DragDrop(object sender, DragEventArgs e)
        {
            //if sender is Panel(subTask) //handle 

            if (!((Panel)e.Data.GetData(typeof(Panel)) is null))
            {
                Panel subTaskPan = (Panel)e.Data.GetData(typeof(Panel));
                Point dropLocation = ((MaterialListBox)sender).PointToClient(new Point(e.X, e.Y));

                
                
                SubTaskeMoved(subTaskPan, dropLocation, (MaterialListBox)sender);
                return;
            }


            //if Panel dropped on anouther Panel => swap them
            //sender - place(or control) where we dropped
            MaterialListBox panel = (MaterialListBox)e.Data.GetData(typeof(MaterialListBox)); //that was dragged

            if (panel is null) return;

            //Point dropLocation = this.PointToClient(new Point(e.X, e.Y));
            //Point newPoint = new Point(dropLocation.X - dragStartPoint.X, dropLocation.Y - dragStartPoint.Y);  
            //panel.Location = newPoint;

            SwapLocsForControls(panel, (MaterialListBox)sender);
            SwapTasksInTaskList(panel, (MaterialListBox)sender);
            SwapControlsInTasksList(panel, (MaterialListBox)sender);

            UpdateTable();
        }
        private void SubTaskeMoved(Panel toMove, Point cordWherePanelDroped, MaterialListBox taskWhereWasDropped)
        {
            //Get table where we are dragged from 
            Control tablePanelGettingFrom = toMove.Parent;


            //Get list with conrols of where we are dragging (from list controls)
            int tableIndexGettingFrom = GetTaskControlIndexByName(tablePanelGettingFrom.Name);
            List<Control> subTasksGettingSubFrom = _controlsInTasks[tableIndexGettingFrom];

            //Get list with conrols of where we are dragging into (into list controls)
            int tableIndexIndsertingInto = GetTaskControlIndexByName(taskWhereWasDropped.Name);
            List<Control> subTasksInsertingSubInto = _controlsInTasks[tableIndexIndsertingInto];

            //Remove from list (table + list getting from)
            RemoveSubtask(toMove, (MaterialListBox)tablePanelGettingFrom, tableIndexGettingFrom);

            //Insert into list(table + list inserting into)
            InsertSubTaskIntoNewTask(toMove, taskWhereWasDropped, tableIndexIndsertingInto, cordWherePanelDroped);

            UpdateTaskControlsLocation(tablePanelGettingFrom);
            UpdateTaskControlsLocation(taskWhereWasDropped);



            UpdateControlsInTable();
        }
        private void UpdateTable()
        {
            TablePanel.Controls.Clear();

            for (int i = 0; i < _taskControls.Count; i++)
            {
                TablePanel.Controls.Add(_taskControls[i]);
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
        private void SwapControlsInTasksList(Control first, Control second)
        {
            int firstTaskIndex = GetTaskControlIndexByName(first.Name);
            int secondTaskIndex = GetTaskControlIndexByName(second.Name);

            List<Control> firstControls = _controlsInTasks[firstTaskIndex];

            _controlsInTasks[firstTaskIndex] = _controlsInTasks[secondTaskIndex];
            _controlsInTasks[secondTaskIndex] = firstControls;
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

            List<Control> controls = _controlsInTasks[taskIndex];

            for (int i = 0; i < controls.Count; i++)
            {
                if (check)
                {
                    controls[i].Location = new Point(controls[i].Location.X, 0);
                    controls[i].Location = new Point(controls[i].Location.X,
                        controls[i - 1].Location.Y + controls[i - 1].Height + _distanceBetweenSubTasks);
                }
                if (task.Controls[i] is Label)
                {
                    check = true;
                }
            }

            Control buttonControl = GetButtonControl(task);
            Control controlBeforeBut = controls[controls.Count - 2];

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

            _table.AddSubTask(taskToAddSubTask.Name, create._subTaskName);

            Panel newSubTask = CreateSubTask(create._subTaskName, taskToAddSubTask);
            newSubTask.Tag = _table.GetUniqueNumForLastSubTask(taskToAddSubTask.Name);

            newSubTask.MouseDown += SubTask_MouseDown;
            newSubTask.DragOver += SubTask_DragOver;
            newSubTask.DragEnter += SubTask_DragEnter;
            newSubTask.DragLeave += SubTask_DragLeave;
            newSubTask.DragDrop += SubTask_DragDrop;

            newSubTask.Click += (snederObj, clickEventArg) => 
            {
                MessageBox.Show("Sub task message!");

                SubTaskMenu subTaskMenu = new SubTaskMenu(_table.GetSubTask(taskToAddSubTask.Name, create._subTaskName), _table, _table.GetTaskByName(taskToAddSubTask.Name));
                subTaskMenu.ShowDialog();
            };

            GetLocationForNewSubTask(newSubTask, taskToAddSubTask);

            //panel Location in task panel
            AddTaskInSubTaskListLits(taskToAddSubTask, newSubTask);

            //Repaint all controls int task panel
            UpdateControlsInTaskPanel(taskToAddSubTask);

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
            //sender - place(or control) where we dropped
            Panel panel = (Panel)e.Data.GetData(typeof(Panel)); //that was dragged
            Point dropLocation = this.PointToClient(new Point(e.X, e.Y));
            //Point newPoint = new Point(dropLocation.X - dragStartPoint.X, dropLocation.Y - dragStartPoint.Y);  
            //panel.Location = newPoint;

            //Get table where we are dragged from 
            Control tablePanelGettingFrom = ((Panel)panel).Parent;

            //Get table where we dragging into 
            Control tablePanelInsertingInto = ((Panel)sender).Parent;

            

            //Get list with conrols of where we are dragging (from list controls)
            int tableIndexGettingFrom = GetTaskControlIndexByName(tablePanelGettingFrom.Name);
            List<Control> subTasksGettingSubFrom = _controlsInTasks[tableIndexGettingFrom];

            //Get list with conrols of where we are dragging into (into list controls)
            int tableIndexIndsertingInto = GetTaskControlIndexByName(tablePanelInsertingInto.Name);
            List<Control> subTasksInsertingSubInto = _controlsInTasks[tableIndexIndsertingInto];


            //Remove from list (table + list getting from)
            RemoveSubtask(panel, (MaterialListBox)tablePanelGettingFrom, tableIndexGettingFrom);

            //Insert into list(table + list inserting into)
            InsertSubTaskIntoNewTask(panel, (MaterialListBox)tablePanelInsertingInto, tableIndexIndsertingInto, dropLocation);

            /*            SwapLocsForControls(panel, (Panel)sender);
                        SwapTasksInTaskList(panel, (Panel)sender);
            */
            UpdateControlsInTable();
        }



        private void InsertSubTaskIntoNewTask(Panel subTask, MaterialListBox taskBox, int taskIndex, Point dropLoc)
        {
            List<Control> taskControls = _controlsInTasks[taskIndex];
            bool check = false;

            for (int i = 0; i < taskControls.Count; i++)
            {
                if (!(taskControls[i] is Button) &&
                    !(taskControls[i] is Label) &&
                    !(taskControls[i] is MaterialScrollBar))
                {
                    if (dropLoc.Y < taskControls[i].Location.Y)
                    {
                        taskControls.Insert(i, subTask);
                        check = true;
                        break;
                    }
                }
            }
            if (!check)
            {
                GetLocationForNewSubTask(subTask, taskBox);
                taskControls.Insert(taskControls.Count - 1, subTask);

                //InsertButAt th end
            }
            
            ApdateRaskControlsUnqueIndexes(taskControls, taskIndex);

            UpdateControlsInTaskPanel(taskBox);
        }
        private void ApdateRaskControlsUnqueIndexes(List<Control> controls, int taskIndex)
        {
            int count = 0;
            for(int i = 0; i < controls.Count; i++)
            {
                if (controls[i] is Panel)
                {
                    controls[i] = controls[i];
                    count++;
                }
            }
            //Updaate in subTasks Logic
            _table.UpdateSubTasksIndexes(taskIndex);
        }


        private void RemoveSubtask(Panel subtask, MaterialListBox taskBox, int taskIndex)
        {
            for (int i = 0; i < _controlsInTasks[taskIndex].Count; i++)
            {
                if (subtask.Name == _controlsInTasks[taskIndex][i].Name && 
                    subtask.Tag == _controlsInTasks[taskIndex][i].Tag)
                {
                    _controlsInTasks[taskIndex].RemoveAt(i);
                    break;
                }
            }
            UpdateControlsInTaskPanel(taskBox);
        }

        public void AddTaskInSubTaskListLits(Control task, Control subTask)
        {
            int taskIndex = GetTaskControlIndexByName(task.Name);
            if (taskIndex == -1) return;

            //List<(Control, int)> list = _controlsInTasks[taskIndex];

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
        public void UpdateTask(Control task)
        {
            int taskIndex = GetTaskControlIndexByName(task.Name);
            TablePanel.Controls.RemoveAt(taskIndex);

            TablePanel.Controls.Add(task);
        }
        public void UpdateControlsInTaskPanel(Control taskPanel)
        {
            taskPanel.Controls.Clear();

            List<Control> subTaskControls = _controlsInTasks[GetTaskControlIndexByName(taskPanel.Name)];

            for (int i = 0; i < subTaskControls.Count; i++)
            {
                taskPanel.Controls.Add(subTaskControls[i]);
                taskPanel.Controls[taskPanel.Controls.Count - 1].Tag = subTaskControls[i].Tag;
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

            subTask.Name = subTaskName;

            Label subTaskNameLb = new Label();
            subTaskNameLb.AutoSize = true;
            subTaskNameLb.Text = DevideStringInRows(subTaskName);
            subTaskNameLb.Location = new Point(_distanceBetweenSubTaskName, _distanceBetweenSubTaskName);

            subTask.AutoSize = false;
            subTask.Size = new Size(taskToAddSubTask.Width - _distanceBetweenSubTasks * 2,
                subTaskNameLb.Height * amountOfTransfers + _distanceBetweenSubTasks * 2);

            subTask.BackColor = SystemColors.ControlLight;

            subTask.Controls.Add(subTaskNameLb);

            subTask.MouseEnter += SubTask_MouseEnter;
            subTask.MouseLeave += SubTask_MouseLeave;

            return subTask;
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
                subTask.BorderStyle = BorderStyle.None;
            }
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
        public void SwapTasksInTaskList(Control first, Control second)
        {
            int firstControl = GetTaskControlIndexByName(first.Name);
            int secondControl = GetTaskControlIndexByName(second.Name);

            MaterialListBox temp = (MaterialListBox)_taskControls[secondControl];

            _taskControls[secondControl] = _taskControls[firstControl];
            _taskControls[firstControl] = temp;

            //int firstAfterIndex = GetTaskControlIndexByName(first.Name);
            //int secondAfterIndex = GetTaskControlIndexByName(second.Name);

            // Console.WriteLine();
        }
        public void SwapLocsForControls(Control first, Control second)
        {
            Point temp = first.Location;

            first.Location = second.Location;
            second.Location = temp;
        }

        private void BGImage_Click(object sender, EventArgs e)
        {

        }
    }
}
