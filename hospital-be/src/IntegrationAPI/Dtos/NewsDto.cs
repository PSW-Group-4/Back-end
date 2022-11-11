using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos
{
    public class NewsDto
    {
        public String BloodBankApiKey { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }
        public DateTime Posted { get; set; }
    }
}
