using HospitalLibrary.Appointments.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Appointments.Service
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment GetById(Guid id);
        Appointment Create(Appointment appointment);
        Appointment Update(Appointment appointment);
        void Delete(Guid appointmentId);
        IEnumerable<Appointment> GetDoctorsOldAppointments(Guid id);
        IEnumerable<Appointment> GetDoctorsCurrentAppointments(Guid id);
    }
}
