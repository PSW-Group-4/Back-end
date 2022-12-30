using System;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Repository
{
    public interface IMedicalAppointmentSchedulingSessionRepository : IEventRepository<MedicalAppointmentSchedulingSessionEvent, MedicalAppointmentSchedulingSession> { }
}