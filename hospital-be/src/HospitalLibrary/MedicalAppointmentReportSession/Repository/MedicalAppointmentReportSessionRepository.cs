using HospitalLibrary.Doctors.Repository;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.Patients.Repository;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Repository
{
    public class MedicalAppointmentReportSessionRepository : IMedicalAppointmentReportSessionRepository
    {

        private readonly HospitalDbContext _context;

        public MedicalAppointmentReportSessionRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public void SaveEvent(MedicalAppointmentReportSessionEvent @event)
        {
            _context.MedicalAppointmentReportSessionEvents.Add(@event);
            _context.SaveChanges();
        }



        public MedicalAppointmentReportSession GetById(Guid id)
        {
            List<MedicalAppointmentReportSessionEvent> events =
                _context.MedicalAppointmentReportSessionEvents
                    .Where(e => e.AggregateId == id)
                    .OrderBy(e => e.OccurrenceTime)
                    .ToList();

            MedicalAppointmentReportSession session = new MedicalAppointmentReportSession(id, this);
            // Rehydrating aggregate
            foreach (var @event in events)
            {
                session.Apply(@event);
                session.Events.Add(@event);
            }

            return session;
        }

        public IEnumerable<MedicalAppointmentReportSession> GetAll()
        {
            List<Guid> sessionIds = _context.MedicalAppointmentReportSessionEvents.Select(e => e.AggregateId).Distinct().ToList();
            List<MedicalAppointmentReportSession> sessions = new List<MedicalAppointmentReportSession>();

            foreach (Guid id in sessionIds)
            {
                sessions.Add(GetById(id));
            }

            return sessions;
        }

        public MedicalAppointmentReportSessionEvent GetEventById(Guid id)
        {
            return _context.MedicalAppointmentReportSessionEvents.SingleOrDefault(e => e.Id == id);
        }

        public IEnumerable<MedicalAppointmentReportSessionEvent> GetAllEvents()
        {
            return _context.MedicalAppointmentReportSessionEvents.ToList();
        }
    }
}
