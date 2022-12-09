using HospitalLibrary.Appointments.Model;
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
        public Guid Id { get; set; }
        public String Reason { get; set; }
        public List<Guid> DoctorsId { get; set; }
        public virtual List<Doctor> Doctors { get; set; }

    }
}
