using HospitalLibrary.Doctors.Model;
using HospitalLibrary.Infrastructure.EventSourcing;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using HospitalLibrary.MedicalAppointmentReportSession.Repository;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Symptoms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession
{
    public class MedicalAppointmentReportSession : EventSourcingRoot
    {
        public Doctor Doctor { get; private set; }
        public List<Symptom>? SelectedSymptoms { get; private set; }
        public string? SelectedReportText { get; private set; }
        public List<Medicine>? SelectedMedicines { get; private set; }

        //Exact time is selected after selecting end
        public DateTime? SelectedTime { get; private set; }
        public bool IsScheduled { get; private set; }

        private readonly IMedicalAppointmentReportSessionRepository _repository;

        public MedicalAppointmentReportSession() : base(Guid.NewGuid()) { }

        public MedicalAppointmentReportSession(IMedicalAppointmentReportSessionRepository repository) : base(
            Guid.NewGuid())
        {
            _repository = repository;
        }
        public MedicalAppointmentReportSession(Guid id, IMedicalAppointmentReportSessionRepository repository) : base(id)
        {
            _repository = repository;
        }

        private void AddEvent(MedicalAppointmentReportSessionEvent @event)
        {
            Events.Add(@event);
            _repository.SaveEvent(@event);
        }

        public void Causes(DomainEvent @event)
        {
            Apply(@event);
            AddEvent((MedicalAppointmentReportSessionEvent)@event);
        }

        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version++;
        }

        private void When(StartedScheduling startedScheduling)
        {
            Doctor = startedScheduling.Doctor;
            IsScheduled = false;
        }

        private void When(ChosenSymptom chosenSympton)
        {
            SelectedSymptoms = chosenSympton.Symptoms;
        }

        private void When(ChosenReportText chosenReportText)
        {
            SelectedReportText = chosenReportText.ReportText;
        }

        private void When(ChosenMedicine chosenMedicine)
        {
            SelectedMedicines = chosenMedicine.Medicines;
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
