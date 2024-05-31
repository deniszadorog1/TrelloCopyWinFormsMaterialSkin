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
using TrelloCopyWinForms.Models.DataBase;

namespace TrelloCopyWinForms.Windows.TableWindows.SubTaskWindows.SubTaskAttribs
{
    public partial class CheckListAction : MaterialForm
    {
        private Table _table;
        private SubTask _chosenSubTask;
        private const char _notCopySign = '-';
        public CheckListAction(Table table, SubTask tempTask)
        {
            _table = table;
            _chosenSubTask = tempTask;

            InitializeComponent();

            InitCopyBox();
        }

        private void InitCopyBox()
        {
            const int distanceBetweenChecksNames = 5;
            const int existCheckListsWidthError = 30;
            Point tempPanelLoc = new Point(0, 0);
            

            for (int i = 0; i < _table.Tasks.Count; i++)
            {
                for (int j = 0; j < _table.Tasks[i].SubTasks.Count; j++)
                {
                    int panelHeight = 0;

                    Point nameLoc = new Point(5, 5);

                    Panel subTaskCheckLists = new Panel();
                    subTaskCheckLists.BorderStyle = BorderStyle.FixedSingle;

                    Label subTaskNameLB = new Label();
                    subTaskNameLB.Tag = _table.Tasks[i].Name; //init name tag to identiyfy it latter
                    subTaskNameLB.Font = new Font("Times New Roman", 14);
                    subTaskNameLB.Location = nameLoc;
                    subTaskNameLB.Text = _table.Tasks[i].SubTasks[j].Name;

                    List<Label> checkListsNames = new List<Label>();
                    for (int k = 0; k < _table.Tasks[i].SubTasks[j].CheckLists.Count; k++)
                    {
                        CheckListModel model = _table.Tasks[i].SubTasks[j].CheckLists[k];

                        Label checkListLB = new Label();
                        checkListLB.Text = model.Name;

                        checkListLB.Click += CheckListNameLb_Click;

                        checkListsNames.Add(checkListLB);
                    }

                    if (checkListsNames.Count > 0)
                    {
                        subTaskCheckLists.Controls.Add(subTaskNameLB);
                        panelHeight += subTaskCheckLists.Height;

                        for (int k = 0; k < checkListsNames.Count; k++)
                        {
                            nameLoc = new Point(nameLoc.X, nameLoc.Y +
                                subTaskCheckLists.Controls[subTaskCheckLists.Controls.Count - 1].Height + distanceBetweenChecksNames);
                            checkListsNames[k].Location = nameLoc;
                            panelHeight += checkListsNames[k].Height + distanceBetweenChecksNames;

                            checkListsNames[k].BorderStyle = BorderStyle.FixedSingle;

                            subTaskCheckLists.Controls.Add(checkListsNames[k]);
                        }

                        Size autoSize = subTaskCheckLists.Size;

                        subTaskCheckLists.AutoSize = false;
                        subTaskCheckLists.Size = new Size(autoSize.Width - existCheckListsWidthError, panelHeight);

                        CheckBoxesToCopy.Controls.Add(subTaskCheckLists);

                    }
                }
            }

        }
        private void CheckListNameLb_Click(object sender, EventArgs e)
        {
            if (sender is Label name)
            {
                Control control = name.Parent.Parent;
                UpadteColorsForCheckListsName(control);

                name.ForeColor = Color.Green;
                ChosenCheckList.Text = name.Text;
            }
        }
        private void UpadteColorsForCheckListsName(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is Panel)
                {
                    UpadteColorsForCheckListsName(control.Controls[i]);
                }
                if (control.Controls[i] is Label name)
                {
                    name.ForeColor = Color.Black;
                }
            }
        }
        public Label GetLabelWhichTextIsGreen(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                Console.WriteLine(control.Controls[i].Name);
                if (control.Controls[i] is Panel)
                {
                    Label label = GetLabelWhichTextIsGreen(control.Controls[i]);

                    if(!(label is null))
                    {
                        return label;
                    }
                }
                if (control.Controls[i] is Label name)
                {
                    if (name.ForeColor == Color.Green)
                    {
                        return name;
                    }
                }
            }
            return null;
        }

        private void AddBut_Click(object sender, EventArgs e)
        {
            if (CheckName.Text == "")
            {
                MessageBox.Show("Smth went wrong!", "Mistake!");
                return;
            }
            if (ChosenCheckList.Text == "-")
            {
                CheckListModel model = new CheckListModel();
                model.Name = CheckName.Text;

                if (_chosenSubTask.IfChackListNameIsExist(model))
                {
                    MessageBox.Show("Check list with such name is exist!", "Mistake!");
                    return;
                }

                InsertModelInDb(model);
                _chosenSubTask.CheckLists.Add(model);

                Close();
                return;
            }
            CheckListModel boxToCopy = new CheckListModel(GetCheckBox());
            boxToCopy.Name = CheckName.Text != "" ? CheckName.Text : boxToCopy.Name;

            if (IfCheckListIsAlreadyExist(boxToCopy))
            {
                MessageBox.Show("Check list with such name is exist!", "Mistake!");
                return;
            }

            InsertModelInDb(boxToCopy);
            _chosenSubTask.CheckLists.Add(boxToCopy);

            Close();
        }
        public void InsertModelInDb(CheckListModel model)
        {
            DBUsage.InsertCheckList(model, _chosenSubTask);
            model.Id = DBUsage.GetCheckListLastId();
        }
        private bool IfCheckListIsAlreadyExist(CheckListModel model)
        {
            Label checkNameLB = GetLabelWhichTextIsGreen(CheckBoxesToCopy);
            if (checkNameLB is null) throw new Exception("Cant get green label to copy");

            Control subTaskNameLB = GetLabelInControl(checkNameLB.Parent);
            if (subTaskNameLB is null) throw new Exception("cant get subTask name");

            return _table.IfCheckListNameIsExistInSubTask(subTaskNameLB.Tag.ToString(), subTaskNameLB.Text, model.Name);
        }
        private CheckListModel GetCheckBox()
        {
            Label chosenLB = GetLabelWhichTextIsGreen(CheckBoxesToCopy);
            if (chosenLB is null) throw new Exception("Chosen check name gave null result");
            Control subTaskNameLB = GetLabelInControl(chosenLB.Parent);
            if (subTaskNameLB is null) throw new Exception("Chosen subTaskNameLB gave null result");

            CheckListModel boxToCopy =
                _table.GetCheckBox(subTaskNameLB.Tag.ToString(), subTaskNameLB.Text, chosenLB.Text);
            if (boxToCopy is null) throw new Exception("Couldnt take a checkList to copy");

            return boxToCopy;
        }

        private Control GetLabelInControl(Control control)
        {
            for (int i = 0; i < control.Controls.Count; i++)
            {
                if (control.Controls[i] is Label subTaskLB && 
                    subTaskLB.Tag != null)
                {
                    return control.Controls[i];
                }
            }
            return null;
        }

        private void ClearCopyBut_Click(object sender, EventArgs e)
        {
            ChosenCheckList.Text = _notCopySign.ToString();
            UpadteColorsForCheckListsName(CheckBoxesToCopy);
        }
    }
}
