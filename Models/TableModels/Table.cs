using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TrelloCopyWinForms.Models.TableModels
{
    public class Table
    {
        public string Name { get; set; }
        public List<TableTask> Tasks { get; set; }
        public Image BGImage { get; set; }

        public Table()
        {
            Name = "";
            Tasks = new List<TableTask>();
            BGImage = null;
        }
        public Table(List<TableTask> tasks, string name, Image bgImage)
        {
            Tasks = tasks;
            Name = name;
            BGImage = bgImage;
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
            task.SubTasks.Add(new SubTask(subTaskName));

        }
    }
}
