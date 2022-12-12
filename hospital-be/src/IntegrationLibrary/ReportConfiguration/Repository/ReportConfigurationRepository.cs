using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodReport.Repository
{
    public class ReportConfigurationRepository : IReportConfigurationRepository
    {
        private readonly IntegrationDbContext _context;

        public ReportConfigurationRepository(IntegrationDbContext context)
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

        public IEnumerable<ReportConfiguration> GetAllActive()
        {
            return _context.ReportConfigurations.Where(where => where.ActiveStatus.Equals(true)).ToList();
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
            var local = _context.Set<ReportConfiguration>()
            .Local
            .FirstOrDefault(entry => entry.Id.Equals(config.Id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _context.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _context.Entry(config).State = EntityState.Modified;

            // save 
            _context.SaveChanges();
            return config;
        }
    }
}
