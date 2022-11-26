using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestMessageDto
    {
        public BloodType BloodType { get; set; }
        public RHFactor RHFactor { get; set; }
        public double BloodAmountInMilliliters { get; set; }
        public DateTime SendOnDate { get; set; }
    }
}
