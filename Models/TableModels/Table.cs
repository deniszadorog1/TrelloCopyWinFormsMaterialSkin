using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;

namespace TrelloCopyWinForms.Models.TableModels
{
    public class Table
    {
        public string Name { get; set; }
        public List<TableTask> Tasks { get; set; }
        public Image BGImage { get; set; }
        public int AmountOfSubTasks { get; set; }

        private List<Flag> _allFlags = new List<Flag>();
        public Table()
        {
            Name = "";
            Tasks = new List<TableTask>();
            BGImage = null;

            _allFlags.Add(new Flag(Color.Red, string.Empty));
            _allFlags.Add(new Flag(Color.Green, string.Empty));
            _allFlags.Add(new Flag(Color.Blue, string.Empty));
        }
        public Table(string name)
        {
            Name = name;
            AmountOfSubTasks = 0;
            Tasks = new List<TableTask>();
            BGImage = null;
        }
        public Table(List<TableTask> tasks, string name, Image bgImage)
        {
            Tasks = tasks;
            Name = name;
            BGImage = bgImage;

            _allFlags.Add(new Flag(Color.Red, string.Empty));
            _allFlags.Add(new Flag(Color.Green, string.Empty));
            _allFlags.Add(new Flag(Color.Blue, string.Empty));
        }
        public TableTask GetTaskByName(string name)
        {
            name = DeleteStrTransfersInString(name);
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Name == name)
                {
                    return Tasks[i];
                }
            }
            return null;
        }
        private string DeleteStrTransfersInString(string str)
        {
            string res = "";
            for(int i = 0; i < str.Length; i++)
            {
                if (str[i] != '\n')
                {
                    res += str[i];
                }
            }
            return res;
        }
        public void AddTask(string name)
        {
            Tasks.Add(new TableTask(name, new List<SubTask>()));
        }
        public void AddSubTask(string tasksName, string subTaskName)
        {
            TableTask task = GetTaskByName(tasksName);
            task.SubTasks.Add(new SubTask(subTaskName, task.SubTasks.Count, AmountOfSubTasks));
            AmountOfSubTasks++;
        }
        public int GetUniqueNumForLastSubTask(string tasksName)
        {
            return GetTaskByName(tasksName).SubTasks.Last().UniqueIndex;
        }

        public SubTask GetSubTask(string taskName, string subTaskName)
        {
            TableTask task = GetTaskByName(taskName);

            return task.GetSubTaskByName(subTaskName);
        }
        public List<Flag> GetAllFlags()
        {
            return _allFlags;
        }
        public CheckListModel GetCheckBox(string taskName, string subTaskName, string checkName)
        {
            TableTask task = Tasks.Find(x => x.Name == taskName);
            SubTask subTask = task.GetSubTaskByName(subTaskName);
            CheckListModel res = subTask.CheckLists.Find(x => x.Name == checkName);

            return res;
        }
        public bool IfCheckListNameIsExistInSubTask(string taskName, string subTaskName, string checkName)
        {
            TableTask task = Tasks.Find(x => x.Name == taskName);
            SubTask subTask = task.GetSubTaskByName(subTaskName);
            return subTask.CheckLists.Any(x => x.Name == checkName);
        }
        public void UpdateSubTasksIndexes(int tableIndex)
        {
            for(int i = 0; i < Tasks[tableIndex].SubTasks.Count; i++)
            {
                Tasks[tableIndex].SubTasks[i].UniqueIndex = i;
            }
        }
        public List<SubTask> GetAllSubTasks()
        {
            return null;
        }
        public string GetTaskNameWitchContainsSubTaskByGlobalIndex(int index)
        {
            for(int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].IfSubTaskContainsAttachmentWhitchContainsGlobalIndex(index))
                {
                    return Tasks[i].Name;
                }
            }
            return "";
        }

    }
}
