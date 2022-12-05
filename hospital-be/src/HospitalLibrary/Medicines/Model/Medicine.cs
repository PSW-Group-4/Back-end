using HospitalLibrary.Prescriptions.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Medicines.Model
{
    public class Medicine
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public virtual List<Prescription> Prescriptions { get; set; }

        public void Update(Medicine medicine)
        {
            Name = medicine.Name;
            Prescriptions = medicine.Prescriptions;
        }
    }
}
