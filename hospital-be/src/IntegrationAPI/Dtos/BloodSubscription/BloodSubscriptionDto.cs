using IntegrationAPI.Dtos.BloodProducts;
using System;
using System.Collections.Generic;

namespace IntegrationAPI.Dtos.BloodSubscription
{
    public class BloodSubscriptionDto
    {
        public List<BloodDto> blood { get; set; }
        public string bloodBank { get; set; }
        public Guid SubscriptionId { get; set; }
    }
}
