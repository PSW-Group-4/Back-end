using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestsCreateDto
    {
        public String doctorId { get; set; }
        public BloodType bloodType { get; set; }
        public String reasonsWhyBloodIsNeeded { get; set; }
        public double bloodAmountInMilliliters { get; set; }
        public DateTime DateTime { get; set; }
    }
}
