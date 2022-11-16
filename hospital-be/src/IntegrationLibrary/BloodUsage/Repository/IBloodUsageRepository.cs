using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Repository
{
    public interface IBloodUsageRepository
    {
        public IEnumerable<BloodUsage> GetAll();
        public BloodUsage GetById(Guid id);
        public BloodUsage Create(BloodUsage config);
        public IEnumerable<BloodUsage> GetAllBetweenDates(DateTime start, DateTime end);
    }
}
