using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Prescriptions.Model;
using HospitalLibrary.Symptoms.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Reports.Model
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string Text { get; set; }
        public List<Symptom> Symptoms { get; set; }
        public List<Prescription> Prescriptions { get; set; }
        public DateTime DateTime { get; set; }

        public void Update(Report report)
        {
            Text = report.Text;
            Symptoms = report.Symptoms;
            Prescriptions = report.Prescriptions;
        }
    }
}
