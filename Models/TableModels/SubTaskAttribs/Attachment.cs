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

        public Attachment(int index, string sign)
        {
            SubTaskGlobalIndex = index;
            Sign = sign;
        }
        public bool IfGlobalIndexesAreEqual(int index)
        {
            return SubTaskGlobalIndex == index;
        }
    }
}
