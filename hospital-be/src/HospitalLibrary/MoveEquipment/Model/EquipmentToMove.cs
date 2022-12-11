using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.MoveEquipment.Model
{
    // Change to VO
    public class EquipmentToMove
    {
        public Guid Id {get; set;}
        public virtual Equipment Equipment {get; set;}
        public Guid EquipmentId {get; set;}
        public UInt64 Amount {get; set;}

        public EquipmentToMove(){}

        public EquipmentToMove(Guid equipmentId, UInt64 amount) {
            EquipmentId = equipmentId;
            Amount = amount; 
        } 
        
        public void Update(EquipmentToMove eq) {
            Equipment = eq.Equipment;
            EquipmentId = eq.EquipmentId;
            Amount = eq.Amount;
        }

        public RoomsEquipment ConvertToRoomsEquipmentForRoom(Room room) {
            return new RoomsEquipment(this.Equipment, room, this.Amount);
        }
    }
}