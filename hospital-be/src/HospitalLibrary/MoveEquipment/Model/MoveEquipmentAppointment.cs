using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.RoomsAndEqipment.Model;
using Microsoft.AspNetCore.Mvc;

namespace HospitalLibrary.MoveEquipment.Model
{
    public class MoveEquipmentAppointment : Appointment
    {
        public enum TypeOfMovement { Give, Get }

        public virtual EquipmentToMove EquipmentToMove {get; private set;}
        public TypeOfMovement Type {get; private set;}
        public MoveEquipmentAppointment() {}

        public MoveEquipmentAppointment(TypeOfMovement type, Guid equipmentId, UInt64 amount, Guid roomId, DateRange dateRange) {
            this.Type = type;
            this.EquipmentToMove = new EquipmentToMove(equipmentId, amount);
            this.IsDone = false;
            this.RoomId = roomId;
            this.DateRange = dateRange;
            Validate();
        }

        public void Validate() {
            if (EquipmentToMove == null)
                throw new InvalidValueException();
            
            if (RoomId.Equals(Guid.Empty)) { 
                throw new InvalidValueException();
            }
            if(DateRange == null) { throw new InvalidValueException();}

        }

        public bool ShouldBeFinished()
        {
            return false == this.IsDone && DateRange.IsLesserThan(DateTime.Now);
        }

        public void Finish()
        {
            this.IsDone = true;
        }
    }
}