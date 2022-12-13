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
        public virtual Room Room { get; set; }

        public RoomMap() {}
        public RoomMap(MapLocation location) {
            this.MapLocation = location;
        }
        public void Update(RoomMap map)
        {
            base.Update(map);
            Room = map.Room;
        }

        // Expects rooms to be on a same floor
        public Boolean IsAdjacentTo(RoomMap roomMap) {
            return this.MapLocation.IsAdjacentTo(roomMap.MapLocation);
        }
    }
}
