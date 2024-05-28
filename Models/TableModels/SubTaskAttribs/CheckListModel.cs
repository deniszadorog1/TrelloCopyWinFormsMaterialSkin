using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public class CheckListModel
    {
        public string Name { get; set; }
        public List<CheckListCase> Cases { get; set; }

        public int Id { get; set; }

        public CheckListModel()
        {
            Name = "";
            Cases = new List<CheckListCase>();
        }
        public CheckListModel(string name)
        {
            Name = name;
            Cases = new List<CheckListCase>();
        }
        public CheckListModel(string name, List<CheckListCase> cases)
        {
            Name = name;
            Cases = cases;
        }
        public CheckListModel(CheckListModel copy)
        {
            Name = copy.Name;
            Cases = new List<CheckListCase>();

            for(int i = 0; i < copy.Cases.Count; i++)
            {
                Cases.Add(new CheckListCase(copy.Cases[i]));
            }
        }
        public int GetAmountOfTurnedOnCases()
        {
            return Cases.Where(x => x.IfCaseDone).Count();
        }

    }
}
