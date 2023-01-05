using System;
using System.ComponentModel.DataAnnotations;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.EventSourcing;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Events
{
    public class ChosenDoctor : MedicalAppointmentSchedulingSessionEvent
    {
        public Guid DoctorId { get; private set; }
        [Required]
        public virtual Doctor Doctor { get; private set; }

        //EF needs this constructor
        public ChosenDoctor(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime) { } 
        public ChosenDoctor(Guid aggregateId, DateTime occurrenceTime, Doctor doctor) : base(aggregateId, occurrenceTime)
        {
            DoctorId = doctor.Id;
            Doctor = doctor;
        }
    }
}