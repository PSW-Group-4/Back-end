using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public class ChosenReportText : MedicalAppointmentReportSessionEvent
    {
        public string ReportText { get; private set; }
        public ChosenReportText(Guid aggregateId, DateTime occurrenceTime, string reportText) : base(aggregateId, occurrenceTime)
        {
            ReportText = reportText;
        }
    }
}
