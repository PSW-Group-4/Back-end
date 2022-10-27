using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Doctors.Service;
using HospitalLibrary.SchedulingAppointment.Service;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Appointments.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorService _doctorService;

        public AppointmentService(IAppointmentRepository appointmentRepository, IDoctorService doctorService)
        {
            _appointmentRepository = appointmentRepository;
            _doctorService = doctorService;
        }

        public IEnumerable<Appointment> GetAll()
        {
            SchedulingService sc = new SchedulingService(_appointmentRepository, _doctorService);
            sc.UpdateDoneAppointments();
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
