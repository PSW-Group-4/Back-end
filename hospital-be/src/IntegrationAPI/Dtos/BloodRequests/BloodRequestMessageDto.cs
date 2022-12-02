using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestMessageDto
    {
        public Guid Id { get; set; }
        public String BloodType { get; set; }
        public double Amount { get; set; }
        public String SendOnDate { get; set; }
        public String BloodBank { get; set; }
        public bool IsUrgent { get; set; }

        public BloodRequestMessageDto() { }

        public BloodRequestMessageDto(Guid id, string bloodType, double amount, DateTime sendOnDate, string bloodBank, bool isUrgent)
        {
            Id = id;
            BloodType = bloodType;
            Amount = amount;
            SendOnDate = sendOnDate.ToString("yyyy-MM-dd HH:mm");
            BloodBank = bloodBank;
            IsUrgent = isUrgent;
        }
    }
}
