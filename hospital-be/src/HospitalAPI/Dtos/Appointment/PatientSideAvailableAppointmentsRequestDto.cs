using System;

namespace HospitalAPI.Dtos.Appointment
{
    public class PatientSideAvailableAppointmentsRequestDto
    {
         public DateTime Date { get; set; }
         public Guid DoctorId { get; set; }
    }
}