using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.BuildingManagment.Model
{
    public class Floor
    {
        public Guid Guid {get; set;}
        public String Name {get; set;}
        public Int16 Number {get; set;}

        public List<Room> RoomList {get; set;}
    }
}