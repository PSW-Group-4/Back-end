using HospitalLibrary.Core.Repository;
using HospitalLibrary.Infrastructure.CRUD;
using HospitalLibrary.Reports.Model;
using iTextSharp.text;
using System;
using System.Collections.Generic;

namespace HospitalLibrary.Reports.Repository
{
    public interface IReportRepository : IRepositoryBase<Report>
    {
        public Report GetByMedicalAppointmentId(Guid id);
        public List<Report> GetBySymptom(String sipmtom);
        public List<Report> GetByPrescription(String prescription);
        public List<Report> GetByPatientName(String name);
        public List<Report> GetByPatientSurname(String name);
        public List<Report> BasicSearch(String search);
        public List<Report> AdvancedSearch(String search);
    }
}
