using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Repository
{
    public class BbReportConfigRepository : IBbReportConfigRepository
    {
        private readonly IntegrationDbContext _context;

        public BbReportConfigRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public ReportConfiguration Create(ReportConfiguration config)
        {
            _context.ReportConfigurations.Add(config);
            _context.SaveChanges();
            return config;
        }

        public IEnumerable<ReportConfiguration> GetAll()
        {
           return _context.ReportConfigurations.ToList();
        }

        public ReportConfiguration GetByBloodBank(Guid bloodBankId)
        {
            return _context.ReportConfigurations.Where(config => config.BloodBank.Id == bloodBankId).FirstOrDefault();
        }

        public ReportConfiguration GetById(Guid id)
        {
            ReportConfiguration config = _context.ReportConfigurations.Find(id);
            if (config == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return config;
            }
        }

        public ReportConfiguration Update(ReportConfiguration config)
        {
            throw new NotImplementedException();
        }
    }
}
