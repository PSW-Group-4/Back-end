using HospitalLibrary.Appointments.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Doctors.Model;
using HospitalLibrary.RoomsAndEqipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Consiliums.Model
{
    public class Consilium : Appointment
    {
        public String Reason { get; set; }
        public virtual List<Doctor> Doctors { get; set; }

    }
}
