using System;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public class GoneBackToSelection : MedicalAppointmentReportSessionEvent
    {
        public Selection Selection { get; private set; }

        public GoneBackToSelection(Guid aggregateId, DateTime occurrenceTime, Selection selection) : base(aggregateId, occurrenceTime)
        {
            Selection = selection;
        }
    }
}
