using HospitalLibrary.Exceptions;
using HospitalLibrary.Prescriptions.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Medicines.Model
{
    public class Medicine
    {
        public Guid Id { get; private set; }
        public String Name { get; private set; }
        public virtual List<Prescription> Prescriptions { get; private set; }

        public Medicine() {}

        public Medicine(Guid id, String name, List<Prescription> prescriptions)
        {
            Id = id;
            Name = name;
            Prescriptions = prescriptions;

            if (!IsValid())
                throw new EntityObjectValidationFailedException();
        }

        private bool IsValid()
        {
            return !String.IsNullOrWhiteSpace(Name);
        }

        public void Update(Medicine medicine)
        {
            Name = medicine.Name;
            Prescriptions = medicine.Prescriptions;
        }
    }
}
