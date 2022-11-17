using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodUsages.Model;
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

        public IEnumerable<BloodUsageDto> GetAllBetweenDates(DateTime start, DateTime end)
        {
            return _context.bloodUsages
                .Where(where => where.TimeStamp > start && where.TimeStamp < end)
                .GroupBy(group => new
                {
                    bType = group.Type,
                    bFactor = group.RHFactor
                }).Select(select => new BloodUsageDto
                {
                    Type = select.Key.bType,
                    RHFactor = select.Key.bFactor,
                    Milliliters = select.Sum(ml => ml.Milliliters)
                }).ToList();    
        } 

        public BloodUsage GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
