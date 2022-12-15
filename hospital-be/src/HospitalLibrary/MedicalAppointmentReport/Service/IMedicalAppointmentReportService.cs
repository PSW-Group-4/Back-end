using HospitalLibrary.AppointmentReport.Model;
using HospitalLibrary.Reports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.AppointmentReport.Service
{
    public interface IMedicalAppointmentReportService
    {
        byte[] GeneratePdf(MedicalAppointmentReport medicalAppointmentReport);
    }
}
