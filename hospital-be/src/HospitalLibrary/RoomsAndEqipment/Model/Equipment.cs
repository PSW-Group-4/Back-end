using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Equipment
    {
        public Guid Guid {get; set;}
        public String Name {get; set;}
        public UInt64 Amount {get; set;}
    }
}