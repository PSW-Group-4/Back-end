using HospitalAPI.Controllers.Dtos.Doctor;
using HospitalAPI.Controllers.Dtos.Patient;
using HospitalAPI.Controllers.Dtos.Rooms;
using System;

namespace HospitalAPI.Controllers.Dtos.Appointment
{
    public class AppointmentRequestDto
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
