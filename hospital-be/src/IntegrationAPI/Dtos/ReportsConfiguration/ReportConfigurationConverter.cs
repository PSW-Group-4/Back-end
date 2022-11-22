using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.ReportConfigurations.Service;

namespace IntegrationAPI.Dtos.ReportsConfiguration
{
    public class ReportConfigurationConverter : IConverter<ReportConfiguration, ReportConfigurationDto>
    {
        private readonly IBbReportConfigService _service;
        public ReportConfigurationConverter(IBbReportConfigService service)
        {
            _service = service;
        }
        public ReportConfigurationDto Convert(ReportConfiguration entity)
        {
            var retVal = new ReportConfigurationDto();
            retVal.ActiveStatus = entity.ActiveStatus;
            retVal.RequestFrequency = entity.RequestFrequency;
            retVal.BloodBankId = entity.BloodBank.Id.ToString();
            retVal.BloodBankName = entity.BloodBank.Name;
            return retVal;
        }

        public ReportConfiguration Convert(ReportConfigurationDto dto)
        {
            throw new System.NotImplementedException();
        }
    }
}
