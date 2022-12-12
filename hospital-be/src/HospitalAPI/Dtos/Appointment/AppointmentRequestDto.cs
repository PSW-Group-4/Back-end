using HospitalAPI.Dtos.DateRange;
using System;

namespace HospitalAPI.Dtos.Appointment
{
    public class AppointmentRequestDto
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
