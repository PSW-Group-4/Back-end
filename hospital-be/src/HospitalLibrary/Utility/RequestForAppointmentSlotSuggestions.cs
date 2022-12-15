using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Utility
{
    public class RequestForAppointmentSlotSuggestions
    {
        public Guid DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid RequestingPatientId { get; set; }
        public string Priority { get; set; }
    }
}
