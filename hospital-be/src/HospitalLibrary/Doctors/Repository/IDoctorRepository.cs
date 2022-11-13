using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Model;

namespace HospitalLibrary.Doctors.Repository
{
    public interface IDoctorRepository : IRepositoryBase<Doctor>
    {
        public int NumberOfPatientsTheDoctorWithLeastPatientsHas();
    }

}
