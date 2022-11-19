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
        public BloodUsageReport Create(string bloodBankId)
        {
            BloodUsageReport bloodUsageReport = new BloodUsageReport();
            bloodUsageReport.BloodBank = _bankService.GetById(new Guid(bloodBankId));
            if(bloodUsageReport.BloodBank == null)
            {
                return null;
            }

            bloodUsageReport.ReportConfiguration = _configService.GetByBloodBank(bloodUsageReport.BloodBank.Id);
            if(bloodUsageReport.ReportConfiguration == null)
            {
                return null;
            }
            bloodUsageReport.timeOfCreation = DateTime.Now;
            bloodUsageReport.BloodUsage = getUsageSinceLast(bloodUsageReport);

            saveAsPdf(bloodUsageReport);
            return _repository.Create(bloodUsageReport);
        }
        public List<BloodUsageReport> CreateMultiple(List<string> bloodBankIds)
        {
            throw new NotImplementedException();
        }
        private String saveAsPdf(BloodUsageReport bloodUsageReport)
        {
            string html = bloodUsageReport.GenerateHtml();
            return HtmlToPdfConvertor.Convert(html, HtmlToPdfConvertor.defaultPath, bloodUsageReport.BloodBank.Name);
        }
        private List<BloodUsageDto> getUsageSinceLast(BloodUsageReport bloodUsageReport)
        {
            var lastReport = _repository.GetLastByBbId(bloodUsageReport.BloodBank.Id);
            DateTime start;
            if (lastReport == null)
            {
                start = new DateTime(1970, 1, 1);
            }
            else
            {
                start = lastReport.timeOfCreation;
            }
             
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
