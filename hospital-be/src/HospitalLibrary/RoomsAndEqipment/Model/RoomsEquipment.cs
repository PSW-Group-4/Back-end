using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class RoomsEquipment
    {
        public virtual Equipment Equipment {get; set;}
        
        [JsonIgnore]
        public Guid EquipmentId {get; set;}
        public virtual DoctorRoom DoctorRoom {get; set;}
        
        [JsonIgnore]
        public Guid DoctorRoomId {get; set;}
        public UInt64 Amount {get; set;}

        public void Update(RoomsEquipment room)
        {
        }
    }
}