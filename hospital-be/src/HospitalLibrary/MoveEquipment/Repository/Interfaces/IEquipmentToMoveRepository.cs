using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.MoveEquipment.Model;

namespace HospitalLibrary.MoveEquipment.Repository.Interfaces
{
    public interface IEquipmentToMoveRepository : IRepositoryBase<EquipmentToMove>
    {
        
    }
}