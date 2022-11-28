using System;

namespace IntegrationAPI.Dtos.BloodSupplies
{
    public class BankBloodSupplyDto
    {
        public Guid RequestId { get; set; }
        public string BloodType { get; set; }
        public string RHFactor { get; set; }
        public double Amount { get; set; }
    }
}
