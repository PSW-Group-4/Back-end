using HospitalLibrary.Reports.Model;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Reports.Service
{
    public interface IReportService
    {
        IEnumerable<Report> GetAll();
        Report GetById(Guid id);
        Report Create(Report report);
        Report Update(Report report);
        void Delete(Guid symptomId);
        public Report GetByMedicalAppointmentId(Guid id);

        public List<Report> GetBySymptom(String sipmtom);
        public List<Report> GetByPrescription(String prescription);
        public List<Report> GetByPatientName(String name);
        public List<Report> GetByPatientSurname(String name);
        public List<Report> BasicSearch(String search);
        public List<Report> AdvancedSearch(String search);
    }
}
