using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.Exceptions;
using IntegrationLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.BloodBanks.Repository
{
    public class BbReportRepository : IBbReportRepository
    {
        private readonly IntegrationDbContext _context;

        public BbReportRepository(IntegrationDbContext context)
        {
            _context = context;
        }

        public BloodUsageReport Create(BloodUsageReport bloodUsageReport)
        {
            _context.BloodUsageReports.Add(bloodUsageReport);
            _context.SaveChanges();
            return bloodUsageReport;
        }

        public IEnumerable<BloodUsageReport> GetAll()
        {
            return _context.BloodUsageReports.ToList();
        }

        public List<string> GetAllIdsForReports()
        {
            throw new NotImplementedException();    
        }

        public IEnumerable<BloodUsageReport> GetByBbId(Guid id)
        {
            return _context.BloodUsageReports.Where(report => report.BloodBank.Id == id).ToList();

        }

        public BloodUsageReport GetById(Guid id)
        {
            BloodUsageReport report = _context.BloodUsageReports.Find(id);
            if (report == null)
            {
                throw new NotFoundException();
            }
            else
            {
                return report;
            }
        }

        public BloodUsageReport GetLastByBbId(Guid id)
        {
            return _context.BloodUsageReports.Where(report => report.BloodBank.Id == id)
                .OrderByDescending(report => report.timeOfCreation).FirstOrDefault();
        }

        public BloodUsageReport Update(BloodUsageReport bloodUsageReport)
        {
            throw new NotImplementedException();
        }
    }
}
