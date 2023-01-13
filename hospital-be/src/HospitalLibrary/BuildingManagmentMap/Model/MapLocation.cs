using HospitalLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.BuildingManagmentMap.Model
{
    public class MapLocation : IComparable<MapLocation>, IEquatable<MapLocation>
    {
        public int CoordinateX { get; private set; } 

        public int CoordinateY { get; private set; }

        public int Height  { get; private set; }  

        public int Width { get; private set; }

        public MapLocation(){}

        public MapLocation(int CoordinateX, int CoordinateY, int Height, int Width) {
            this.CoordinateX = CoordinateX;
            this.CoordinateY = CoordinateY;
            this.Height = Height;
            this.Width = Width;
            if (!Validate())
            {
                throw new ValueObjectValidationFailedException("Map Location is not in correct format");
            }
        }

        public bool Validate() {
            if (this.CoordinateX < 0)
                return false;
            if(this.CoordinateY < 0)
                return false;
            if(this.Height < 0)
                return false;
            if(this.Width < 0)
                return false;
            return true;
        }

        // Used for checking which location is on top
        public int ComapreX(MapLocation mapLocation) {
            return this.CoordinateX - mapLocation.CoordinateX;
        }
        public int ComapreY(MapLocation mapLocation) {
            return this.CoordinateY - mapLocation.CoordinateY;
        }

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

        public int CompareTo(MapLocation other)
        {
            if(!(other.CoordinateX == this.CoordinateX))
                return -1;
            if (!(other.CoordinateY == this.CoordinateY))
                return -1;
            if (!(other.Height == this.Height))
                return -1;
            if(!(other.Width == this.Width))
                return -1; 
            return 0;
        }

        public bool Equals(MapLocation other)
        {
            return CompareTo(other) == 0;
        }
    }
}