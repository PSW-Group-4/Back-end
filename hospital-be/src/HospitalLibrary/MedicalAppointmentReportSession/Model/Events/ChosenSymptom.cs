using HospitalLibrary.Symptoms.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public class ChosenSymptom : MedicalAppointmentReportSessionEvent
    {
        public int NumberOfSymptoms { get; private set; }

        public ChosenSymptom(Guid aggregateId, DateTime occurrenceTime, int numberOfSymptoms) : base(aggregateId, occurrenceTime)
        {
            NumberOfSymptoms = numberOfSymptoms;
        }
    }
}
