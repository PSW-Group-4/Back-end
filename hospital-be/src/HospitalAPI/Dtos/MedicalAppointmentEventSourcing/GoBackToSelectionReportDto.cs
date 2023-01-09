using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using System;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class GoBackToSelectionReportDto
    {
        public Guid AggregateId { get; set; }
        public SelectionReport Selection { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}
