using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public class Attachment
    {
        public int SubTaskGlobalIndex { get; set; }
        public string Sign { get; set; }
        public int UniqueIndex { get; set; }
        public int Id { get; set; }
        public int SubTaskPlacingId { get; set; }
        public int SubTaskLinkId { get; set; }

        public Attachment()
        {
            SubTaskGlobalIndex = -1;
            Sign = string.Empty;
            UniqueIndex = -1;
            Id = -1;
            SubTaskPlacingId = -1;
            SubTaskLinkId = -1;
        }
        public Attachment(int index, string sign, int uniqueIndex)
        {
            SubTaskGlobalIndex = index;
            Sign = sign;
            UniqueIndex = uniqueIndex;
        }
        public Attachment(int subTaskGlobalIndex, string sign, int uniqueIndex, int subTaskPaceingId, int subTaskLinkId)
        {
            SubTaskGlobalIndex = subTaskGlobalIndex;
            Sign = sign;
            UniqueIndex = uniqueIndex;
            SubTaskPlacingId = subTaskPaceingId;
            SubTaskLinkId = subTaskLinkId;
        }

        public bool IfGlobalIndexesAreEqual(int index)
        {
            return SubTaskGlobalIndex == index;
        }
    }
}
