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

        public MapLocation(){}

        public Boolean IsAdjacentTo(MapLocation location) {
            // Check vertical
            if(this.CoordinateX == location.CoordinateX) {
                if(this.CoordinateY > location.CoordinateY) {
                    if(this.CoordinateY - this.Height == location.CoordinateY) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    if(location.CoordinateY - location.Height == this.CoordinateY) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
            // Check horizontal
            if(this.CoordinateY == location.CoordinateY) {
                if(this.CoordinateX > location.CoordinateX) {
                    if(this.CoordinateX - this.Width == location.CoordinateX) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
                else {
                    if(location.CoordinateX - location.Width == this.CoordinateX) {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}