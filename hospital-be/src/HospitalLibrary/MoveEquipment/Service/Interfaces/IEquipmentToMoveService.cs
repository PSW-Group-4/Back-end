using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Service;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.MoveEquipment.Model;

namespace HospitalLibrary.MoveEquipment.Service.Interfaces
{
    public interface IEquipmentToMoveService : ICrudService<EquipmentToMove>
    {
        
    }
}