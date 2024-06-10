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
    public partial class AddSubTaskFlag : MaterialForm
    {
        SubTask _subTask;

        Flag _toChangeFlag;
        Table _table;
        private const string _addColorText = "Add Color in List";
        private const string _correctColorText = "Correct color";
        public AddSubTaskFlag(SubTask subTask, Table table)
        {
            _subTask = subTask;
            _table = table;
            InitializeComponent();

            InitBaseParams();
        }
        public void InitBaseParams()
        {
            ChoseColor.Color = Color.Empty;
            FillColorsBox();
        }
        public void FillColorsBox()
        {
            ColorsBox.Controls.Clear();
            Point loc = new Point();
            const int _distanceBetweenFlags = 5;
            const int checkArgbA = 255; 
            const int checkArgbR = 64; 
            const int checkArgbG = 0; 
            const int checkArgbB = 64; 
            for (int i = 0; i < _table._allFlags.Count; i++)
            {
                if (_table._allFlags[i].ForColor == Color.FromArgb(checkArgbA, checkArgbR, checkArgbG, checkArgbB))
                {
                    _table._allFlags[i].ForColor = Color.White;
                }
                Panel colorPanel = CreateColorPanel(_table._allFlags[i].FlagColor, _table._allFlags[i].FlagTag, i, _table._allFlags[i].ForColor);
                colorPanel.Location = loc;

                ColorsBox.Controls.Add(colorPanel);
                loc = new Point(loc.X, loc.Y + colorPanel.Height + _distanceBetweenFlags);
            }
            for (int i = 0; i < ColorsBox.Controls.Count; i++)
            {
                if (ColorsBox.Controls[i] is Panel)
                {
                    CheckBox box = GetCheckBoxFromControl(ColorsBox.Controls[i]);
                    if (!(box is null))
                    {
                        box.CheckedChanged += (sender, e) =>
                        {
                            UpdateSubTaskFlags();
                        };
                    }
                }
            }
        }
        private Panel CreateColorPanel(Color newColor, string text, int tag, Color textColor)
        {
            const int checkBoxXDistance = 10;
            const int distanceBetweenControls = 20;
            const int colorPanelHeight = 50;
            const int checkBoxSizeParam = 15;
            Size flagCheckBoxSize = new Size(checkBoxSizeParam, checkBoxSizeParam);
            const int colorPanelXDistMultiplier = 3;

            Panel colorPanel = new Panel();

            colorPanel.AutoSize = false;
            colorPanel.Size = new Size(ColorsBox.Width - checkBoxXDistance * colorPanelXDistMultiplier, colorPanelHeight);

            colorPanel.BorderStyle = BorderStyle.FixedSingle;
            colorPanel.Tag = tag;// newColor;

            CheckBox check = new CheckBox();
            check.Text = string.Empty;
            check.Size = flagCheckBoxSize;
            check.Location = new Point(checkBoxXDistance, colorPanel.Height / 2 - check.Height / 2);

            check.Checked = _subTask.Flags.Any(x => x.FlagColor == newColor && x.FlagTag == text);
            check.CheckedChanged += AddFlag_CheckChanged;

            colorPanel.Controls.Add(check);

            Panel color = new Panel();
            color.BackColor = newColor;
            color.Size = new Size(colorPanel.Width - check.Width - checkBoxXDistance - distanceBetweenControls, colorPanel.Height / 2);
            color.Location = new Point(colorPanel.Width - color.Width - distanceBetweenControls, colorPanel.Height / 2 - color.Height / 2);

            color.Click += CorrectColor_Click;

            Label colorText = new Label();
            colorText.Text = text;
            colorText.TextAlign = ContentAlignment.MiddleCenter;
            colorText.ForeColor = textColor;

            color.Controls.Add(colorText);
            colorPanel.Controls.Add(color);

            return colorPanel;
        }
        private void AddFlag_CheckChanged(object sender, EventArgs e)
        {
            Panel colorPanel = (Panel)((CheckBox)sender).Parent;
            Flag flag = _table._allFlags[(int)colorPanel.Tag];
            if (((CheckBox)sender).Checked)
            {
                DBUsage.InsertSubTaskTag(_subTask, flag);
                return;
            }
            DBUsage.DeleteTagFromSubTask(_subTask, flag);
        }
        private void CorrectColor_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel)
            {
                ColorAction.Text = _correctColorText;
                ColorAction.Invalidate();

                ChosenColorBox.BackColor = panel.BackColor;
                ChoseColor.Color = panel.BackColor;

                Label lb = GetLabelFromControl(panel);
                TagNameBox.Text = lb.Text;

                _toChangeFlag = IfFlagParamsIsExist();
            }
        }
        private void UpdateSubTaskFlags()
        {
            _subTask.Flags.Clear();

            for (int i = 0; i < ColorsBox.Controls.Count; i++)
            {
                if (ColorsBox.Controls[i] is Panel)
                {
                    CheckBox box = GetCheckBoxFromControl(ColorsBox.Controls[i]);
                    if (box.Checked)
                    {
                        Flag flagToAdd = GetFlag(ColorsBox.Controls[i]);

                        if (!(flagToAdd is null))
                        {
                            _subTask.Flags.Add(flagToAdd);
                        }
                    }
                }
            }
        }
        private Flag GetFlag(Control control)
        {
            Panel colorPanel = GetPanelFromCotorl(control);
            Label colorTagLb = GetLabelFromControl(colorPanel);
            string tag = colorTagLb is null ? string.Empty : colorTagLb.Text;

            return GetFlagByParams(colorPanel.BackColor, tag);
        }
        private void BackBut_Click(object sender, EventArgs e)
        {
            UpdateSubTaskFlags();

            Close();
        }
        private void AddColorInListBut_Click(object sender, EventArgs e)
        {
            if (ColorAction.Text == _correctColorText)
            {
                if (ChoseColor.Color == Color.Empty ||
                    ChoseColor.Color == Color.Black ||
                    !(IfFlagParamsIsExist() is null))
                {
                    MessageBox.Show("Smth went wrong", "Mistake!");
                    return;
                }

                _toChangeFlag.FlagColor = ChoseColor.Color;
                _toChangeFlag.FlagTag = TagNameBox.Text;
                _toChangeFlag.ForColor = GetColorForTableName(ChoseColor.Color);

                ChoseColor.Color = Color.Empty;
                TagNameBox.Text = string.Empty;

                ColorAction.Text = _addColorText;

                FillColorsBox();
                return;
            }

            //Check if Color is Empty
            ChosenColorBox.BackColor = SystemColors.Control;
            if (ChoseColor.Color == Color.Empty || ChoseColor.Color == Color.Black)
            {
                MessageBox.Show("Smth went wrong!", "Mistake");

                return;
            }
            if (IfFlagColorIsAlreadyExist(ChoseColor.Color, TagNameBox.Text))
            {
                return;
            }



            DBUsage.InsertColor(ChoseColor.Color.R, ChoseColor.Color.G, ChoseColor.Color.B);
            Flag newFlag = new Flag(ChoseColor.Color, TagNameBox.Text);
            DBUsage.InsertTags(_table, newFlag);
            newFlag.Id = DBUsage.GetTagLastId();

            newFlag.ForColor = GetColorForTableName(ChoseColor.Color);


            _table._allFlags.Add(newFlag);

            FillColorsBox();

            ChoseColor.Color = Color.Empty;
            TagNameBox.Text = string.Empty;
        }

        public Color GetColorForTableName(Color bgColor)
        {
            const double lumCorrection = 0.05;
            double bgLuminance = GetLuminance(bgColor);
            Color black = Color.Black;
            Color white = Color.White;
            double blackLuminance = GetLuminance(black);
            double whiteLuminance = GetLuminance(white);
            double blackContrast = (Math.Max(bgLuminance, blackLuminance) + lumCorrection) /
                (Math.Min(bgLuminance, blackLuminance) + lumCorrection);
            double whiteContrast = (Math.Max(bgLuminance, whiteLuminance) + lumCorrection) /
                (Math.Min(bgLuminance, whiteLuminance) + lumCorrection);

            return (blackContrast > whiteContrast) ? black : white;
        }
        public double GetLuminance(Color color)
        {
            const double maxColorValue = 255.0;

            const double rReturnParamMultipilier = 0.2126;
            const double gReturnParamMultipilier = 0.7152;
            const double bReturnParamMultipilier = 0.0722;

            const double comparationParam = 0.03928;
            const double trueParamDevider = 12.92;
            const double additionInPow = 0.055;
            const double deviderInPow = 1.055;
            const double power = 2.4;

            double r = color.R / maxColorValue;
            double g = color.G / maxColorValue;
            double b = color.B / maxColorValue;

            r = (r <= comparationParam) ? r / trueParamDevider :
                Math.Pow((r + additionInPow) / deviderInPow, power);
            g = (g <= comparationParam) ? g / trueParamDevider :
                Math.Pow((g + additionInPow) / deviderInPow, power);
            b = (b <= comparationParam) ? b / trueParamDevider :
                Math.Pow((b + additionInPow) / deviderInPow, power);

            return rReturnParamMultipilier * r + gReturnParamMultipilier * g + bReturnParamMultipilier * b;
        }
        private bool IfFlagColorIsAlreadyExist(Color color, string text)
        {
            Panel bigColorPanel = GetPanelFromCotorl(ColorsBox);
            if (bigColorPanel is null) return false;

            Panel colorPanel = GetPanelFromCotorl(bigColorPanel);
            if (colorPanel is null) return false;

            Label colorPanelLb = GetLabelFromControl(colorPanel);
            if (colorPanelLb is null) return false;

            return (colorPanel.BackColor == color &&
                colorPanelLb.Text == text);
        }
        private CheckBox GetCheckBoxFromControl(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is CheckBox)
                {
                    return (CheckBox)control.Controls[i];
                }
            }
            return null;
        }
        private Label GetLabelFromControl(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is Label)
                {
                    return (Label)control.Controls[i];
                }
            }
            return null;
        }
        private Panel GetPanelFromCotorl(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is Panel)
                {
                    return (Panel)control.Controls[i];
                }
            }
            return null;
        }
        private void OwnColorBut_Click(object sender, EventArgs e)
        {
            _toChangeFlag = null;
            ColorAction.Text = _addColorText;
            ChosenColorBox.BackColor = SystemColors.Control;
            TagNameBox.Text = string.Empty;

            ChoseColor.ShowDialog();

            if (ChoseColor.Color != Color.Empty)
            {
                ChosenColorBox.BackColor = ChoseColor.Color;
                ChosenColorBox.Invalidate();
            }
        }
        private Flag IfFlagParamsIsExist()
        {
            for (int i = 0; i < _table._allFlags.Count; i++)
            {
                if (_table._allFlags[i].FlagColor == ChosenColorBox.BackColor &&
                    _table._allFlags[i].FlagTag == TagNameBox.Text)
                {
                    return _table._allFlags[i];
                }
            }
            return null;
        }
        private Flag GetFlagByParams(Color color, string tag)
        {
            for (int i = 0; i < _table._allFlags.Count; i++)
            {
                if (_table._allFlags[i].FlagColor == color &&
                    _table._allFlags[i].FlagTag == tag)
                {
                    return _table._allFlags[i];
                }
            }
            return null;
        }
    }
}
