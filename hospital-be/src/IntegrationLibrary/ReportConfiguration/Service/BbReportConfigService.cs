using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.ReportConfigurations.Service
{
    public class BbReportConfigService : IBbReportConfigService
    {
        private readonly IBbReportConfigRepository _repository;

        public BbReportConfigService(IBbReportConfigRepository repository)
        {
            _repository = repository;
        }
        public ReportConfiguration Create(ReportConfiguration config)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportConfiguration> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReportConfiguration GetByBloodBank(Guid bloodBankId)
        {
           return _repository.GetByBloodBank(bloodBankId);
        }

        public ReportConfiguration GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ReportConfiguration Update(ReportConfiguration config)
        {
            throw new NotImplementedException();
        }
    }
}
