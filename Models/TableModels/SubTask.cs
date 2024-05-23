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
        public int UniqueIndex { get; set; }
        public int GlobalSubTaskIndex { get; set; }
        public List<Flag> Flags { get; set; }
        public DeadLineDate DeadLine { get; set; }
        public List<CheckListModel> CheckLists { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Comment> History { get; set; }
        public List<Attachment> Attachments { get; set; }

        public SubTask()
        {
            Name = "";
            UniqueIndex = -1;
            GlobalSubTaskIndex = -1;
            Flags = new List<Flag>();
            DeadLine = new DeadLineDate();
            CheckLists = new List<CheckListModel>();
            Comments = new List<Comment>();
            History = new List<Comment>();
            Attachments = new List<Attachment>();
        }
        public SubTask(string name, int uniqueIndex, int globalSubTaskIndex)
        {
            Name = name;
            UniqueIndex = uniqueIndex;
            GlobalSubTaskIndex = globalSubTaskIndex;
            Flags = new List<Flag>();
            DeadLine = null;
            CheckLists = new List<CheckListModel>();
            Comments = new List<Comment>();
            History = new List<Comment>();
            Attachments = new List<Attachment>();
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
        public void DeleteSubTask(string checkListName, string caseName)
        {
            CheckListModel model = CheckLists.Find(x => x.Name == checkListName);

            model.Cases.Remove(model.Cases.Find(x => x.Name == caseName));
        }
        public void AddComment(string comment)
        {
            Comments.Insert(0, new Comment(comment, Comments.Count));
        }
        public void DeleteComment(string commentValue, int commentIndex)
        {
            Comments.Remove(Comments.Find(x => x.Value == commentValue && x.UniqueIndex == commentIndex));
        }
        public Comment GetComment(string commentValue, int commentIndex)
        {
            return Comments.Find(x => x.Value == commentValue && x.UniqueIndex == commentIndex);
        }
        public void UpdateComment(string newValue, int commentIndex)
        {
            Comments.Find(x => x.UniqueIndex == commentIndex).Value = newValue;
        }
        public bool IfSubTaskContainsAttachmentWithGlobalIndex(int index)
        {
            for(int i = 0; i < Attachments.Count; i++)
            {
                if (Attachments[i].IfGlobalIndexesAreEqual(index))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
