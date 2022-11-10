using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Patients.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll();
        }

        public Patient GetById(Guid id)
        {
            return _patientRepository.GetById(id);
        }

        public Patient Create(Patient patient)
        {
            return _patientRepository.Create(patient);
        }

        public Patient Update(Patient patient)
        {
            return _patientRepository.Update(patient);
        }

        public void Delete(Guid patientId)
        {
            _patientRepository.Delete(patientId);
        }
    }
}
