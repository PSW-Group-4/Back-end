using System;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseDateDto
    {
        public Guid AggregateId { get; set; }
        public DateTime Date { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}