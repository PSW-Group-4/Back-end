using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.Core.Model;
using System;

namespace HospitalLibrary.Appointments.Model
{
    public class MedicalAppointment : Appointment
    {
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
