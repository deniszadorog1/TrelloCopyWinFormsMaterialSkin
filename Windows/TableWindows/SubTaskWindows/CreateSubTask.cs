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


namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows
{
    public partial class CreateSubTask : MaterialForm
    {
        public string _subTaskName = "";
    
        public CreateSubTask()
        {
            InitializeComponent();
        }

        private void CreateBut_Click(object sender, EventArgs e)
        {
            if(NameBox.Text == "")
            {
                MessageBox.Show("Cant be add!", "Mistake!");
                return;
            }
            _subTaskName = NameBox.Text;
            Close();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
