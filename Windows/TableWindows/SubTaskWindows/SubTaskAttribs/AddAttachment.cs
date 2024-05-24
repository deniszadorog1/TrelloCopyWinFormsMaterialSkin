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
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class AddAttachment : MaterialForm
    {
        private Table _table;
        private SubTask _chosenSubTask;
        private TableTask _task;
        private Attachment _newAttachment;

        private List<SubTask> _listWithoutChosen = new List<SubTask>();

        public AddAttachment(Table table, SubTask subTask, TableTask task)
        {
            _table = table;
            _chosenSubTask = subTask;
            _task = task;

            InitializeComponent();
            FillParams();
        }
        public void FillParams()
        {
            for (int i = 0; i < _table.Tasks.Count; i++)
            {
                TaskBox.Items.Add(_table.Tasks[i].Name);
            }
            TaskBox.TextChanged += TaskChosen_TextChanged;
        }
        private void TaskChosen_TextChanged(object sender, EventArgs e)
        {
            InitSubTaskListWithoutChosenList();
            FillSubTasks();
        }
        private void FillSubTasks()
        {
            SubTaskBox.Items.Clear();

            for (int i = 0; i < _listWithoutChosen.Count; i++)
            {
                SubTaskBox.Items.Add(_listWithoutChosen[i].Name);
            }
        }
        private void InitSubTaskListWithoutChosenList()
        {
            _listWithoutChosen.Clear();

            //Get chosen task
            TableTask chosenTask = _table.Tasks[TaskBox.SelectedIndex];

            //init every subTask except temp subTask
            for (int i = 0; i < chosenTask.SubTasks.Count; i++)
            {
                if (chosenTask.SubTasks[i].Name != _chosenSubTask.Name &&
                    chosenTask.SubTasks[i].UniqueIndex != _chosenSubTask.UniqueIndex)
                {
                    _listWithoutChosen.Add(chosenTask.SubTasks[i]);
                }
            }
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            if (SignBox.Text == string.Empty ||
                TaskBox.Text == string.Empty ||
                SubTaskBox.Text == string.Empty)
            {
                MessageBox.Show("Smth went wrong!", "Mistake!");
                return;
            }
            _newAttachment = new Attachment(_listWithoutChosen[SubTaskBox.SelectedIndex].GlobalSubTaskIndex, SignBox.Text, _chosenSubTask.Attachments.Count);
            _table.LastSubTaskIndex++;
            _chosenSubTask.Attachments.Add(_newAttachment);

            Close();
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
