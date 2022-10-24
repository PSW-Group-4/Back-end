using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Patients.Service
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(Guid id);
        Patient Create(Patient patient);
        Patient Update(Patient patient);
        void Delete(Guid patientId);
    }
}
