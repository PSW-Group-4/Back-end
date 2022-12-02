using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.Report
{
    public class ReportRequestDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public string Text { get; set; }
        public List<HospitalLibrary.Symptoms.Model.Symptom> Symptoms { get; set; }
        public List<HospitalLibrary.Prescriptions.Model.Prescription> Prescriptions { get; set; }
        public DateTime DateTime { get; set; }
    }
}
