using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Doctors.Repository;
using System;
using System.Collections.Generic;


namespace HospitalLibrary.Doctors.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
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
    }
}
