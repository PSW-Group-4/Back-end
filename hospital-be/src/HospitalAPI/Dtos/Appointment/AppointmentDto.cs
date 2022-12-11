using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HospitalAPI.Dtos.DateRange;
using HospitalLibrary.Core.Model;

namespace HospitalAPI.Dtos.Appointment
{
    public class AppointmentDto
    {
        public DateRangeDto DateRange { get; set; }
        public Guid RoomId { get; set; }
    }
}