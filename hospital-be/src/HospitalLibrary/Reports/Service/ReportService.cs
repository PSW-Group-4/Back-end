using HospitalLibrary.Reports.Model;
using HospitalLibrary.Reports.Repository;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Reports.Service
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }
        public IEnumerable<Report> GetAll()
        {
            return _reportRepository.GetAll();
        }

        public Report GetById(Guid id)
        {
            return _reportRepository.GetById(id);
        }

        public Report Create(Report report)
        {
            return _reportRepository.Create(report);
        }

        public Report Update(Report report)
        {
            return _reportRepository.Update(report);
        }

        public void Delete(Guid id)
        {
            _reportRepository.Delete(id);
        }
    }
}
