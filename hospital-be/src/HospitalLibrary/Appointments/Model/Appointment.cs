using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Patients.Model;

using System;

namespace HospitalLibrary.Appointments.Model
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public Guid ScheduleId { get; set; }
        public virtual RoomSchedule Schedule { get; set; }
        

        public void Update(Appointment appointment)
        {
            Schedule.Update(appointment.Schedule);
        }
    }
}
