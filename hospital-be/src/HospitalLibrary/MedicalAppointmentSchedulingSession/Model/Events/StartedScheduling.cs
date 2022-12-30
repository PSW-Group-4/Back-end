using System;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.Patients.Model;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class StartedScheduling : MedicalAppointmentSchedulingSessionEvent
    {
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get; private set; }

        //EF needs this constructor
        public StartedScheduling(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime) { }

        public StartedScheduling(Guid aggregateId, DateTime occurrenceTime, Patient patient) : base(aggregateId,
            occurrenceTime)
        {
            PatientId = patient.Id;
            Patient = patient;
        }
    }
}