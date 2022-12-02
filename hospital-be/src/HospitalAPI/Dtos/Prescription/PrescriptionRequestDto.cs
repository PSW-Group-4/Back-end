using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.Prescription
{
    public class PrescriptionRequestDto
    {
        public Guid Id { get; set; }
        public Guid ReportId { get; set; }
        public DateTime DateTime { get; set; }
        public List<HospitalLibrary.Medicines.Model.Medicine> Medicines { get; set; }
    }
}
