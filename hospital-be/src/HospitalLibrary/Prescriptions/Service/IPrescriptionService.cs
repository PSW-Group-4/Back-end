using HospitalLibrary.Prescriptions.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Prescriptions.Service
{
    public interface IPrescriptionService
    {
        IEnumerable<Prescription> GetAll();
        Prescription GetById(Guid id);
        Prescription Create(Prescription prescription);
        Prescription Update(Prescription prescription);
        void Delete(Guid symptomId);
    }
}
