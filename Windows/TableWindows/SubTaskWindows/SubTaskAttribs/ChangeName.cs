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

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class ChangeName : MaterialForm
    {
        private SubTask _subTask;
        public ChangeName(SubTask subTask)
        {
            _subTask = subTask;
            InitializeComponent();

            InitBaseParams();
        }
        public void InitBaseParams()
        {
            SubTaskNameBox.Text = _subTask.Name;
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitBut_Click(object sender, EventArgs e)
        {
            if(SubTaskNameBox.Text == string.Empty)
            {
                MessageBox.Show("Something went wrong!", "Mistake!");
                return;
            }
            _subTask.Name = SubTaskNameBox.Text;
            Close();
        }
    }
}
