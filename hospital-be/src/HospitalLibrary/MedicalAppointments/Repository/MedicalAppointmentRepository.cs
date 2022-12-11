using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Appointments.Repository;
using HospitalLibrary.Exceptions;

namespace HospitalLibrary.Appointments.Repository
{
    public class MedicalAppointmentRepository : IMedicalAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public MedicalAppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MedicalAppointment> GetAll()
        {
            return _context.MedicalAppointments.ToList();
        }

        public MedicalAppointment GetById(Guid id)
        {
            var result = _context.MedicalAppointments.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public MedicalAppointment Create(MedicalAppointment medicalAppointment)
        {
            _context.MedicalAppointments.Add(medicalAppointment);
            _context.SaveChanges();
            return medicalAppointment;
        }

        public MedicalAppointment Update(MedicalAppointment medicalAppointment)
        {
            var updatingAppointment = _context.MedicalAppointments.SingleOrDefault(a => a.Id == medicalAppointment.Id);
            if (updatingAppointment == null)
            {
                throw new NotFoundException();
            }

            _context.SaveChanges();
            return updatingAppointment;
        }

        public void Delete(Guid appointmentId)
        {
            var appointment = GetById(appointmentId);
            _context.MedicalAppointments.Remove(appointment);
            _context.SaveChanges();
        }
    }
}
