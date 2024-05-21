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
    public partial class AddCase : MaterialForm
    {
        public SubTask _subTask;
        public CheckListModel _checkList;
        public AddCase(SubTask subTask, CheckListModel checkList)
        {
            _subTask = subTask;
            _checkList = checkList;

            InitializeComponent();
        }
        private void AddBut_Click(object sender, EventArgs e)
        {
            if(CaseNameBox.Text == "" || 
                _subTask.IfCaseInCheckListIsExist(_checkList.Name, CaseNameBox.Text))
            {
                MessageBox.Show("Smth went wrong!", "Mistake!");
                return;
            }
            _checkList.Cases.Add(new CheckListCase(CaseNameBox.Text));
            Close();
        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
