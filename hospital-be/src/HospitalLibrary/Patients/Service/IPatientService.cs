using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using HospitalLibrary.Core.Service;
using HospitalAPI.Dtos.Patient;
using HospitalLibrary.Infrastructure.CRUD;

namespace HospitalLibrary.Patients.Service
{
    public interface IPatientService : ICrudService<Patient>{
        public Patient RegisterPatient(Patient patient, Guid chosenDoctorId, List<Guid> allergieIds);


        public List<NumberOfPatientsByAgeGroup> PatientsByAgeGroup();
        public List<NumberOfPatientsByGender> PatientsByGender();
        public List<NumberOfPatientsByAgeGroup> DoctorsPatientsByAgeGroup(Guid doctorId);
      
        public bool isEmailUnique(String email);
    }
}
