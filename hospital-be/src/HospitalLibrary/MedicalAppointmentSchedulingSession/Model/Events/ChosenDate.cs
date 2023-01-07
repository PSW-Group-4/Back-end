using System;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class ChosenDate : MedicalAppointmentSchedulingSessionEvent
    {
        public DateTime Date { get; private set; }
        public ChosenDate(Guid aggregateId, DateTime occurrenceTime, DateTime date) : base(aggregateId, occurrenceTime)
        {
            Date = date;
        }
    }
}