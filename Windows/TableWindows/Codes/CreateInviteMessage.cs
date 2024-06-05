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
using TrelloCopyWinForms.Models.Enums;
using TrelloCopyWinForms.Models.DataBase;

namespace TrelloCopyWinForms.Windows.TableWindows
{
    public partial class CreateInviteMessage : MaterialForm
    {
        Table _table;
        public CreateInviteMessage(Table table)
        {
            _table = table;
            InitializeComponent();

            FillTypeBox();
            CopyCodeInStrip();
        }
        private void FillTypeBox()
        {
            TypeBox.Items.Add("Usualuser");
            TypeBox.Items.Add("Viewer");
        }
        private void CopyCodeInStrip()
        {
            CopyCode.Items[0].Click += CopyCodeInBuffer;
        }
        private void CopyCodeInBuffer(object sender, EventArgs e)
        {
            Clipboard.SetText(CodeBox.Text);
        }
        private void GenerateCodeBut_Click(object sender, EventArgs e)
        {
            if(TypeBox.Text == string.Empty)
            {
                MessageBox.Show("Wrong type!", "Mistake!");
                return;
            }

            string newCode = Guid.NewGuid().ToString();

            CodeBox.Text = newCode;

            DBUsage.DeleteCodesInTable(_table.Id);
            DBUsage.AddCodeToAddUser(_table.Id, newCode, GetAccType());
        }
        public AccountType GetAccType()
        {
            for(int i = 0; i <= (int)AccountType.Viewer; i++)
            {
                if(TypeBox.Text == ((AccountType)i).ToString())
                {
                    return (AccountType)i;
                }
            }
            return AccountType.Viewer;
        }
    }
}
