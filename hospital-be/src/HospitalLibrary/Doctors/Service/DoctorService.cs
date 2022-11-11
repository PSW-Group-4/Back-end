using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Patients.Service;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HospitalLibrary.Doctors.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientService _patientService
            ;

        public DoctorService(IDoctorRepository doctorRepository, IPatientService patientService)
        {
            _doctorRepository = doctorRepository;
            _patientService = patientService;

        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll();
        }

        public Doctor GetById(Guid id)
        {
            return _doctorRepository.GetById(id);
        }

        public Doctor Create(Doctor doctor)
        {
            return _doctorRepository.Create(doctor);
        }

        public Doctor Update(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }

        public void Delete(Guid doctorId)
        {
            _doctorRepository.Delete(doctorId);
        }


        public IEnumerable<ChooseDoctorDTO> DoctorsWithLeastPatients()
        {
            return (from doc in _doctorRepository.GetAll() where _patientService.NumberOfPatientsDoctorHas(doc.Id) <= 2 + _doctorRepository.NumberOfPatientsTheDoctorWithLeastPatientsHas() select new ChooseDoctorDTO(doc.Id, doc.Name, doc.Surname, _patientService.NumberOfPatientsDoctorHas(doc.Id))).ToList();
        }
    }
}
