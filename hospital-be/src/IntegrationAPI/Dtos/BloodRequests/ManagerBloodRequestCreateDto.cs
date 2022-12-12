using System;

namespace IntegrationAPI.Dtos.BloodRequests
{
    public class ManagerBloodRequestCreateDto
    {
        public string BloodType { get; set; }
        public double Amount { get; set; }
        public string ManagerId { get; set; }
        public string BloodBankId { get; set; }
    }
}
