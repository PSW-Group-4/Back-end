using System;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseReportTextDto
    {
        public Guid AggregateId { get; set; }
        public string ReportText { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}
