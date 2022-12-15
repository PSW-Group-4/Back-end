using System;

namespace HospitalAPI.Dtos.Appointment
{
    public class AppointmentRequestPatientDto
    {
        public Guid DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}