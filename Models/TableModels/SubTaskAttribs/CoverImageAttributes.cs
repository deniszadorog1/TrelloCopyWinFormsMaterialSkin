using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrelloCopyWinForms.Models.TableModels.SubTaskAttribs
{
    public class CoverImageAttributes
    {
        public Image Image { get; set; }
        public string Path { get; set; }

        public CoverImageAttributes(Image img, string path)
        {
            Image = img;
            Path = path;
        }
        public CoverImageAttributes()
        {
            Image = null;
            Path = "";
        }
    }
}
