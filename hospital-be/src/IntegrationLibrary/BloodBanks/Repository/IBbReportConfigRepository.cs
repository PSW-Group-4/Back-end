using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Repository
{
    public interface IBbReportConfigRepository
    {
        public IEnumerable<BloodUsageReport> GetAll();
        public BloodUsageReport GetById(Guid id);
        public BloodUsageReport Create(BloodUsageReport report);
        public BloodUsageReport Update(BloodUsageReport report);
        public BloodUsageReport GetByBloodBank(Guid bloodBankId);
    }
}
