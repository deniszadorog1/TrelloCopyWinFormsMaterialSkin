using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;
using TrelloCopyWinForms.Models.UserModel;

namespace TrelloCopyWinForms.Models.TableModels
{
    public class Table
    {
        public string Name { get; set; }
        public List<TableTask> Tasks { get; set; }
        public Image BGImage { get; set; }
        public int LastSubTaskIndex { get; set; }
        public List<User> UserInTable { get; set; }

        private List<Flag> _allFlags = new List<Flag>();
        public Table()
        {
            Name = "";
            Tasks = new List<TableTask>();
            BGImage = null;
            UserInTable = new List<User>();

            _allFlags.Add(new Flag(Color.Red, string.Empty));
            _allFlags.Add(new Flag(Color.Green, string.Empty));
            _allFlags.Add(new Flag(Color.Blue, string.Empty));
        }
        public Table(string name)
        {
            Name = name;
            LastSubTaskIndex = 0;
            Tasks = new List<TableTask>();
            BGImage = null;
            UserInTable = new List<User>();
        }
        public Table(List<TableTask> tasks, string name, Image bgImage)
        {
            Tasks = tasks;
            Name = name;
            BGImage = bgImage;

            UserInTable = new List<User>();

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
            task.SubTasks.Add(new SubTask(subTaskName, task.SubTasks.Count, LastSubTaskIndex));
            LastSubTaskIndex++;
        }
        public int GetUniqueNumForLastSubTask(string tasksName)
        {
            return GetTaskByName(tasksName).SubTasks.Last().UniqueIndex;
        }

        public SubTask GetSubTask(string taskName, string subTaskName, int uniqueIndex)
        {
            TableTask task = GetTaskByName(taskName);

            return task.GetSubTaskByNameAndIndex(subTaskName, uniqueIndex);
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

        public string GetSubTaskNameByGlobalindex(int index)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                string res = Tasks[i].GetSubTaskaNameByGlobalIndex(index);
                if (res != string.Empty)
                {
                    return res;
                }
            }
            return "";
        }

        public bool IfSuccessDeleteAttachment(string taskName, string subTaskName, int uniqueIndex, int subTaskGlobalIndex)
        {
            TableTask task = GetTaskByName(taskName);
            SubTask subTask = task.GetSubTaskByIndex(subTaskGlobalIndex);

            for(int i = 0; i < subTask.Attachments.Count; i++)
            {
                if (subTask.Attachments[i].UniqueIndex == uniqueIndex)
                {
                    subTask.Attachments.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public string GetUserLoginById(int userId)
        {
            for(int i = 0; i < UserInTable.Count; i++)
            {
                if (UserInTable[i].Id == userId)
                {
                    return UserInTable[i].Login;
                }
            }
            throw new Exception("Cant find user with such ID");
        }
    }
}
