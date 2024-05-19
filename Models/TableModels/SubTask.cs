using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrelloCopyWinForms.Models.TableModels.SubTaskAttribs;
using TrelloCopyWinForms.Models.UserModel;

namespace TrelloCopyWinForms.Models.TableModels
{
    public class SubTask
    {
        public string Name { get; set; }
        public List<Flag> Flags { get; set; }
        public DateTime? DeadLine { get; set; }

        public SubTask()
        {

        }
        public SubTask(string name)
        {
            Name = name;
            Flags = new List<Flag>();
            DeadLine = null;
        }

        public int GetTransfersAmount()
        {
            int count = 1;
            for (int i = 0; i < Name.Length - 1; i++)
            {
                if (Name[i] == '\n')
                {
                    count++;
                    i++;
                }
            }
            return count;
        }
    }
}
