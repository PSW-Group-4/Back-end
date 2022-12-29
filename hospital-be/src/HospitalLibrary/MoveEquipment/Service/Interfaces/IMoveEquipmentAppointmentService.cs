using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.MoveEquipment.Model;

namespace HospitalLibrary.MoveEquipment.Service.Interfaces
{
    public interface IMoveEquipmentAppointmentService : ICrudService<MoveEquipmentAppointment>
    {
        public void CreateMoveEquipment(InputCreateData data);

        public void MoveEquipment();
    }
}