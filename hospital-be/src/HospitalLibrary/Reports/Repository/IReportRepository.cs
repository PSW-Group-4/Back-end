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
    }
}
