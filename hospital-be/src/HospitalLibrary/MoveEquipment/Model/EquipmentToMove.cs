using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.RoomsAndEqipment.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalLibrary.MoveEquipment.Model
{
    public class EquipmentToMove
    {
        public Guid Id {get; set;}
        public virtual Equipment Equipment {get; set;}
        public Guid EquipmentId {get; set;}
        public UInt64 Amount {get; set;}
        
        public void Update(EquipmentToMove eq) {
            Equipment = eq.Equipment;
            EquipmentId = eq.EquipmentId;
            Amount = eq.Amount;
        }

    }
}