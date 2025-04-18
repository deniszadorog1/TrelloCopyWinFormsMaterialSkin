﻿using System;
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
        public CoverImageAttributes BGImage { get; set; }
        public Color? BGColor { get; set; }
        public CoverType? Type { get; set; }
        public int Id { get; set; }

        public Cover()
        {
            BGImage = null;
            BGColor = null;
            Type = null;
        }
        public Cover(CoverImageAttributes image)
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
