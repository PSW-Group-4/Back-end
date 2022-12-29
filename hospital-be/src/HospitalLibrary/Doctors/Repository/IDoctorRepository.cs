using System.Collections.Generic;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Doctors.Repository
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        public IEnumerable<string> GetAllSpecialties();
        public IEnumerable<Doctor> GetDoctorsWithSpecialty(string specialty);
    }
}
