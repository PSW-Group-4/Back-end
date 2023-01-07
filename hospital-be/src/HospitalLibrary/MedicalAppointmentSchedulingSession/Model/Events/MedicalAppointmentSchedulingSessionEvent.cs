using System;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public abstract class MedicalAppointmentSchedulingSessionEvent : DomainEvent
    {
        protected MedicalAppointmentSchedulingSessionEvent(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime) { }
    }
}