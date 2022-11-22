using System;
using HospitalLibrary.RoomsAndEqipment.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalLibrary.Appointments.Model
{
    public class RoomSchedule
    {
        public Guid Id {get; set;}
        public DateTime DateTime { get; set; }
        public bool IsDone { get; set; }
        public Guid RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int Duration {get; set;}

        public void Update(RoomSchedule schedule)
        {
            DateTime = schedule.DateTime;
            IsDone = schedule.IsDone;
        }
    }
}