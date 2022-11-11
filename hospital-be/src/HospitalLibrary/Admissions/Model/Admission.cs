using HospitalLibrary.Patients.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Admissions.Model
{
    public class Admission
    {        
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public string Reason { get; set; }
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        public DateTime arrivalDate { get; set; }

        public void Update(Admission admission)
        {
            PatientId = admission.PatientId;
            Reason = admission.Reason;
            RoomId = admission.RoomId;
            arrivalDate = admission.arrivalDate;
        }
    }

    
}
