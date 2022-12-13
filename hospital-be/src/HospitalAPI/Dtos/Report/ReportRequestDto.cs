using HospitalAPI.Dtos.Prescription;
using HospitalAPI.Dtos.Symptom;
using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.Report
{
    public class ReportRequestDto
    {
        public Guid MedicalAppointmentId { get; set; }
        public string Text { get; set; }
        public List<HospitalLibrary.Symptoms.Model.Symptom> Symptoms { get; set; }
        public List<PrescriptionRequestDto> Prescriptions { get; set; }
        public DateTime DateTime { get; set; }
    }
}
