using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.Patients.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace HospitalLibrary.Doctors.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        private readonly IPatientRepository _patientRepository
            ;

        public DoctorService(IDoctorRepository doctorRepository, IPatientRepository patientRepository)
        {
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;

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

        private  int NumberOfPatientsDoctorHas(Guid doctorId)
        {
           
            return _patientRepository.GetAll().Count(p => p.ChosenDoctorId == doctorId);
        }


        public IEnumerable<ChooseDoctorDTO> DoctorsWithLeastPatients()
        {
            const int maxPatientCountOffset = 2;
            int maximum = _patientRepository.GetAll().Count();
            int minimum = NumberOfPatientsDoctorWithLeastPatientHas(maximum);
            return (from doc in _doctorRepository.GetAll().Where(d => d.Speciality == Constants.Constants.GeneralPractitioner) where NumberOfPatientsDoctorHas(doc.Id) <= maxPatientCountOffset + minimum select new ChooseDoctorDTO(doc.Id, doc.Name, doc.Surname, NumberOfPatientsDoctorHas(doc.Id))).ToList();
        }

        public IEnumerable<string> GetAllSpecialties()
        {
            return _doctorRepository.GetAllSpecialties();
        }

        public IEnumerable<Doctor> GetDoctorsWithSpecialty(string specialty)
        {
            return _doctorRepository.GetDoctorsWithSpecialty(specialty);
        }

        private int NumberOfPatientsDoctorWithLeastPatientHas(int maximum)
        {
            return _doctorRepository.GetAll().Where(d => d.Speciality == Constants.Constants.GeneralPractitioner).ToList().Select(doctor => NumberOfPatientsDoctorHas(doctor.Id)).Prepend(maximum).Min();
        }
    }
}
