using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrelloCopyWinForms.Models.DataBase;

namespace TrelloCopyWinForms.Models.TableModels
{
    public class TableTask
    {
        public string Name { get; set; }
        public List<SubTask> SubTasks { get; set; }
        public int PlaceingTableId { get; set; }
        public int TableId { get; set; }
        public int Id { get; set; }
        public TableTask()
        {
            Name = "";
            SubTasks = new List<SubTask>();
        }
        public TableTask(string name)
        {
            Name = name;
            SubTasks = new List<SubTask>();
            PlaceingTableId = -1;
            TableId = -1;
            Id = -1;
        }
        public TableTask(string name, List<SubTask> subTasks)
        {
            Name = name;
            SubTasks = subTasks;
        }

        public SubTask GetSubTaskByName(string subTaskName)
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                if (SubTasks[i].Name == subTaskName)
                {
                    return SubTasks[i];
                }
            }
            return null;
        }

        public SubTask GetSubTaskByNameAndIndex(string name, int index)
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                if (SubTasks[i].Name == name &&
                    SubTasks[i].UniqueIndex == index)
                {
                    return SubTasks[i];
                }
            }
            return null;
        }

        public SubTask GetSubTaskByIndex(int index)
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                if (SubTasks[i].GlobalSubTaskIndex == index)
                {
                    return SubTasks[i];
                }
            }
            throw new Exception("Cant find subTask with such globalsubTaskIndex");
        }


        public bool IfSubTaskContainsAttachmentWhitchContainsGlobalIndex(int index)
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                if (SubTasks[i].IfSubTaskContainsAttachmentWithGlobalIndex(index))
                {
                    return true;
                }
            }
            return false;
        }

        public string GetSubTaskaNameByGlobalIndex(int index)
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                string res = SubTasks[i].GetSubTaskNameByGlobalIndex(index);

                if (res != string.Empty)
                {
                    return res;
                }
            }
            return "";
        }
        public int GetSubTaskIndexByNameAndUniqueIndex(string name, int index)
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                if (SubTasks[i].Name == name &&
                    SubTasks[i].UniqueIndex == index)
                {
                    return i;
                }
            }
            throw new Exception("Cant find subTasks with such params");
        }
        public void RemoveSubTask(string name, int uniqueIndex)
        {
            int subTasksIndex = GetSubTaskIndexByNameAndUniqueIndex(name, uniqueIndex);

            SubTasks.Remove(SubTasks[subTasksIndex]);

        }
        public void InserDraggedSubTask(SubTask subTask, int insertPlace)
        {
            if (insertPlace < SubTasks.Count)
            {
                SubTasks.Insert(insertPlace, subTask);
                subTask.UniqueIndex = insertPlace;
            }
            else
            {
                SubTasks.Add(subTask);
                subTask.UniqueIndex = SubTasks.Count;
            }
        }

        public void UpdateSubTasksUniqueIndexes()
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                SubTasks[i].UniqueIndex = i;
            }
        }
        public int GetTheMostSubTAskGlobalIndex()
        {
            int mostNum = 0;
            for (int i = 0; i < SubTasks.Count; i++)
            {
                if (SubTasks[i].GlobalSubTaskIndex > mostNum)
                {
                    mostNum = SubTasks[i].GlobalSubTaskIndex;
                }
            }
            return mostNum;
        }
        public void UpdateSubTasksInDb()
        {
            for (int i = 0; i < SubTasks.Count; i++)
            {
                DBUsage.UpdateSubTask(SubTasks[i]);
            }
        }
        public void SortSubTaskForPlaceing()
        {
            for (int i = 0; i < SubTasks.Count - 1; i++)
            {
                for (int j = 0; j < SubTasks.Count - i - 1; j++)
                {
                    if (SubTasks[j].UniqueIndex > SubTasks[j + 1].UniqueIndex)
                    {
                        SubTask temp = SubTasks[j];
                        SubTasks[j] = SubTasks[j + 1];
                        SubTasks[j + 1] = temp;
                    }
                }
            }
        }
    }
}
