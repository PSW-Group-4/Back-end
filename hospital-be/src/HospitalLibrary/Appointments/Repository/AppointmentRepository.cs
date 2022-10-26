using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Appointments.Repository;

namespace HospitalLibrary.Patients.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _context.Appointments.ToList();
        }

        public Appointment GetById(Guid id)
        {
            var result = _context.Appointments.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Appointment Create(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            return appointment;
        }

        public Appointment Update(Appointment appointment)
        {
            var updatingAppointment = _context.Appointments.SingleOrDefault(a => a.Id == appointment.Id);
            if (updatingAppointment == null)
            {
                throw new NotFoundException();
            }

            updatingAppointment.Update(appointment);

            _context.SaveChanges();
            return updatingAppointment;
        }

        public void Delete(Guid appointmentId)
        {
            var appointment = GetById(appointmentId);
            _context.Appointments.Remove(appointment);
            _context.SaveChanges();
        }
    }
}
