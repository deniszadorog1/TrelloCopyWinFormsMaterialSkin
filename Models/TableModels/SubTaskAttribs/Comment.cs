using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public  class Comment
    {
        public string Value { get; set; }
        public int UniqueIndex { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public int SubTaskId { get; set; }

        public Comment()
        {
            Value = "";
            UniqueIndex = 0;
        }
        public Comment(string value)
        {
            Value = value;
        }
        public Comment(string value, int uniqueIndex, int userId, int subTaskId)
        {
            Value = value;
            UniqueIndex = uniqueIndex;
            Date = DateTime.Now;
            UserId = userId;
            SubTaskId = subTaskId;
        }
    }
}
