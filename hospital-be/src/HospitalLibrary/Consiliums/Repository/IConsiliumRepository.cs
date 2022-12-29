using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Core.Repository;
using System;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Consiliums.Repository
{
    public interface IConsiliumRepository : IRepositoryBase<Consilium>
    {
        bool IsDoctorOnConsilium(Guid doctorId, DateTime date);
    }
}
