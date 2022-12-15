using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Execution;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.MoveEquipment.Model
{
    // Change to VO
    public class EquipmentToMove
    {
        public Guid Id {get; private set;}
        public virtual Equipment Equipment {get;  private set;}
        public Guid EquipmentId {get; private set;}
        public UInt64 Amount {get; private set;}

        public EquipmentToMove(){}

        public EquipmentToMove(Guid equipmentId, UInt64 amount) {
            EquipmentId = equipmentId;
            Amount = amount;
            Validate();
        } 
        
        public void Update(EquipmentToMove eq) {
            Equipment = eq.Equipment;
            EquipmentId = eq.EquipmentId;
            Amount = eq.Amount;
        }

        public RoomsEquipment ConvertToRoomsEquipmentForRoom(Room room) {
            return new RoomsEquipment(this.Equipment, room, this.Amount);
        }

        public void Validate() {
            if (EquipmentId.Equals(Guid.Empty))
                throw new InvalidValueException();
            if (Amount <= 0)
            {
                throw new InvalidValueException();
            }
        }

        public override string ToString()
        {

            return Amount.ToString() + Equipment.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Equipment, Amount);
        }

        public bool Equals(EquipmentToMove other)
        {
            return CompareTo(other) == 0;
        }

        public int CompareTo(EquipmentToMove other)
        {
            return string.Compare(ToString(), other.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return obj is EquipmentToMove equipmentToMove && Equals(equipmentToMove);
        }
    }

    
}