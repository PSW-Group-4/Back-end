using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Equipment
    {
        public Guid Id {get; set;}
        public String Name {get; set;}

        public virtual ICollection<RoomsEquipment> RoomsEquipment {get; set;}

        public void Update(Equipment equipment) {
            Name = equipment.Name;
        }
    }
}