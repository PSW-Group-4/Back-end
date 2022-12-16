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

        
        public MoveEquipmentAppointment(TypeOfMovement type, Guid equipmentId, UInt64 amount, Guid roomId, DateRange dateRange) : base(Guid.NewGuid(), dateRange, roomId, null) {
            this.Type = type;
            this.EquipmentToMove = new EquipmentToMove(equipmentId, amount);
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
            this.FinishAppointment();
        }

        public bool AbleToCancel() {
            return this.DateRange.StartTime.AddDays(-1) < DateTime.Now;
        }

        public bool IsSameAppointment(MoveEquipmentAppointment appointment) {
            return appointment.Id != this.Id && appointment.DateRange.StartTime == this.DateRange.StartTime;
        }
    }
}