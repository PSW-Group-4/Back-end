using HospitalLibrary.Allergies.Model;
using HospitalLibrary.Allergies.Repository;
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

        public PatientService(IPatientRepository patientRepository, IAddressRepository addressRepository,
            IDoctorRepository doctorRepository, IAllergieRepository allergieRepository)
        {
            _patientRepository = patientRepository;
            _addressRepository = addressRepository;
            _doctorRepository = doctorRepository;
            _allergieRepository = allergieRepository;
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

        public Patient RegisterPatient(Patient patient, Guid addressId, Guid choosenDoctorId, List<Guid> allergieIds)
        {
            patient.Address = _addressRepository.GetById(addressId);
            patient.AddressId = addressId;

            patient.ChoosenDoctor = _doctorRepository.GetById(choosenDoctorId);
            patient.ChoosenDoctorId = choosenDoctorId;

            patient.Allergies = _allergieRepository.GetAll().Where(a => allergieIds.Contains(a.Id)).ToList();

            return _patientRepository.Create(patient);
        }
    }
}
