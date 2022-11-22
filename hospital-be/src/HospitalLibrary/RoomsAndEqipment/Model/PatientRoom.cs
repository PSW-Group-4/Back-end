using HospitalLibrary.Patients.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.RoomsAndEqipment.Model
{
    public class PatientRoom : Room
    {
        public List<Guid> BedIds { get; set; }
        //public virtual ICollection<Bed> Bed { get; set; }
        //public List<Guid> PatientIds { get; set; }
        //public virtual List<Patient> Patients { get; set; }

        public void Update(PatientRoom patientRoom)
        {
            BedIds = patientRoom.BedIds;
        }
    }
}
