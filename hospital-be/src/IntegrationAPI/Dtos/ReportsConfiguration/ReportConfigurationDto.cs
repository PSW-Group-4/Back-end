using IntegrationLibrary.BloodBanks.Model;
using System;

namespace IntegrationAPI.Dtos.ReportsConfiguration
{
    public class ReportConfigurationDto
    {
        public string Id { get; set; }
        public string BloodBankId { get; set; }
        public string BloodBankName { get; set; }
        public ReportFrequencyTitles RequestFrequency { get; set; }
        public Boolean ActiveStatus { get; set; }
    }
}
