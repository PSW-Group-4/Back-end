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
    
        public Consilium(Guid id, DateRange dateRange, Guid? roomId, Room room,
            string reason, List<Doctor> doctors) : base(id, dateRange, roomId,  room)
        {
            Reason = reason;
            Doctors = doctors;
        }
        
        public  Consilium() : base(){}
    }
}
