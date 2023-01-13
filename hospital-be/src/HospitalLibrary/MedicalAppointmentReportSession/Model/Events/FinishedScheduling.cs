using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public class FinishedScheduling : MedicalAppointmentReportSessionEvent
    {
        public DateTime SelectedTime { get; private set; }

        public FinishedScheduling(Guid aggregateId, DateTime occurrenceTime, DateTime selectedTime) : base(aggregateId, occurrenceTime)
        {
            SelectedTime = selectedTime;
        }
    }
}
