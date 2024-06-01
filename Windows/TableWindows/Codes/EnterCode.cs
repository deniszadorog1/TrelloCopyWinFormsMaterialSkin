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

namespace TrelloCopyWinForms.Windows.TableWindows.Codes
{
    public partial class EnterCode : MaterialForm
    {
        public Table _table = null;
        private User _user;
        public EnterCode(User user)
        {
            _user = user;
            InitializeComponent();
        }

        private void EnterCodeBut_Click(object sender, EventArgs e)
        {
            if(CodeBox.Text == "" || !DBUsage.IfCodeExist(CodeBox.Text)) 
            {
                MessageBox.Show("No such code");
                return;
            }            
            
            _table = DBUsage.GetTableByCode(CodeBox.Text);

            if(DBUsage.IfUserContainsInTable(_table.Id, _user.Id))
            {
                _table = null;
                MessageBox.Show("User is already contains in this table");
                return;
            }

            DBUsage.InsertUserTables(_table, _user, DBUsage.GetTypeByCode(CodeBox.Text));

        }

        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
