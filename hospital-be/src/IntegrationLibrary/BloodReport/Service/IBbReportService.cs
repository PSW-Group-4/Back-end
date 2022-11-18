using IntegrationLibrary.BloodBanks.Model;
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
        public BloodUsageReport Create(string bloodBankId);
        public BloodUsageReport Update(BloodUsageReport bloodUsageReport);
        public IEnumerable<BloodUsageReport> GetByBbId(Guid id);
    }
}
