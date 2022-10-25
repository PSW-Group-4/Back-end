using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Room
    {
        public Guid Id {get; set;}
        public String Name {get; set;}
        public String Description {get; set;}
    }
}