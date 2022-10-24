using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Patients.Service
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(Guid id);
        void Create(Patient patient);
        void Update(Patient patient);
        void Delete(Guid patientId);
    }
}
