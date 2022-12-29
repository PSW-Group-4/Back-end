using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.Renovation.Model;

namespace HospitalLibrary.Renovation.Repository.Interfaces
{ 
    public interface IRenovationAppointmentRepository : IRepositoryBase<RenovationAppointment>
    {
        
    }
}