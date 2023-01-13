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
            updatingAppointment.Update(medicalAppointment);
            _context.SaveChanges();
            return updatingAppointment;
        }

        public void Delete(Guid appointmentId)
        {
            var appointment = GetById(appointmentId);
            _context.MedicalAppointments.Remove(appointment);
            _context.SaveChanges();
        }

        public IEnumerable<MedicalAppointment> GetDoneByPatient(Guid patientId)
        {
            return _context.MedicalAppointments.Where(a => a.PatientId == patientId && 
            (a.IsDone || a.DateRange.StartTime < DateTime.Now)).ToList();   //stefan menjao da bih se uskladio sa doktorima
        }

        public IEnumerable<MedicalAppointment> GetCacneledByPatient(Guid patientId)
        {
            return _context.MedicalAppointments.Where(a => a.PatientId == patientId && a.IsCanceled).ToList();
        }

        public IEnumerable<MedicalAppointment> GetFutureByPatient(Guid patientId)
        {
            return _context.MedicalAppointments.Where(a => a.PatientId == patientId 
            && a.DateRange.StartTime >= DateTime.Now
            && !a.IsCanceled).ToList();
        }
    }
}
