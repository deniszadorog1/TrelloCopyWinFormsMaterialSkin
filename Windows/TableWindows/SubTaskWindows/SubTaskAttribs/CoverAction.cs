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
using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class CoverAction : MaterialForm
    {
        private SubTask _subTask;
        public CoverAction(SubTask subTask)
        {
            _subTask = subTask;
            InitializeComponent();
            InitDefaultParams();
        }
        public void InitDefaultParams()
        {
            FullSizeTypeRadio.Checked = false;
            PartSizeRadio.Checked = false;
            if (_subTask is null || _subTask.Cover is null) return;
            if(!(_subTask.Cover.BGColor is null))
            {
                BgColorPanel.BackColor = (Color)_subTask.Cover.BGColor;
            }
            if(!(_subTask.Cover.Type is null))
            {
                if(_subTask.Cover.Type == CoverType.FullSizeCover)
                {
                    FullSizeTypeRadio.Checked = true;
                }
                else
                {
                    PartSizeRadio.Checked = true;
                }
            }
        }
        private void BackBut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddColorBut_Click(object sender, EventArgs e)
        {
            ChooseColor.ShowDialog();
            BgColorPanel.BackColor = ChooseColor.Color;
            _subTask.Cover = new Cover(ChooseColor.Color);
            _subTask.Cover.Type = FullSizeTypeRadio.Checked ? CoverType.FullSizeCover : CoverType.PartSizeCover;
        }

        private void ClearCoverBut_Click(object sender, EventArgs e)
        {
            BgColorPanel.BackColor = SystemColors.Control;
            _subTask.Cover = null;
            MessageBox.Show("Cleared!", "Success");
        }
    }
}
