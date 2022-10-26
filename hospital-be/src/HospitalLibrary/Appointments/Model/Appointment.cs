using System;

namespace HospitalLibrary.Appointments.Model
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid RoomId { get; set; }
        public Guid PatientId { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDone { get; set; }

        public void Update(Appointment appointment)
        {
            DateTime = appointment.DateTime;
        }
    }
}
