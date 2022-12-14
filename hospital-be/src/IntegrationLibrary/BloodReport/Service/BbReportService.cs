using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.BloodReport.Model;
using IntegrationLibrary.BloodUsages.Model;
using IntegrationLibrary.BloodUsages.Service;
using IntegrationLibrary.ReportConfigurations.Service;
using IntegrationLibrary.Utilities.Converters;
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
        private readonly IReportConfigurationService _configurationService;
        public BbReportService(IBbReportRepository repository, IBloodUsageService usageService, IBloodBankService bankService, IReportConfigurationService configurationService)
        {
            _repository = repository;
            _usageService = usageService;
            _bankService = bankService;
            _configurationService = configurationService;
        }
        public ReportPathTransporter Create(string bloodBankId)
        {
            BloodUsageReport bloodUsageReport = new BloodUsageReport();
            bloodUsageReport.BloodBank = _bankService.GetById(new Guid(bloodBankId));
            if(bloodUsageReport.BloodBank == null)
            {
                return null;
            }

            bloodUsageReport.ReportConfiguration = _configurationService.GetByBloodBank(bloodUsageReport.BloodBank.Id);
            if(bloodUsageReport.ReportConfiguration == null)
            {
                return null;
            }
            bloodUsageReport.timeOfCreation = DateTime.Now;
            bloodUsageReport.BloodUsage = getUsageSinceLast(bloodUsageReport);

            var path = saveAsPdf(bloodUsageReport);
            var createdReport = _repository.Create(bloodUsageReport);
            var dto = new ReportPathTransporter();
            dto.ReportPath = path;
            dto.Report = createdReport;
            return dto;
        }
        public List<ReportPathTransporter> CreateMultiple(List<string> bloodBankIds)
        {
            List<ReportPathTransporter> retVal = new List<ReportPathTransporter>();
            foreach (string bloodBankId in bloodBankIds)
            {
                retVal.Add(this.Create(bloodBankId));
            }
            return retVal;

        }
        public IEnumerable<ReportConfiguration> GetAllActiveConfigs()
        {
            return _configurationService.GetAllActive();
        }
        public List<ReportPathTransporter> CreateAllTimeElapsed()
        {
            var configs = this.GetAllActiveConfigs().ToList();
            List <ReportPathTransporter> retVal = new List<ReportPathTransporter>();
            if(configs == null)
            {
                return null;
            }
            foreach (var config in configs)
            {
                var lastReport = _repository.GetLastByBbId(config.BloodBank.Id);
                DateTime start;
                if (lastReport == null)
                {
                    start = new DateTime(1970, 1, 1);
                }
                else
                {
                    start = lastReport.timeOfCreation;
                }
                if (start.AddDays((int)config.RequestFrequency) <= DateTime.Now)
                {
                    retVal.Add(this.Create(config.BloodBank.Id.ToString()));
                }
            }
            return retVal;
        }
        private string saveAsPdf(BloodUsageReport bloodUsageReport)
        {
            string html = bloodUsageReport.GenerateHtml();
            return HtmlToPdfConverter.Convert(html, HtmlToPdfConverter.defaultPath, bloodUsageReport.BloodBank.Name);
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

        public List<string> GetAllIdsForReports()
        {
            throw new NotImplementedException();
        }
    }
}
