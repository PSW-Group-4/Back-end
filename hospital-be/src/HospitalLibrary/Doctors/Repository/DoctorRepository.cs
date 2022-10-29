﻿using HospitalLibrary.Core.Repository;
using HospitalLibrary.Doctors.Model;
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

        public DoctorRepository(HospitalDbContext context, IAddressRepository addressRepository)
        {
            _context = context;
            _addressRepository = addressRepository;
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



    }
}