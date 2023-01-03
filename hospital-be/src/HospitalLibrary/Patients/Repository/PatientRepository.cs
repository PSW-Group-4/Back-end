using HospitalLibrary.Patients.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Core.Repository;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Core.Model;

namespace HospitalLibrary.Patients.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;


        public PatientRepository(HospitalDbContext context)
        {
            _context = context;
         
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(Guid id)
        {
            var result =  _context.Patients.SingleOrDefault(p => p.Id == id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return  result;
        }

        public Patient Create(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return patient;
        }

        public Patient Update(Patient patient)
        {
            var updatingPatient = _context.Patients.SingleOrDefault(p => p.Id == patient.Id);
            if (updatingPatient == null)
            {
                throw new NotFoundException();
            }
            
            updatingPatient.Update(patient);
            
            _context.SaveChanges();
            return updatingPatient;
        }

        public void Delete(Guid patientId)
        {
            var patient = GetById(patientId);
            _context.Patients.Remove(patient);
            _context.SaveChanges();
        }

        public int GetPatientCountByAgeGroup(AgeGroup ageGroup)
        {
            return _context.Patients.ToList().Count(p => p.IsInAgeGroup(ageGroup));
        }

        public int GetPatientCountByGender(Gender gender)
        {
            return _context.Patients.Count(p => p.Gender == gender);
        }

        public int GetDoctorsPatientCountByAgeGroup(AgeGroup ageGroup, Guid doctorId)
        {
            return _context.Patients.ToList().Count(p => p.IsInAgeGroup(ageGroup) && p.ChosenDoctorId==doctorId);
        }

        public int NumberOfAllPatients()
        {
        return _context.Patients.Count();
        }

 

        public Patient GetByEmail(string email)
        {
           return _context.Patients.SingleOrDefault(p => p.Email.Address.Equals(email));
        }
    }
}



