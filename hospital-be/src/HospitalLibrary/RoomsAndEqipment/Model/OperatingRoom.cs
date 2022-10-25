using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class OperatingRoom : Room
    {
        
        public virtual ICollection<Equipment> EquipmentList {get; set;}
    }
}