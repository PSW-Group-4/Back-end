using System;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class StartedScheduling : DomainEvent
    {
        public StartedScheduling(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime) { }
    }
}