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

        private MaterialButton _addTaskBut = new MaterialButton();
        private const string _addTaskButName = "AddTaskBut";

        private const int _taskBoxWidth = 250;
        private const int _taskBoxStartHeight = 150;

        private const int _upperBorderDistance = 10;
        private const int _distanceBetweenTasks = 10;

        private const int _distanceBetweenSubTasks = 10;

        private const string _addSubTaskButName = "AddSubTask";
        private const string _taskName = "TaskName";


        //private TransparentFlowLayoutPanel TablePanel = new TransparentFlowLayoutPanel();

        public TableWindow(Table table)
        {
            _table = table;
            InitializeComponent();

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

            if (!(create._task is null))
            {
                AddNewTaskBoxInTable(create.Name);
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
            taskBox.Size = new Size(_taskBoxWidth, _taskBoxStartHeight);
            taskBox.Name = taskName;

            //Add task name
            MaterialLabel name = new MaterialLabel();
            name.Text = taskName;
            name.Location = new Point(_distanceBetweenSubTasks, _distanceBetweenSubTasks);
            name.Name = _taskName;
            taskBox.Controls.Add(name);


            //Add add subTask button
            MaterialButton but = new MaterialButton();
            but.Text = "Add new subTask";
            but.Name = _addSubTaskButName;
            but.AutoSize = false;
            but.Size = new Size(_taskBoxWidth / 4 * 3, _taskBoxWidth / 10);
            but.Location = new Point(_distanceBetweenSubTasks, taskBox.Height - _distanceBetweenSubTasks - but.Height);
            taskBox.Controls.Add(but);

            return taskBox;
        }

        private void AddSubTask_Click(object sender, EventArgs e)
        {
            CreateSubTask create = new CreateSubTask();
            create.ShowDialog();

            if(create._subTaskName != "")
            {

            }
        }

        private void CreateSubTask(string subTaskName)
        {
            Panel subTask = new Panel();
            string deviderInRows = DivideStringInRows(subTaskName);
            
            

            

        }

        private string DivideStringInRows(string row)
        {
            const int charsInRow = 10;
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
