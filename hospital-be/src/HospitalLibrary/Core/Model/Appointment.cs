using System;
using HospitalLibrary.RoomsAndEqipment.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class Appointment
    {
        public Guid Id {get; set;}
        public DateRange DateRange { get; set; }
        public Guid? RoomId { get; set; }
        public String Discriminator {get; private set;}
        public virtual Room Room { get; set; }
        public bool IsDone { get; set; }

        public void Update(Appointment schedule)
        {
            IsDone = schedule.IsDone;
            DateRange = schedule.DateRange;
        }
    }
}