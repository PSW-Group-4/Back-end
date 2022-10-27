using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Appointments.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment GetById(Guid id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Create(Appointment appointment)
        {
            return _appointmentRepository.Create(appointment);
        }

        public Appointment Update(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }

        public void Delete(Guid appointmentId)
        {
            _appointmentRepository.Delete(appointmentId);
        }
    }
}
