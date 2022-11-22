using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodReport.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Service
{
    public interface IBbReportService
    {
        public IEnumerable<BloodUsageReport> GetAll();
        public BloodUsageReport GetById(Guid id);
        public ReportPathTransporter Create(string bloodBankId);
        public List<ReportPathTransporter> CreateMultiple(List<string> bloodBankIds);
        public BloodUsageReport Update(BloodUsageReport bloodUsageReport);
        public IEnumerable<BloodUsageReport> GetByBbId(Guid id);
        public IEnumerable<ReportConfiguration> GetAllActiveConfigs();
        public List<ReportPathTransporter> CreateAllTimeElapsed();
    }
}
