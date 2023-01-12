using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.BuildingManagmentMap.Model
{
    public class RoomMap : MapItem
    {
        public virtual Room Room { get; private set; }

        public RoomMap() {}
        public RoomMap(Room room, MapLocation location) {
            this.Room = room;
            this.MapLocation = location;
            if (!Validate()) {
                throw new Exception();
            }
        }
        public void Update(RoomMap map)
        {
            base.Update(map);
            Room = map.Room;
            if (!Validate()) {
                throw new Exception();
            }
        }

        // Expects rooms to be on a same floor
        public Boolean IsAdjacentTo(RoomMap roomMap) {
            return this.MapLocation.IsAdjacentTo(roomMap.MapLocation);
        }

        // RoomNumber dictates which part it should take
        // RoomNumber should be 1 for first room and 2 for second
        public MapLocation SplitRoomLocation(int roomNumber) {
            // it will always split vertically
            return new MapLocation(this.MapLocation.CoordinateX + this.MapLocation.Width/2 * (roomNumber-1) , this.MapLocation.CoordinateY, this.MapLocation.Height, this.MapLocation.Width/2);
        }

        public MapLocation MergeRoomLocation(MapLocation location) {
            if(this.MapLocation.ComapreX(location) < 0) {
                return new MapLocation(this.MapLocation.CoordinateX, this.MapLocation.CoordinateY, this.MapLocation.Height, this.MapLocation.Width + location.Width);
            }
            else if(this.MapLocation.ComapreX(location) > 0) {
                return new MapLocation(location.CoordinateX, location.CoordinateY, this.MapLocation.Height, this.MapLocation.Width + location.Width);
            }
            else if(this.MapLocation.ComapreY(location) < 0) {
                return new MapLocation(this.MapLocation.CoordinateX, this.MapLocation.CoordinateY, this.MapLocation.Height + location.Height, this.MapLocation.Width);
            }
            else if(this.MapLocation.ComapreY(location) > 0) {
                return new MapLocation(location.CoordinateX, location.CoordinateY, this.MapLocation.Height + location.Height, this.MapLocation.Width);
            }
            return this.MapLocation;
        }

        public bool Validate()
        {
            if (this.MapLocation == null)
                return false;
            if (this.Room == null)
                return false;
            return true;
        }
    }
}
