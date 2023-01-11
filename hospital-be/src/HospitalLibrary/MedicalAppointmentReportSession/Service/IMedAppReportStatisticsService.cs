using HospitalLibrary.MedicalAppointmentReportSession.Model.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.MedicalAppointmentReportSession.Service
{
    public interface IMedAppReportStatisticsService
    {
        public IDictionary<SelectionReport, int> GetNumberEachStep();
        public IDictionary<SelectionReport, double> GetTimeEachStep();

        public IDictionary<string, int> GetReportTable();
        public IDictionary<string, int> GetNumberSteps();
        public IDictionary<string, double> GetTimeSteps();
        public IDictionary<string, double> GetDoctorTimeSteps();
    }
}
