using HospitalAPI.Dtos.Patient;
using HospitalLibrary.Allergies.Repository;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Patients.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Patients.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IAllergieRepository _allergieRepository;
        private readonly IAgeGroupService _ageGroupRepository;

        public PatientService(IPatientRepository patientRepository, IAddressRepository addressRepository,
            IDoctorRepository doctorRepository, IAllergieRepository allergieRepository, IAgeGroupService ageGroupRepository)
        {
            _patientRepository = patientRepository;
            _addressRepository = addressRepository;
            _doctorRepository = doctorRepository;
            _allergieRepository = allergieRepository;
            _ageGroupRepository = ageGroupRepository;
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

        //TODO "Hash password"
        public Patient RegisterPatient(Patient patient, Guid chosenDoctorId, List<Guid> allergieIds)
        {
            var doctor  =_doctorRepository.GetById(chosenDoctorId);
            patient.AppointTheChosenDoctor(doctor);
            patient.AddStartingAllergies(_allergieRepository.GetAll().Where(a => allergieIds.Contains(a.Id)).ToList());
            return _patientRepository.Create(patient);
        }

        public List<NumberOfPatientsByAgeGroup> PatientsByAgeGroup()
        {
            var PatientsByAgeGroup = new List<NumberOfPatientsByAgeGroup>();
            foreach (var ageGroup in _ageGroupRepository.GetAll())
            {
                PatientsByAgeGroup.Add(new NumberOfPatientsByAgeGroup(ageGroup, _patientRepository.GetPatientCountByAgeGroup(ageGroup)));
            }
            return PatientsByAgeGroup;
        }

        public List<NumberOfPatientsByGender> PatientsByGender()
        {
            var PatientsByGender = new List<NumberOfPatientsByGender>();
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                PatientsByGender.Add(new NumberOfPatientsByGender(gender, _patientRepository.GetPatientCountByGender(gender)));
            }
            return PatientsByGender;
        }

        public List<NumberOfPatientsByAgeGroup> DoctorsPatientsByAgeGroup(Guid DoctorId)
        {
            var DoctorsPatientsByAgeGroup = new List<NumberOfPatientsByAgeGroup>();
            foreach (var ageGroup in _ageGroupRepository.GetAll())
            {
                DoctorsPatientsByAgeGroup.Add(new NumberOfPatientsByAgeGroup(ageGroup, _patientRepository.GetDoctorsPatientCountByAgeGroup(ageGroup, DoctorId)));
            }
            return DoctorsPatientsByAgeGroup;
        }

        public bool isEmailUnique(String email)
        {
            if (_patientRepository.GetByEmail(email) == null)
                return true;
            return false;
        }

     
    }
}
