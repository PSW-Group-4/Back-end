using System;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class ChosenDoctor : DomainEvent
    {
        public Doctor Doctor { get; private set; }
        public ChosenDoctor(Guid aggregateId, DateTime occurrenceTime, Doctor doctor) : base(aggregateId, occurrenceTime)
        {
            Doctor = doctor;
        }
    }
}