using System;

namespace HospitalAPI.Dtos.MedicalAppointmentEventSourcing
{
    public class ChooseSpecialityDto
    {
        public Guid AggregateId { get; set; }
        public string Speciality  { get; set; }
        public DateTime OccurenceTime { get; set; }
    }
}