using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Equipment
    {
        public Guid Id {get; set;}
        public String Name {get; set;}
        public UInt64 Amount {get; set;}

        public void Update(Equipment equipment) {
            Name = equipment.Name;
            Amount = equipment.Amount;
        }
    }
}