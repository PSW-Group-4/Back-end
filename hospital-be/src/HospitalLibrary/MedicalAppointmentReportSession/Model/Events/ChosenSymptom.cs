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
        public List<Guid> SymptomIds { get; private set; }
        public virtual List<Symptom> Symptoms { get; private set; }

        //EF needs this constructor
        public ChosenSymptom(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime) { }
        public ChosenSymptom(Guid aggregateId, DateTime occurrenceTime, List<Symptom> symptoms) : base(aggregateId, occurrenceTime)
        {
            //SymptomIds = doctor.Id;
            Symptoms = symptoms;
        }
    }
}
