using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Symptoms.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalLibrary.Reports.Model
{
    public class Report
    {
        public Guid Id { get; private set; }
        public Guid MedicalAppointmentId { get; private set; }
        public virtual MedicalAppointment MedicalAppointment { get; private set; }
        public string Text { get; private set; }

        [Column(TypeName = "jsonb")]
        public virtual List<Symptom> Symptoms { get; private set; }

        [Column(TypeName = "jsonb")]
        public List<Prescription> Prescriptions { get; private set; }
        public DateTime DateTime { get; private set; }

        public Report() {}

        public Report(Guid id, Guid medicalAppointmentId, string text, List<Symptom> symptoms, List<Prescription> prescriptions, DateTime dateTime)
        {
            Id = id;
            MedicalAppointmentId = medicalAppointmentId;
            Text = text;
            Symptoms = symptoms;
            Prescriptions = prescriptions;
            DateTime = dateTime;

            if (!IsValid())
            {
                throw new EntityObjectValidationFailedException();
            }
        }

        private bool IsValid()
        {
            if (!IsThereMedicalAppointment())
            {
                return false;
            }
            if (!IsThereText())
            {
                return false;
            }
            if (!IsThereSymptoms())
            {
                return false;
            }
            if (!IsTherePrescriptions())
            {
                return false;
            }
            return true;
        }

        private bool IsThereMedicalAppointment()
        {
            if (MedicalAppointmentId.Equals(Guid.Empty))        //Stefan menjao, puca pri inicijalizaciji jer se provrava ceo objekat, koji je null
            {
                return false;
            }
            return true;
        }

        private bool IsThereText()
        {
            if (String.IsNullOrEmpty(Text))
            {
                return false;
            }
            return true;
        }

        private bool IsThereSymptoms()
        {
            if (Symptoms.Count <= 0)
            {
                return false;
            }
            return true;
        }

        private bool IsTherePrescriptions()
        {
            if (Prescriptions.Count <= 0)
            {
                return false;
            }
            return true;
        }

        public void AddSymptom(Symptom symptom)
        {
            Symptoms.Add(symptom);
        }

        public void AddPrescription(Prescription prescription)
        {
            Prescriptions.Add(prescription);
        }

        public void Update(Report report)
        {
            Text = report.Text;
            Symptoms = report.Symptoms;
            Prescriptions = report.Prescriptions;
        }
    }
}
