using System;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class FinishedScheduling : MedicalAppointmentSchedulingSessionEvent
    {
        public DateTime SelectedTime { get; private set; }

        public FinishedScheduling(Guid aggregateId, DateTime occurrenceTime, DateTime selectedTime) : base(aggregateId, occurrenceTime)
        {
            SelectedTime = selectedTime;
        }
    }
}