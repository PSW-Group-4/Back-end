using HospitalLibrary.Core.Repository;
using HospitalLibrary.Vacations.Model;
using System;
using System.Collections.Generic;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Vacations.Repository
{
    public interface IVacationRepository : IRepositoryBase<Vacation> {
        IEnumerable<Vacation> GetAllPastByDoctorId(Guid doctorId);
        bool IsDoctorOnVacation(Guid doctorId, DateTime date);
        public IEnumerable<Vacation> GetAllManager();
    }
}
