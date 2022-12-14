using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Reports.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HospitalLibrary.AppointmentReport.Model
{
    public class MedicalAppointmentReport
    {
        public Report Report { get; }
        public List<String> Settings { get; }

        public MedicalAppointmentReport(Report report, List<string> settings)
        {
            Report = report;
            Settings = settings;
            if (!IsValid())
            {
                throw new ValueObjectValidationFailedException("Report doesn't exist !");
            }
        }

        private bool IsValid()
        {
            if (String.IsNullOrEmpty(Report.Id.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
