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
        public Room Room { get; set; }

        public void Update(RoomMap map)
        {
            base.Update(map);
            Room = map.Room;
        }
    }
}
