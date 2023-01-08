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
        public List<Guid> MedicineIds { get; private set; }
        public virtual List<Medicine> Medicines { get; private set; }

        //EF needs this constructor
        public ChosenMedicine(Guid aggregateId, DateTime occurrenceTime) : base(aggregateId, occurrenceTime) { }
        public ChosenMedicine(Guid aggregateId, DateTime occurrenceTime, List<Medicine> medicines) : base(aggregateId, occurrenceTime)
        {
            //MedicineIds = doctor.Id;
            Medicines = medicines;
        }
    }
}
