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

        public TableTask()
        {
            Name = "";
        }
        public TableTask(string name)
        {
            Name = name;
        }

    }
}
