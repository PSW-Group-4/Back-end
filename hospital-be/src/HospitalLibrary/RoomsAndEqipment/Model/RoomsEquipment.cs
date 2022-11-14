using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class RoomsEquipment
    {
        public virtual Equipment Equipment {get; set;}
        public Guid EquipmentId {get; set;}
        public virtual DoctorRoom DoctorRoom {get; set;}
        public Guid DoctorRoomId {get; set;}
        public UInt64 Amount {get; set;}
    }
}