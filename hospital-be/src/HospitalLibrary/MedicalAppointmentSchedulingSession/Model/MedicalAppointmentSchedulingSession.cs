using System;
using System.ComponentModel;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Repository;
using HospitalLibrary.Patients.Model;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession
{
    public class MedicalAppointmentSchedulingSession : EventSourcingRoot
    {
        public Patient Patient { get; private set; }
        public DateTime? SelectedDate{ get; private set; }
        public string? SelectedSpeciality { get; private set; }

        public Doctor? SelectedDoctor { get; private set; }
        
        //Exact time is selected after selecting speciality and doctor
        public DateTime? SelectedTime{ get; private set; }
        public bool IsScheduled { get; private set; }

        private readonly IMedicalAppointmentSchedulingSessionRepository _repository;

        public MedicalAppointmentSchedulingSession() : base(Guid.NewGuid()) { }

        public MedicalAppointmentSchedulingSession(IMedicalAppointmentSchedulingSessionRepository repository) : base(
            Guid.NewGuid())
        {
            _repository = repository;
        }
        public MedicalAppointmentSchedulingSession(Guid id, IMedicalAppointmentSchedulingSessionRepository repository) : base(id)
        {
            _repository = repository;
        }

        private void AddEvent(MedicalAppointmentSchedulingSessionEvent @event)  
        {
            Events.Add(@event);
           _repository.SaveEvent(@event); 
        }

        public void Causes(DomainEvent @event)
        {
            Apply(@event);
            AddEvent((MedicalAppointmentSchedulingSessionEvent)@event);
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version++;
        }

        private void When(StartedScheduling startedScheduling)
        {
            Patient = startedScheduling.Patient;
            IsScheduled = false;
        }

        private void When(ChosenDate chosenDate)
        {
            SelectedDate = chosenDate.Date;
        }
        
        private void When(ChosenSpeciality chosenSpeciality)
        {
            SelectedSpeciality = chosenSpeciality.Speciality;
        }
        
        private void When(ChosenDoctor chosenDoctor)
        {
            SelectedDoctor = chosenDoctor.Doctor;
        }
        
        private void When(GoneBackToSelection goneBackToSelection)
        {
            IsScheduled = false;
        }
        
        private void When(FinishedScheduling finishedScheduling)
        {
            SelectedTime = finishedScheduling.SelectedTime;     
            IsScheduled = true;
        }
    }
}