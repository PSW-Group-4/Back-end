using HospitalLibrary.Exceptions;
using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Reports.Model
{
    public class Prescription
    {
        public List<Medicine> Medicines { get; private set; }

        public Prescription(List<Medicine> medicines)
        {
            Medicines = medicines;

            if (!IsValid())
                throw new ValueObjectValidationFailedException();
        }

        private bool IsValid()
        {
            return Medicines.Count > 0;
        }

        public void AddMedicine(Medicine medicine)
        {
            Medicines.Add(medicine);
        }

        public override bool Equals(object obj)
        {
            return obj is Prescription prescription &&
                   Medicines.Equals(prescription.Medicines);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Medicines);
        }
    }
}
