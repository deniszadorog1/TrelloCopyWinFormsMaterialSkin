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

namespace TrelloCopyWinForms.Windows.TableWindows.CreateTaskWindow
{
    public partial class CreateTask : MaterialForm 
    {
        public TableTask _task = null;
        public CreateTask()
        {
            InitializeComponent();
        }
        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void AddTaskBut_Click(object sender, EventArgs e)
        {
            if(TaskNameBox.Text == "")
            {
                MessageBox.Show("Cant be add!", "Mistake!");
                return;
            }
            _task = new TableTask(TaskNameBox.Text, new List<SubTask>());
            Close();
        }
    }
}
