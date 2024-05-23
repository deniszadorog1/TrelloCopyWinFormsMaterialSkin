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

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class CorrectComment : MaterialForm
    {
        public Comment _comment;
        public CorrectComment(Comment comment)
        {
            if (comment is null) throw new Exception("comment value is null!");
            _comment = comment;

            InitializeComponent();

            EnterDefaultParams();
        }
        private void EnterDefaultParams()
        {
            CommentBox.Text = _comment.Value;
        }
        private void CorrectBut_Click(object sender, EventArgs e)
        {
            if(CommentBox.Text == "")
            {
                MessageBox.Show("Smth went wrong!", "mistake!");
                return;
            }
            _comment.Value = CommentBox.Text;
            Close();
        }
        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
