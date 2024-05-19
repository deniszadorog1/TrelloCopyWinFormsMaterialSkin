using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels
{
    public class TableTask
    {
        public string Name { get; set; }
        public List<SubTask> SubTasks { get; set; }

        public TableTask()
        {
            Name = "";
            SubTasks = new List<SubTask>();
        }
        public TableTask(string name, List<SubTask> subTasks)
        {
            Name = name;
            SubTasks = subTasks;
        }

        public SubTask GetSubTaskByName(string subTaskName)
        {
            for(int i = 0; i < SubTasks.Count; i++)
            {
                if (SubTasks[i].Name == subTaskName)
                {
                    return SubTasks[i];
                }
            }
            return null;
        }

    }
}
