using System;
using System.Collections.Generic;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;

namespace HospitalLibrary.MedicalAppointmentReportSession.Repository
{
    public interface IMedicalAppointmentReportSessionRepository : IEventRepository<MedicalAppointmentReportSessionEvent, MedicalAppointmentReportSession>
    {
        public IEnumerable<MedicalAppointmentReportSessionEvent> GetAllEvents();
    }
}
