using System;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public class GoneBackToSelection : MedicalAppointmentReportSessionEvent
    {
        public SelectionReport Selection { get; private set; }

        public GoneBackToSelection(Guid aggregateId, DateTime occurrenceTime, SelectionReport selection) : base(aggregateId, occurrenceTime)
        {
            Selection = selection;
        }
    }
}
