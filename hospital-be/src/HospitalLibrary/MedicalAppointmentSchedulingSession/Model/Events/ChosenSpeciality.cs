using System;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class ChosenSpeciality : MedicalAppointmentSchedulingSessionEvent 
    {
        
        public string  Speciality { get; private set; }
        public ChosenSpeciality(Guid aggregateId, DateTime occurrenceTime, string speciality) : base(aggregateId, occurrenceTime)
        {
            Speciality = speciality;
        }
    }
}