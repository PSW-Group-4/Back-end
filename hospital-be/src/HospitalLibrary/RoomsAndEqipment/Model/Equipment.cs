using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class Equipment
    {
        public Guid Id {get; set;}
        public String Name {get; set;}

        [JsonIgnore]
        public virtual ICollection<RoomsEquipment> RoomsEquipment {get; set;}

        public void Update(Equipment equipment) {
            Name = equipment.Name;
        }
    }
}