using System;
using HospitalAPI.Dtos.Doctor;
using HospitalAPI.Dtos.Patient;
using HospitalAPI.Dtos.Rooms;

namespace HospitalAPI.Dtos.Appointment
{
    public class AppointmentRequestDto
    {
        public DoctorRequestDto Doctor { get; set; }
        public PatientRequestDto Patient { get; set; }
        public RoomRequestDto Room { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDone { get; set; }
    }
}
