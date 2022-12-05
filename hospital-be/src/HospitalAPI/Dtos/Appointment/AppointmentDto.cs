using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Dtos.Appointment
{
    public class AppointmentDto
    {
        public Guid Id {get; set;}
        public DateRange DateRange { get; set; }
        public Guid RoomId { get; set; }
        public bool IsDone { get; set; }
    }
}