using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.ReportConfigurations.Service
{
    public class ReportConfigurationService : IReportConfigurationService
    {
        private readonly IReportConfigurationRepository _repository;

        public ReportConfigurationService(IReportConfigurationRepository repository)
        {
            _repository = repository;
        }
        public ReportConfiguration Create(ReportConfiguration config)
        {
            return _repository.Create(config); 
        }

        public IEnumerable<ReportConfiguration> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ReportConfiguration> GetAllActive()
        {
            return _repository.GetAllActive();
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
            return _repository.Update(config);
        }
    }
}
