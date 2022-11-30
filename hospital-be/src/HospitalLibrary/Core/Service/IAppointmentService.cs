using System;
using System.Collections.Generic;
using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Doctors.Model;

namespace HospitalLibrary.Core.Service
{
    public interface IAppointmentService : ICrudService<Appointment>
    {
        public bool IsAvailable(DateTime time);
        public bool IsDoctorWorkTimeAvailable(DateTime time);
        public List<MedicalAppointment> getAll();
        public Doctor getDoctor();
        public List<DateTime> AvailableTerminsForDate(DateTime date);
        public void UpdateDoneAppointments();

    }
}
