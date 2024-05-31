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
using TrelloCopyWinForms.Models.DataBase;

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class ParticipantsAction : MaterialForm
    {
        private Table _table;
        private SubTask _subTask;

        private List<int> _usersIndexesToAdd = new List<int>();
        public ParticipantsAction(SubTask subTask, Table table)
        {
            _table = table;
            _subTask = subTask;

            InitializeComponent();

            FillBoxes();
        }

        public void FillBoxes()
        {
            UsersInSubTaskBox.Items.Clear();
            for (int i = 0; i < _subTask.UsersIdsInSuBTask.Count; i++)
            {
                UsersInSubTaskBox.Items.Add(_table.GetUserLoginById(_subTask.UsersIdsInSuBTask[i]));
            }

            _usersIndexesToAdd.Clear();
            UsersToAddBox.Items.Clear();
            for (int i = 0; i < _table.UserInTable.Count; i++)
            {
                if (!_subTask.UsersIdsInSuBTask.Contains(_table.UserInTable[i].Id))
                {
                    UsersToAddBox.Items.Add(_table.UserInTable[i].Login);
                    _usersIndexesToAdd.Add(_table.UserInTable[i].Id);
                }
            }
        }
        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void RemoveBut_Click(object sender, EventArgs e)
        {
            if (UsersInSubTaskBox.Text == string.Empty)
            {
                MessageBox.Show("Nothing to delete!", "Mistake!");
                return;
            }
            DBUsage.DeleteFromUserSubTask(_subTask.UsersIdsInSuBTask[UsersInSubTaskBox.SelectedIndex], _subTask);

            _subTask.UsersIdsInSuBTask.Remove(_subTask.UsersIdsInSuBTask.Find(x => x ==
            _subTask.UsersIdsInSuBTask[UsersInSubTaskBox.SelectedIndex]));

            FillBoxes();
            UsersInSubTaskBox.Text = string.Empty;
            UsersInSubTaskBox.SelectedItem = null;
        }
        private void AddBut_Click(object sender, EventArgs e)
        {
            if (UsersToAddBox.Text == string.Empty)
            {
                MessageBox.Show("Nothing to add!", "Mistake!");
                return;
            }
            _subTask.UsersIdsInSuBTask.Add(_usersIndexesToAdd[UsersToAddBox.SelectedIndex]);

            DBUsage.InsertUserSubTask(_usersIndexesToAdd[UsersToAddBox.SelectedIndex], _subTask);

            FillBoxes();
            UsersToAddBox.Text = string.Empty;
            UsersToAddBox.SelectedItem = null;
            
        }
    }
}
