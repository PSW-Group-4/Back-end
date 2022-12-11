using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.RoomsAndEqipment.Model;

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
        }


    }
}