using HospitalLibrary.Appointments.Model;
using System;

namespace HospitalAPI.Dtos.Appointment
{
    public class MedicalAppointmentDto
    {
        public Guid Id { get; set; }
        public DateTime StartTime { get; set; }

        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string RoomNumber { get; set;}

        public MedicalAppointmentDto(MedicalAppointment app)
        {
            Id = app.Id;
            StartTime = app.DateRange.StartTime;
            DoctorName = app.Doctor.Name;
            DoctorSurname= app.Doctor.Surname;
            RoomNumber = app.Room.Name + app.Room.Number.ToString();
        }
        
    }
}
