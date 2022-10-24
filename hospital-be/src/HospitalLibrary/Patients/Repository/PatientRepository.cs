﻿using HospitalLibrary.Patients.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Core.Repository;

namespace HospitalLibrary.Patients.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalDbContext _context;
        private readonly IAddressRepository _addressRepository;

        public PatientRepository(HospitalDbContext context, IAddressRepository addressRepository)
        {
            _context = context;
            _addressRepository = addressRepository;
        }

        public IEnumerable<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient GetById(Guid id)
        {
            var result =  _context.Patients.Find(id);
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
    }
}
