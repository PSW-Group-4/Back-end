using System;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class GoneBackToSelection : MedicalAppointmentSchedulingSessionEvent
    {
        public Selection Selection { get; private set; }
        
        public GoneBackToSelection(Guid aggregateId, DateTime occurrenceTime, Selection selection) : base(aggregateId, occurrenceTime)
        {
            Selection = selection;
        }
    }
}