using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.Tenders
{
    public class TenderDto
    {
        public BloodType BloodType { get; set; }
        public RHFactor RHFactor { get; set; }
        public double Amount { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime Deadline { get; set; }
    }
}
