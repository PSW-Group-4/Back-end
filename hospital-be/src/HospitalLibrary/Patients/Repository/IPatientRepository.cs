using HospitalLibrary.Patients.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Utility;
using HospitalLibrary.Core.Model;
using System;

namespace HospitalLibrary.Patients.Repository
{
    public interface IPatientRepository : IRepositoryBase<Patient>
    {
        int GetPatientCountByAgeGroup(AgeGroup ageGroup);
        int GetPatientCountByGender(Gender gender);
        int GetDoctorsPatientCountByAgeGroup(AgeGroup ageGroup, Guid doctorId);
    }

}
