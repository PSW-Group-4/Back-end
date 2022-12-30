using System;
using System.Collections.Generic;
using System.Linq;
using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Settings;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Repository
{
    public class MedicalAppointmentSchedulingSessionRepository : IMedicalAppointmentSchedulingSessionRepository
    {

         private readonly HospitalDbContext _context;
         private readonly IPatientRepository _patientRepository;
         private readonly IDoctorRepository _doctorRepository;

        public MedicalAppointmentSchedulingSessionRepository(HospitalDbContext context, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _context = context;
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }
        
        public void SaveEvent(MedicalAppointmentSchedulingSessionEvent @event)
        {
            _context.MedicalAppointmentSchedulingSessionEvents.Add(@event);
        }

        public MedicalAppointmentSchedulingSession GetById(Guid id)
        {
            
            List<MedicalAppointmentSchedulingSessionEvent> events =
                _context.MedicalAppointmentSchedulingSessionEvents
                    .Where(e => e.AggregateId == id).
                    OrderBy(e => e.OccurrenceTime).
                    ToList();

            MedicalAppointmentSchedulingSession session = new MedicalAppointmentSchedulingSession(id, this);
            // Rehydrating aggregate
            foreach (var @event in events)
            {
               session.Apply(@event); 
               session.Events.Add(@event);
            }

            return session;
        }
    }
}