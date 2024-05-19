using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public class Flag
    {
        public Color FlagColor { get; set; }
        public string FlagTag { get; set; }
        public Flag()
        {
            FlagColor = Color.Empty;
            FlagTag = string.Empty;
        }
        public Flag(Color flagColor, string tag)
        {
            FlagColor = flagColor;
            FlagTag = tag;
        }

    }
}
