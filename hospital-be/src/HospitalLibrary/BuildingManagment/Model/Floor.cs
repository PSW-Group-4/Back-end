using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.BuildingManagment.Model
{
    public class Floor
    {
        public Guid Id {get; set;}
        public String Name {get; set;}
        public Int16 Number {get; set;}

        public virtual ICollection<Room> RoomList {get; set;}
    
        public void Update(Floor floor) {
            Name = floor.Name;
            Number = floor.Number;
            RoomList = floor.RoomList;
        }
    }
}