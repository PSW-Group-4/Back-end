using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Prescriptions.Model;
using HospitalLibrary.Symptoms.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Reports.Model
{
    public class Report
    {
        public Guid Id { get; set; }
        public Guid MedicalAppointmentId { get; set; }
        public virtual MedicalAppointment MedicalAppointment { get; set; }
        public string Text { get; set; }
        public virtual List<Symptom> Symptoms { get; set; }
        public virtual List<Prescription> Prescriptions { get; set; }
        public DateTime DateTime { get; set; }

        public void Update(Report report)
        {
            Text = report.Text;
            Symptoms = report.Symptoms;
            Prescriptions = report.Prescriptions;
        }
    }
}
