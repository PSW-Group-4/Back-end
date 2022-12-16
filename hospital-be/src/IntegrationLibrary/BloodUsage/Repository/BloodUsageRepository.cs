using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodUsages.Model;
using IntegrationLibrary.Common;
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
            return _context.BloodUsages.ToList();
        }

        public IEnumerable<BloodUsageDto> GetAllBetweenDates(DateTime start, DateTime end)
        {
            /*return _context.BloodUsages
                .Where(where => where.TimeStamp > start && where.TimeStamp < end)
                .GroupBy(group => new
                {
                    bType = group.Type,
                }).Select(select => new BloodUsageDto
                {
                    BloodType = new BloodType(select.Key.bType.BloodGroup, select.Key.bType.RhFactor),
                    Milliliters = select.Sum(ml => ml.Milliliters)
                }).ToList();    */
            List<BloodUsage> bloodUsages = GetAll().ToList();
            List<BloodUsageDto> bloodUsageDtos = new();
            for (int i = 0; i < bloodUsages.Count; i++)
            {
                if (bloodUsages[i].TimeStamp.CompareTo(start) > 0 && bloodUsages[i].TimeStamp.CompareTo(end) < 0)
                {
                    BloodUsageDto dto = new BloodUsageDto();
                    dto.BloodType = new BloodType(bloodUsages[i].Type.BloodGroup, bloodUsages[i].Type.RhFactor);
                    dto.Milliliters = bloodUsages[i].Milliliters;
                    bloodUsageDtos.Add(dto);
                }
            }

            return bloodUsageDtos;
        } 

        public BloodUsage GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
