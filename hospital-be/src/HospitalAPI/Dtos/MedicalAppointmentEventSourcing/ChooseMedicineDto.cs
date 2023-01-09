using System;
using System.Collections.Generic;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseMedicineDto
    {
        public Guid AggregateId { get; set; }
        public int NumberOfMedicines { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}
