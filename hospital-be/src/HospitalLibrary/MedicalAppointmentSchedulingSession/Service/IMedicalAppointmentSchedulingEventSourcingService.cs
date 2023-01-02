using System;
using HospitalLibrary.MedicalAppointmentSchedulingSession.Events;

namespace HospitalLibrary.MedicalAppointmentSchedulingSession.Service
{
    public interface IMedicalAppointmentSchedulingEventSourcingService
    {
        public Guid StartScheduling(Guid patientId, DateTime occurenceTime);
        public void ChooseDate(Guid aggregateId, DateTime date, DateTime occurenceTime);
        public void ChooseSpeciality(Guid aggregateId, string speciality, DateTime occurenceTime);
        public void ChooseDoctor(Guid aggregateId, Guid doctorId, DateTime occurenceTime);
        public void FinishScheduling(Guid aggregateId, DateTime time, DateTime occurenceTime);
        public void GoBackToSelection(Guid aggregateId, Selection selection, DateTime occurenceTime);
    }
}