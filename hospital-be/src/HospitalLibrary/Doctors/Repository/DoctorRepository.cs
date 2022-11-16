using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Doctors.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalDbContext _context;
        private readonly IAddressRepository _addressRepository;
        private readonly IPatientRepository _patientRepository;

        public DoctorRepository(HospitalDbContext context, IAddressRepository addressRepository, IPatientRepository patientRepository)
        {
            _context = context;
            _addressRepository = addressRepository;
            _patientRepository = patientRepository;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _context.Doctors.ToList();
        }

        public Doctor GetById(Guid id)
        {
            var result = _context.Doctors.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Doctor Create(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            _context.SaveChanges();
            return doctor;
        }

        public Doctor Update(Doctor doctor)
        {
            var updatingDoctor = _context.Doctors.SingleOrDefault(p => p.Id == doctor.Id);
            if (updatingDoctor == null)
            {
                throw new NotFoundException();
            }

            updatingDoctor.Update(doctor);

            _context.SaveChanges();
            return updatingDoctor;
        }

        public void Delete(Guid doctorId)
        {
            var doctor = GetById(doctorId);
            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }

        public int NumberOfPatientsTheDoctorWithLeastPatientsHas()
        {
            int minimum = _patientRepository.NumberOfAllPatients();
            return _context.Doctors.ToList().Select(doctor => _patientRepository.NumberOfPatientsDoctorHas(doctor.Id)).Prepend(minimum).Min();
        }



    }
}
