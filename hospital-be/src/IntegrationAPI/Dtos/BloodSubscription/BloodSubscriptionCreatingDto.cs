using IntegrationAPI.Dtos.BloodProducts;
using System.Collections.Generic;

namespace IntegrationAPI.Dtos.BloodSubscription
{
    public class BloodSubscriptionCreatingDto
    {
        public List<BloodDto> Blood { get; set; }
        public string BloodBank { get; set; }
        public bool ActiveStatus { get; private set; }
        public bool Urgent { get; private set; }

    }
}
