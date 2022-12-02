using HospitalLibrary.Prescriptions.Model;
using HospitalLibrary.Prescriptions.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Prescriptions.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        public PrescriptionService(IPrescriptionRepository prescriptionRepository)
        {
            _prescriptionRepository = prescriptionRepository;
        }
        public IEnumerable<Prescription> GetAll()
        {
            return _prescriptionRepository.GetAll();
        }

        public Prescription GetById(Guid id)
        {
            return _prescriptionRepository.GetById(id);
        }

        public Prescription Create(Prescription prescription)
        {
            return _prescriptionRepository.Create(prescription);
        }

        public Prescription Update(Prescription prescription)
        {
            return _prescriptionRepository.Update(prescription);
        }

        public void Delete(Guid id)
        {
            _prescriptionRepository.Delete(id);
        }
    }
}
