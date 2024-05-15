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

    }
}
