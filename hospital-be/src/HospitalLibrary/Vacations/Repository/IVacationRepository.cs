using HospitalLibrary.Core.Repository;
using HospitalLibrary.Vacations.Model;
using System;

namespace HospitalLibrary.Vacations.Repository
{
    public interface IVacationRepository : IRepositoryBase<Vacation> {
        bool IsDoctorOnVacation(Guid doctorId, DateTime date);
    }
}
