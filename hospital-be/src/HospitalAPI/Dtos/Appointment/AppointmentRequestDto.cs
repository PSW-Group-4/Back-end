using HospitalAPI.Controllers.Dtos.Doctor;
using HospitalAPI.Controllers.Dtos.Patient;
using HospitalAPI.Controllers.Dtos.Rooms;
using System;

namespace HospitalAPI.Controllers.Dtos.Appointment
{
    public class AppointmentRequestDto
    {
        public DoctorRequestDto Doctor { get; set; }
        public PatientRequestDTO Patient { get; set; }
        public RoomRequestDto Room { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDone { get; set; }
    }
}
