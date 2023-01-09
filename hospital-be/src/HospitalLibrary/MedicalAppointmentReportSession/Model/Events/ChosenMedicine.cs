using HospitalLibrary.Medicines.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Model.Events
{
    public class ChosenMedicine : MedicalAppointmentReportSessionEvent
    {
        public int NumberOfMedicines { get; private set; }

        public ChosenMedicine(Guid aggregateId, DateTime occurrenceTime, int numberOfMedicines) : base(aggregateId, occurrenceTime)
        {
            NumberOfMedicines = numberOfMedicines;
        }
    }
}
