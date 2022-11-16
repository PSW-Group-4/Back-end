using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Repository
{
    public class BloodUsageRepository : IBloodUsageRepository
    {
        private readonly IntegrationDbContext _context;

        public BloodUsageRepository(IntegrationDbContext context)
        {
            _context = context;
        }
        public BloodUsage Create(BloodUsage config)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodUsage> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodUsage> GetAllBetweenDates(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public BloodUsage GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
