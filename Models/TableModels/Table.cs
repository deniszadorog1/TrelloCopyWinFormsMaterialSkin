using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;
using TrelloCopyWinForms.Models.UserModel;
using TrelloCopyWinForms.Models.DataBase;
using TrelloCopyWinForms.Models.Enums;

namespace TrelloCopyWinForms.Models.TableModels
{
    public class Table
    {
        public string Name { get; set; }
        public List<TableTask> Tasks { get; set; }
        public Color? BgColor { get; set; }
        public int LastSubTaskIndex { get; set; }
        public List<User> UserInTable { get; set; }
        public TableStatus Status { get; set; }
        public FavoriteType FavStatus { get; set; }

        public List<Flag> _allFlags = new List<Flag>();

        public int Id { get; set; }

        public Table()
        {
            Name = string.Empty;
            Tasks = new List<TableTask>();
            BgColor = null;
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
            BgColor = null;
            UserInTable = new List<User>();
        }
        public Table(List<TableTask> tasks, string name, Color bgColor)
        {
            Tasks = tasks;
            Name = name;
            BgColor = bgColor;
            UserInTable = new List<User>();
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
            string res = string.Empty;
            for (int i = 0; i < str.Length; i++)
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
        public SubTask AddSubTask(string tasksName, string subTaskName)
        {
            TableTask task = GetTaskByName(tasksName);
            task.SubTasks.Add(new SubTask(subTaskName, task.SubTasks.Count, LastSubTaskIndex, task.Id));
            LastSubTaskIndex++;

            return task.SubTasks.Last();
        }
        public SubTask GetSubTask(string taskName, string subTaskName, int uniqueIndex)
        {
            TableTask task = GetTaskByName(taskName);

            return task.GetSubTaskByNameAndIndex(subTaskName, uniqueIndex);
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
            for (int i = 0; i < Tasks[tableIndex].SubTasks.Count; i++)
            {
                Tasks[tableIndex].SubTasks[i].UniqueIndex = i;
            }
        }
        public string GetTaskNameWitchContainsSubTaskByGlobalIndex(int index)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].IfSubTaskContainsAttachmentWhitchContainsGlobalIndex(index))
                {
                    return Tasks[i].Name;
                }
            }
            return string.Empty;
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
            return string.Empty;
        }
        public string GetUserLoginById(int userId)
        {
            for (int i = 0; i < UserInTable.Count; i++)
            {
                if (UserInTable[i].Id == userId)
                {
                    return UserInTable[i].Login;
                }
            }
            throw new InvalidOperationException("Cant find user with such ID");
        }
        public bool IfTaskIsExist(string name)
        {
            return Tasks.Any(x => x.Name == name);
        }
        public int GetTaskIndexByName(string name)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Name == name)
                {
                    return i;
                }
            }
            throw new InvalidOperationException("cant find task with such name!");
        }
        public void SwapTwoTasks(string firstTaskName, string secondTaskName)
        {
            TableTask temp = GetTaskByName(firstTaskName);

            int firstIndex = GetTaskIndexByName(firstTaskName);
            int secondIndex = GetTaskIndexByName(secondTaskName);

            Tasks[firstIndex] = Tasks[secondIndex];
            Tasks[secondIndex] = temp;

            int placeIndex = Tasks[firstIndex].PlaceingTableId;
            Tasks[firstIndex].PlaceingTableId = Tasks[secondIndex].PlaceingTableId;
            Tasks[secondIndex].PlaceingTableId = placeIndex;
        }
        public void MoveSubTaskToAnoutherTask(string gettingFromName, string initIntoName, string subTaskName, int subTaskUniqueIndex, int insertionPosition)
        {
            int fromTaskIndex = GetTaskIndexByName(gettingFromName);
            int intoTaskIndex = GetTaskIndexByName(initIntoName);

            SubTask draggingSubTask = Tasks[fromTaskIndex].GetSubTaskByNameAndIndex(subTaskName, subTaskUniqueIndex);

            Tasks[fromTaskIndex].RemoveSubTask(subTaskName, subTaskUniqueIndex);
            Tasks[intoTaskIndex].InserDraggedSubTask(draggingSubTask, insertionPosition);

            Tasks[fromTaskIndex].UpdateSubTasksUniqueIndexes();
            Tasks[intoTaskIndex].UpdateSubTasksUniqueIndexes();
        }
        public void MoveSubTaskInSameTask(string tableName, string subTaskName, int subTaskUniqueIndex, int insertIndex)
        {
            int tableIndex = GetTaskIndexByName(tableName);

            SubTask draggingSubTask = Tasks[tableIndex].GetSubTaskByNameAndIndex(subTaskName, subTaskUniqueIndex);

            Tasks[tableIndex].SubTasks.Remove(draggingSubTask);
            Tasks[tableIndex].InserDraggedSubTask(draggingSubTask, insertIndex);

            Tasks[tableIndex].UpdateSubTasksUniqueIndexes();
        }
        public void UpdateSUbTasksInDB()
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                Tasks[i].UpdateSubTasksInDb();
            }
        }
        public void UpdateTasks()
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                DBUsage.UpdateTask(Tasks[i]);
            }
        }
        public void InitLastSubTaskIndex()
        {
            int theMostNum = 0;
            for (int i = 0; i < Tasks.Count; i++)
            {
                theMostNum = Tasks[i].GetTheMostSubTAskGlobalIndex();
            }
            LastSubTaskIndex = theMostNum;
        }
        public void SortTaskByPlaceingOnTable()
        {
            for (int i = 0; i < Tasks.Count - 1; i++)
            {
                for (int j = 0; j < Tasks.Count - i - 1; j++)
                {
                    if (Tasks[j].PlaceingTableId > Tasks[j + 1].PlaceingTableId)
                    {
                        TableTask task = Tasks[j];
                        Tasks[j] = Tasks[j + 1];
                        Tasks[j + 1] = task;
                    }
                }
            }
        }


    }
}
