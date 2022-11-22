using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Repository
{
    public interface IBbReportRepository
    {
        public IEnumerable<BloodUsageReport> GetAll();
        public BloodUsageReport GetById(Guid id);
        public BloodUsageReport Create(BloodUsageReport bloodUsageReport);
        public BloodUsageReport Update(BloodUsageReport bloodUsageReport);
        public IEnumerable<BloodUsageReport> GetByBbId(Guid id);
        public BloodUsageReport GetLastByBbId(Guid id);
        public List<string> GetAllIdsForReports();
    }
}
