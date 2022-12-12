using IntegrationLibrary.BloodBanks.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.ReportConfigurations.Service
{
    public interface IReportConfigurationService 
    {
        public IEnumerable<ReportConfiguration> GetAll();
        public ReportConfiguration GetById(Guid id);
        public ReportConfiguration Create(ReportConfiguration config);
        public ReportConfiguration Update(ReportConfiguration config);
        public ReportConfiguration GetByBloodBank(Guid bloodBankId);
        public IEnumerable<ReportConfiguration> GetAllActive();
    }
}
