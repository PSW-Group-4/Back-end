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
        public virtual Room Room {get; set;}
        
        [JsonIgnore]
        public Guid RoomId {get; set;}
        public UInt64 Amount {get; set;}

        public void Update(RoomsEquipment room)
        {
        }

        public RoomsEquipment()
        {

        }

        public RoomsEquipment(Equipment equipment, Room room, ulong amount)
        {
            Equipment = equipment;
            EquipmentId = equipment.Id;
            Room = room;
            RoomId = Room.Id;
            Amount = amount;
        }

        public RoomsEquipment(Guid equipment, Guid room, ulong amount)
        {
            EquipmentId = equipment;
            RoomId = room;
            Amount = amount;
        }
    }
}