using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.RoomsAndEqipment.Model;

namespace HospitalLibrary.RoomsAndEqipment.Repository.Interfaces
{
    public interface IEquipmentRepository : IRepositoryBase<Equipment>
    {
        
    }
}