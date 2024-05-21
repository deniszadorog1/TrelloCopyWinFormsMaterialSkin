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
        public DeadLineDate DeadLine { get; set; }
        public List<CheckListModel> CheckLists { get; set; }

        public SubTask()
        {

        }
        public SubTask(string name)
        {
            Name = name;
            Flags = new List<Flag>();
            DeadLine = null;
            CheckLists = new List<CheckListModel>();
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

        public bool IfChackListNameIsExist(CheckListModel model)
        {
            return CheckLists.Any(x => x.Name == model.Name);
        }

        public bool DeleteCheckListByName(string name)
        {
            if (name == string.Empty) return false;

            CheckListModel toDelete = CheckLists.Find(x => x.Name == name);
            if (toDelete is null) return false;

            CheckLists.Remove(toDelete);
            return true;
        }

        public bool IfCaseInCheckListIsExist(string checkListName, string caseName)
        {
            if (!CheckLists.Any(x => x.Name == checkListName)) throw new Exception("Cant find CheckList with such name!");

            return CheckLists.Any(x => x.Name == checkListName && x.Cases.Any(y => y.Name == caseName));

        }
        public CheckListModel GetCheckListByName(string name)
        {
            return CheckLists.Find(x => x.Name == name);
        }
        
        public void CheckCheckSignForCase(string checkListName, string caseName)
        {
            CheckListModel model = CheckLists.Find(x => x.Name == checkListName);
            CheckListCase caseModel = model.Cases.Find(x => x.Name == caseName);

            caseModel.IfCaseDone = !caseModel.IfCaseDone; 

        }
        public int GetAmountOfCasesOfCheckBox(string checkListName, string caseName)
        {
            CheckListModel model = CheckLists.Find(x => x.Name == checkListName);

            return model.Cases.Count;
        }
        public int GetAmountOfTurnedOnCasesOfCheckBox(string checkListName, string caseName)
        {
            CheckListModel model = CheckLists.Find(x => x.Name == checkListName);

            return model.GetAmountOfTurnedOnCases();
        }

    }
}
