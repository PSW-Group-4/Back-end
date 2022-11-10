using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Service;

namespace HospitalLibrary.Patients.Service
{
    public interface IPatientService : ICrudService<Patient>{
        public Patient RegisterPatient(Patient patient, Guid addressId, Guid choosenDoctorId, List<Guid> allergieIds);
    }
}
