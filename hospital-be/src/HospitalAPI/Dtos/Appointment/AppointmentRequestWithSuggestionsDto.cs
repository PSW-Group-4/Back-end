using HospitalAPI.Dtos.DateRange;
using System;

namespace HospitalAPI.Dtos.Appointment
{
    public class AppointmentRequestWithSuggestionsDto
    {
        public Guid DoctorId { get; set; }
        public DateRangeDto RequestTimeRange { get; set; }
        public string Priority { get; set; }

    }
}
