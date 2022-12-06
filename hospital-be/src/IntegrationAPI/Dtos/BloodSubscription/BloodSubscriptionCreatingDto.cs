using IntegrationAPI.Dtos.BloodProducts;
using System;
using System.Collections.Generic;

namespace IntegrationAPI.Dtos.BloodSubscription
{
    public class BloodSubscriptionCreatingDto
    {
        public List<BloodDto> Blood { get; set; }
        public string BloodBank { get; set; }
        public bool ActiveStatus { get; set; }
        public bool Urgent { get; set; }
        public int DeliveryDay { get; set; }

    }
}
