using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.BuildingManagmentMap.Model
{
    public class MapLocation
    {
        public int CoordinateX { get; set; } 

        public int CoordinateY { get; set; }

        public int Height  { get; set; }  

        public int Width { get; set; }
    }
}