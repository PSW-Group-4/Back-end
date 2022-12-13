using IntegrationAPI.Dtos.BloodProducts;
using System;
using System.Collections.Generic;

namespace IntegrationAPI.Dtos.BloodSubscription
{
    public class BloodSubscriptionSendingDto
    {
        public List<BloodDto> Blood { get; set; }
        public string BloodBank { get; set; }
        public Guid SubscriptionId { get; set; }
        
        public int DeliveryDay { get; set; }  
    }
}
