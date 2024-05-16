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
    public partial class RenameTask : MaterialForm
    {
        public TableTask _task;
        private List<TableTask> _allTasks;
        public RenameTask(TableTask taskToRename, List<TableTask> allTasks)
        {
            _task = taskToRename;
            _allTasks = allTasks;
            InitializeComponent();

            NameBox.Text = taskToRename.Name;
        }

        private void RenameBut_Click(object sender, EventArgs e)
        {
            if(NameBox.Text == string.Empty &&
                _allTasks.Any(x => x.Name == NameBox.Text))
            {
                MessageBox.Show("Mistake!", "Smth went wrong!", MessageBoxButtons.OK);
                return;
            }
            _task.Name = NameBox.Text;
            Close();
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
