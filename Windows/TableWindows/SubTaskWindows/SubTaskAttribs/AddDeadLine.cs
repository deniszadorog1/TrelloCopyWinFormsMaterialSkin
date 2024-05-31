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

using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;
using TrelloCopyWinForms.Models.TableModels;
using TrelloCopyWinForms.Models.DataBase;

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class AddDeadLine : MaterialForm
    {
        public DeadLineDate _deadLine = new DeadLineDate();
        private SubTask _subTask;
        public AddDeadLine(SubTask subTask)
        {
            _subTask = subTask;
            InitializeComponent();
        }
        public AddDeadLine(DeadLineDate deadLine)
        {
            _deadLine = deadLine;
            InitializeComponent();
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            DateTime start = StartDatePicker.Value;
            DateTime end = EndDatePicker.Value;

            string startDate = start.ToString();
            string endDate = end.ToString();

            if (!EndDateCheckBox.Checked)
            {
                MessageBox.Show("Smth went wrong!", "Mistake!");
                return;
            }
            if (StartDateBox.Checked)
            {
                _deadLine.StartDate = start;
                _deadLine.PrintString = startDate + " - ";
            }
            _deadLine.EndDate = end;
            _deadLine.PrintString += endDate;

            _subTask.DeadLine = _deadLine;
            DBUsage.UpdateSubTask(_subTask);

            Close();
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            _deadLine = null;
            _subTask.DeadLine = null;
            DBUsage.UpdateSubTask(_subTask);

            Close();
        }
    }
}
