using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.Tenders
{
    public class TenderDto
    {
        public String BloodGroup { get; set; }
        public String RHFactor { get; set; }
        public double Amount { get; set; }
        public String Deadline { get; set; }
    }
}
