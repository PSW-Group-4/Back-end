using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Prescriptions.Model
{
    public class Prescription
    {
        public Guid Id { get; set; }
        public Guid ReportId { get; set;}
        public DateTime DateTime { get; set; }
        public virtual List<Medicine> Medicines { get; set; }

        public void Update(Prescription prescription)
        {
            ReportId = prescription.ReportId;
            DateTime = prescription.DateTime;
            Medicines = prescription.Medicines;
        }
    }
}
