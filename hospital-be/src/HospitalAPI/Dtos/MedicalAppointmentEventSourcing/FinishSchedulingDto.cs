using System;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class FinishSchedulingDto
    {
        public Guid AggregateId { get; set; }
        public DateTime Time { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}