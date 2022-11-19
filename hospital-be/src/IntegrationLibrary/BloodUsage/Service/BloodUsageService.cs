using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodReport.Repository;
using IntegrationLibrary.BloodUsages.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodUsages.Service
{
    public class BloodUsageService : IBloodUsageService
    {
        private readonly IBloodUsageRepository _repository;
        public BloodUsageService(IBloodUsageRepository repository)
        {
            _repository = repository;
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
            return _repository.GetAllBetweenDates(start, end);
        }

        public BloodUsage GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
