using System;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;

namespace HospitalLibrary.MedicalAppointmentReportSession.Repository
{
    public interface IMedicalAppointmentReportSessionRepository : IEventRepository<MedicalAppointmentReportSessionEvent, MedicalAppointmentReportSession>
    {
    }
}
