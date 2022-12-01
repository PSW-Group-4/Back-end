using IntegrationLibrary.Common;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestsCreateDto
    {
        public String DoctorId { get; set; }
        public BloodType BloodType { get; set; }
        public String ReasonsWhyBloodIsNeeded { get; set; }
        public double BloodAmountInMilliliters { get; set; }
        public DateTime DateTime { get; set; }
    }
}
