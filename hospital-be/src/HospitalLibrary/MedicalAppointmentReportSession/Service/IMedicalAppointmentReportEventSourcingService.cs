using System;
using System.Collections.Generic;
using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;

namespace HospitalLibrary.MedicalAppointmentReportSession.Service
{
    public interface IMedicalAppointmentReportEventSourcingService
    {
        public Guid StartScheduling(Guid doctorId, DateTime occurenceTime);
        public void ChooseSymptom(Guid aggregateId, int numberOfSymptoms, DateTime occurenceTime);
        public void ChooseReportText(Guid aggregateId, string reportText, DateTime occurenceTime);
        public void ChooseMedicine(Guid aggregateId, int numberOfMedicines, DateTime occurenceTime);
        public void FinishScheduling(Guid aggregateId, DateTime time, DateTime occurenceTime);
        public void GoBackToSelection(Guid aggregateId, SelectionReport selection, DateTime occurenceTime);

    }
}
