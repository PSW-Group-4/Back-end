using HospitalLibrary.Exceptions;
using HospitalLibrary.Medicines.Model;
using HospitalLibrary.Prescriptions.Model;
using HospitalLibrary.Reports.Model;
using HospitalLibrary.Settings;
using HospitalLibrary.Symptoms.Model;
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
            List<Symptom> symptoms = new List<Symptom>(report.Symptoms);
            report.Symptoms.Clear();
            foreach (Symptom symptom in symptoms)
            {
                report.Symptoms.Add(_context.Symptoms.SingleOrDefault(s => s.Id.Equals(symptom.Id)));
            }
            List<Prescription> prescriptions = new List<Prescription>(report.Prescriptions);
            report.Prescriptions.Clear();

            foreach (Prescription prescription in prescriptions)
            {
                List<Medicine> medicines = new List<Medicine>(prescription.Medicines);
                prescription.Medicines.Clear();
                foreach (Medicine medicine in medicines)
                {
                    prescription.Medicines.Add(_context.Medicines.SingleOrDefault(m => m.Id.Equals(medicine.Id)));
                }
                report.Prescriptions.Add(prescription);
            }

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
