using System;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseDoctorDto
    {
        public Guid AggregateId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}