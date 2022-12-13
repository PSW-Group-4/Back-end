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
    }
}
