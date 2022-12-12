using IntegrationAPI.Dtos.BloodProducts;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestSendDto
    {
        public Guid Id { get; set; }
        public String BloodBank { get; set; }
        public BloodDto Blood { get; set; }
    }
}
