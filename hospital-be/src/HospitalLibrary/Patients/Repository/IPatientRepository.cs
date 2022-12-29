using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Patients.Model;
using System;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Patients.Repository
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        int GetPatientCountByAgeGroup(AgeGroup ageGroup);
        int GetPatientCountByGender(Gender gender);
        int GetDoctorsPatientCountByAgeGroup(AgeGroup ageGroup, Guid doctorId);
        int NumberOfAllPatients();
        
        Patient GetByEmail(string email);
    }

}
