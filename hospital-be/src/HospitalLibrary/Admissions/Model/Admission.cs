using HospitalLibrary.Exceptions;
using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using HospitalLibrary.Treatments.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Admissions.Model
{
    public class Admission
    {
        public Guid Id { get; private set; }
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get; private set; }        
        public Reason ReasonText { get; private set; }
        public Guid RoomId { get; private set; }
        public virtual Room Room { get; private set; }
        public DateTime arrivalDate { get; private set; }
        public Nullable<Guid> TreatmentId { get; private set; }
        public virtual Treatment Treatments { get; private set; }

        public Admission(Guid id, Guid patientId, Patient patient, Reason reason, Guid roomId, Room room, DateTime arrivalDate, Guid? treatmentId, Treatment treatments)
        {
            Id = id;
            PatientId = patientId;
            Patient = patient;
            ReasonText = reason;
            RoomId = roomId;
            Room = room;
            this.arrivalDate = arrivalDate;
            TreatmentId = treatmentId;
            Treatments = treatments;
            Validate();
        }

        private void Validate()
        {
            if (PatientId.Equals(Guid.Empty))
            {
                throw new ValueObjectValidationFailedException();
            }
            if (arrivalDate > DateTime.Now)
            {
                throw new ValueObjectValidationFailedException();
            }
        }

        public Admission()
        {

        }

        public void Update(Admission admission)
        {
            PatientId = admission.PatientId;
            ReasonText = admission.ReasonText;
            RoomId = admission.RoomId;
            arrivalDate = admission.arrivalDate;
            TreatmentId = admission.TreatmentId;
        }

        public void UpdateTreatment(Guid treatmentId)
        {
            TreatmentId = treatmentId;
        }
    }

    
}
