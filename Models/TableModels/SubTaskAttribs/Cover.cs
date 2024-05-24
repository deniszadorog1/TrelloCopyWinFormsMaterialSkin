using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TrelloCopyWinForms.Models.Enums; 

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public class Cover
    {
        public Image BGImage { get; set; }
        public Color? BGColor { get; set; }
        public CoverType? Type { get; set; }

        public Cover()
        {
            BGImage = null;
            BGColor = null;
            Type = null;
        }
        public Cover(Image image)
        {
            BGImage = image;
            BGColor = null;
        }
        public Cover(Color color)
        {
            BGImage = null;
            BGColor = color;
        }
    }
}
