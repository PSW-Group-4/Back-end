using HospitalLibrary.Exceptions;
using HospitalLibrary.Prescriptions.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Prescriptions.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly HospitalDbContext _context;
        public PrescriptionRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Prescription> GetAll()
        {
            return _context.Prescriptions.ToList();
        }

        public Prescription GetById(Guid id)
        {
            var result = _context.Prescriptions.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Prescription Create(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
            return prescription;
        }
        public Prescription Update(Prescription prescription)
        {
            var updatingPrescription = _context.Prescriptions.SingleOrDefault(p => p.Id == prescription.Id);
            if (updatingPrescription == null)
            {
                throw new NotFoundException();
            }

            updatingPrescription.Update(prescription);

            _context.SaveChanges();
            return updatingPrescription;
        }

        public void Delete(Guid prescriptionId)
        {
            var prescription = GetById(prescriptionId);
            _context.Prescriptions.Remove(prescription);
            _context.SaveChanges();
        }
    }
}
