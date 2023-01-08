using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseMedicineDto
    {
        public Guid AggregateId { get; set; }
        public List<Guid> Medicines { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}
