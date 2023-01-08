using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseSymptomDto
    {
        public Guid AggregateId { get; set; }
        public List<Guid> Symptoms { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}
