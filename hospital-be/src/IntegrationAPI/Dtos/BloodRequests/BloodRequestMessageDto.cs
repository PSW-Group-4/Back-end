using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestMessageDto
    {
        public BloodProductDto BloodProduct { get; set; }
        public DateTime SendOnDate { get; set; }
    }
}
