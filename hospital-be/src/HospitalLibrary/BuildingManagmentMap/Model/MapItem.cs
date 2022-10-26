using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.BuildingManagmentMap.Model
{
    public abstract class MapItem
    {
        public Guid Guid { get; set; }

        public int CoordinateX { get; set; } 

        public int CoordinateY { get; set; }

        public int Height  { get; set; }  

        public int Width { get; set; }

        public void Update(MapItem item)
        {
            CoordinateX = item.CoordinateX;
            CoordinateY = item.CoordinateY;
            Height = item.Height;
            Width = item.Width;
        }
    }
}
