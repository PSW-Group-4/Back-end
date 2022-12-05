using HospitalLibrary.Exceptions;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Settings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalLibrary.Reports.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly HospitalDbContext _context;
        public ReportRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Report> GetAll()
        {
            return _context.Reports.ToList();
        }

        public Report GetById(Guid id)
        {
            var result = _context.Reports.Find(id);
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result;
        }

        public Report Create(Report report)
        {
            _context.Reports.Add(report);
            _context.SaveChanges();
            return report;
        }
        public Report Update(Report report)
        {
            var updatingReport = _context.Reports.SingleOrDefault(r => r.Id == report.Id);
            if (updatingReport == null)
            {
                throw new NotFoundException();
            }

            updatingReport.Update(report);

            _context.SaveChanges();
            return updatingReport;
        }

        public void Delete(Guid reportId)
        {
            var report = GetById(reportId);
            _context.Reports.Remove(report);
            _context.SaveChanges();
        }
    }
}
