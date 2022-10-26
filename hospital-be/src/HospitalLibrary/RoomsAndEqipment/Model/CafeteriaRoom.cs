using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class CafeteriaRoom : Room
    {
        //TODO Change to DateTime
        public String Workhours {get; set;}

        public void Update(CafeteriaRoom room) {
            //base.Update(room);
            Workhours = room.Workhours;
        }
    }
}