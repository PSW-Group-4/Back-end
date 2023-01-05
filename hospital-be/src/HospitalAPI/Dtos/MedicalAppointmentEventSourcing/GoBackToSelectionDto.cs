using System;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class GoBackToSelectionDto
    {
        public Guid AggregateId { get; set; }
        public Selection Selection { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}