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

        public Report GetByMedicalAppointmentId(Guid id)
        {
            return _reportRepository.GetByMedicalAppointmentId(id);
        }
        public List<Report> GetBySymptom(String sipmtom)
        {
            return _reportRepository.GetBySymptom(sipmtom);
        }
        public List<Report> GetByPrescription(String prescription)
        {
            return _reportRepository.GetByPrescription(prescription);
        }

        public List<Report> GetByPatientName(String name)
        {
            return _reportRepository.GetByPatientName(name);
        }
        public List<Report> GetByPatientSurname(String name)
        {
            return _reportRepository.GetByPatientSurname(name);
        }
        public List<Report> BasicSearch(String search)
        {
            return _reportRepository.BasicSearch(search); 
        }
        public List<Report> AdvancedSearch(String search)
        {
            return _reportRepository.AdvancedSearch(search);
        }
    }
}
