using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public class CheckListCase
    {
        public string Name { get; set; }
        public bool IfCaseDone { get; set; }
        public int ListId { get; set; }
        public int Id { get; set; }
        public  CheckListCase()
        {
            Name = "";
            IfCaseDone = false;
        }
        public CheckListCase(string name)
        {
            Name = name;
            IfCaseDone = false;
        }
        public CheckListCase(string name, bool ifCaseDone)
        {
            Name = name;
            IfCaseDone = ifCaseDone;
        }
        public CheckListCase(CheckListCase copy)
        {
            Name = copy.Name;
            IfCaseDone = copy.IfCaseDone;
        }
    }
}
