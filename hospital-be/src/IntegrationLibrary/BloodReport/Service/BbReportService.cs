using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.BloodUsages.Model;
using IntegrationLibrary.BloodUsages.Service;
using IntegrationLibrary.ReportConfigurations.Service;
using IntegrationLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Service
{
    public class BbReportService : IBbReportService
    {
        private readonly IBbReportRepository _repository;
        private readonly IBloodUsageService _usageService;
        private readonly IBloodBankService _bankService;
        private readonly IBbReportConfigService _configService;
        public BbReportService(IBbReportRepository repository, IBloodUsageService usageService, IBloodBankService bankService, IBbReportConfigService configService)
        {
            _repository = repository;
            _usageService = usageService;
            _bankService = bankService;
            _configService = configService;
        }
        public BloodUsageReport Create(BloodUsageReport bloodUsageReport)
        {
            bloodUsageReport.BloodBank = _bankService.GetById(bloodUsageReport.Id);
            if(bloodUsageReport.BloodBank == null)
            {
                return null;
            }

            bloodUsageReport.ReportConfiguration = _configService.GetByBloodBank(bloodUsageReport.Id);
            if(bloodUsageReport == null)
            {
                return null;
            }

            bloodUsageReport.BloodUsage = getUsageSinceLast(bloodUsageReport);

            saveAsPdf(bloodUsageReport);

            return bloodUsageReport;
        }
        private String saveAsPdf(BloodUsageReport bloodUsageReport)
        {
            string html = bloodUsageReport.GenerateHtml();
            return HtmlToPdfConvertor.Convert(html, HtmlToPdfConvertor.defaultPath, bloodUsageReport.BloodBank.Name);
        }
        private List<BloodUsageDto> getUsageSinceLast(BloodUsageReport bloodUsageReport)
        {
            DateTime start = _repository.GetLastByBbId(bloodUsageReport.Id).timeOfCreation;
            return _usageService.GetAllBetweenDates(start, bloodUsageReport.timeOfCreation).ToList();
        }
        public IEnumerable<BloodUsageReport> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<BloodUsageReport> GetByBbId(Guid id)
        {
            throw new NotImplementedException();
        }

        public BloodUsageReport GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BloodUsageReport Update(BloodUsageReport bloodUsageReport)
        {
            throw new NotImplementedException();
        }
    }
}
