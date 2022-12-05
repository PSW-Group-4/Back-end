using System;

namespace IntegrationAPI.Dtos.BloodSupplies
{
    public class ReceivedBloodDto
    {
        public ReceivedBloodDto(string bloodType, double amount)
        {
            BloodType = bloodType;
            Amount = amount;
        }

        public string BloodType { get; set; }
        public double Amount { get; set; }
        
        
    }
}
