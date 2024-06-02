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

using TrelloCopyWinForms.Models.DataBase;
using TrelloCopyWinForms.Models.TableModels;
using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Models.Enums;

namespace TrelloCopyWinForms.Windows.TableWindows
{
    public partial class DeleteUsersFromTable : MaterialForm
    {
        private Table _table;
        public DeleteUsersFromTable(Table table)
        {
            _table = table;
            InitializeComponent();

            FillUsersBox();
        }
        private void FillUsersBox()
        {
            UsersBox.Items.Clear();
            for (int i = 0; i < _table.UserInTable.Count; i++)
            {
                UsersBox.Items.Add(_table.UserInTable[i].Login);
            }
        }
        private void DeleteUserBut_Click(object sender, EventArgs e)
        {
            if (UsersBox.SelectedIndex == -1) return;
            User toDelete = _table.UserInTable[UsersBox.SelectedIndex];

            toDelete.Type =  DBUsage.InitUserTypeToUser(toDelete.Id, _table.Id);


            if (toDelete.Type == AccountType.Admin && _table.UserInTable.Count > 1)
            {
                DBUsage.DeleteUserFromUsersTable(toDelete.Id, _table.Id);
                DBUsage.MakeUserAnAdminInTable(_table.Id);


                MessageBox.Show("Deleted!");
                DBUsage.MakeUserAnAdminInTable(_table.Id);

            }
            else if (toDelete.Type == AccountType.Admin && _table.UserInTable.Count == 1)
            {
                DBUsage.MakeTableInActive(_table.Id);
                DBUsage.DeleteUserFromUsersTable(toDelete.Id, _table.Id);
                MessageBox.Show("Deleted!");
            }
            else
            {
                DBUsage.DeleteUserFromUsersTable(toDelete.Id, _table.Id);
                MessageBox.Show("Deleted!");
            }
            _table.UserInTable = DBUsage.GetUsersForTable(_table.Id);
            FillUsersBox();
        }
        private void BuckBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
