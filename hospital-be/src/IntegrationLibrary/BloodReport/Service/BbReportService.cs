using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodUsages.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Service
{
    public class BbReportService : IBbReportService
    {
        private readonly IBbReportRepository _repository;
        private readonly IBloodUsageService _usageService;
        public BbReportService(IBbReportRepository repository, IBloodUsageService usageService)
        {
            _repository = repository;
            _usageService = usageService;
        }
        public BloodUsageReport Create(BloodUsageReport bloodUsageReport)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodUsageReport> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BloodUsageReport> GetByBbId(Guid id)
        {
            throw new NotImplementedException();
        }

        public BloodUsageReport GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public BloodUsageReport Update(BloodUsageReport bloodUsageReport)
        {
            throw new NotImplementedException();
        }
    }
}
