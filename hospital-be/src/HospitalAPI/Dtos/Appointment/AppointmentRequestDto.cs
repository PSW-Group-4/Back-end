using HospitalAPI.Controllers.Dtos.Doctor;
using HospitalAPI.Controllers.Dtos.Patient;
using System;

namespace HospitalAPI.Controllers.Dtos.Appointment
{
    public class AppointmentRequestDto
    {
        public DoctorRequestDto Doctor { get; set; }
        public PatientRequestDTO Patient { get; set; }

        // TODO: RoomRequestDto Room
        public DateTime DateTime { get; set; }
    }
}
