using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.ReportConfigurations.Service;
using System;

namespace IntegrationAPI.Dtos.ReportsConfiguration
{
    public class ReportConfigurationConverter : IConverter<ReportConfiguration, ReportConfigurationDto>
    {
        private readonly IBloodBankService _service;
        public ReportConfigurationConverter(IBloodBankService service)
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
            retVal.Id = entity.Id.ToString();
            return retVal;
        }

        public ReportConfiguration Convert(ReportConfigurationDto dto)
        {
            var retVal = new ReportConfiguration();
            retVal.ActiveStatus = dto.ActiveStatus;
            retVal.RequestFrequency = dto.RequestFrequency;
            retVal.Id = new Guid(dto.Id);
            retVal.BloodBank = _service.GetById(new Guid(dto.BloodBankId));
            return retVal;
        }
    }
}
