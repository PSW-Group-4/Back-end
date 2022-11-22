using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Appointments.Model;

namespace HospitalLibrary.MoveEquipment.Model
{
    public class MoveEquipmentTask
    {
        public Guid Id {get; set;}
        public virtual ICollection<EquipmentToMove> EquipmentToGet {get; set;}
        public virtual ICollection<EquipmentToMove> EquipmentToGive {get; set;}
        public virtual RoomSchedule RoomSchedule {get; set;}
        public Guid RoomScheduleId {get; set;}
        public void Update(MoveEquipmentTask task) {
            EquipmentToGet = task.EquipmentToGet;
            EquipmentToGive = task.EquipmentToGive;
            RoomSchedule = task.RoomSchedule;
            RoomScheduleId = task.RoomScheduleId;
        }
    }
}