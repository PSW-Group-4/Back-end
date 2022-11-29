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
            return _context.BloodUsages
                .Where(where => where.TimeStamp > start && where.TimeStamp < end)
                .GroupBy(group => new
                {
                    bType = group.Type,
                }).Select(select => new BloodUsageDto
                {
                    BloodType = new BloodType(select.Key.bType.Title, select.Key.bType.RHFactor),
                    Milliliters = select.Sum(ml => ml.Milliliters)
                }).ToList();    
        } 

        public BloodUsage GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
