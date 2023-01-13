using System;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public abstract class MedicalAppointmentReportSessionEvent : DomainEvent
    {
        protected MedicalAppointmentReportSessionEvent(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime)
        {
        }
    }
}
