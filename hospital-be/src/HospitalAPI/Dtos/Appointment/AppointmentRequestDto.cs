using System;
using HospitalAPI.Dtos.Doctor;
using HospitalAPI.Dtos.Patient;
using HospitalAPI.Dtos.Rooms;

namespace HospitalAPI.Dtos.Appointment
{
    public class AppointmentRequestDto
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
