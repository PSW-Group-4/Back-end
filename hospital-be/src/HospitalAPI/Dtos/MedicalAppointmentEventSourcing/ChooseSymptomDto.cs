using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseSymptomDto
    {
        public Guid AggregateId { get; set; }
        public int NumberOfSymptoms { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}
