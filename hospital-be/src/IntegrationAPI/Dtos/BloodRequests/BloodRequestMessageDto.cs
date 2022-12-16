using IntegrationAPI.Dtos.BloodProducts;
using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class BloodRequestMessageDto
    {
        public Guid Id { get; set; }
        public string BloodType { get; set; }
        public double Amount { get; set; }
        public string SendOnDate { get; set; }
        public bool Urgent { get; set; }

        public BloodRequestMessageDto() { }

        public BloodRequestMessageDto(Guid id, string bloodType, double amount, DateTime sendOnDate, bool urgent)
        {
            Id = id;
            BloodType = bloodType;
            Amount = amount;
            SendOnDate = sendOnDate.ToString("yyyy-MM-dd HH:mm");
            Urgent = urgent;
        }
    }
}
