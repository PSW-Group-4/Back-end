using HospitalLibrary.AppointmentReport.Model;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Exceptions;
using HospitalLibrary.Reports.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestHospitalApp.UnitTesting.VOTest
{
    public class MedicalAppointmentReportTest
    {
        [Fact]
        public void Valid_report()
        {
            string s = "lek";
            List<String> strings = new List<string>();
            strings.Add(s);
            Report r = new Report();

            MedicalAppointmentReport medicalAppointmentReport = new MedicalAppointmentReport(r, strings);

            medicalAppointmentReport.ShouldNotBeNull();

            
        }
        [Fact]
        public void Invalid_settings_report()
        {
            string s = "Srbija" ;
            List<String> strings = new List<string>();
            strings.Add(s);
            Report r = new Report();

            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                MedicalAppointmentReport medicalAppointmentReport = new MedicalAppointmentReport(r, strings);
            });
        }
        [Fact]
        public void Invalid_null_report()
        {
            string s = "dijagnoza";
            List<String> strings = new List<string>();
            strings.Add(s);
            Report r = null;



            Should.Throw<ValueObjectValidationFailedException>(() =>
            {
                MedicalAppointmentReport medicalAppointmentReport = new MedicalAppointmentReport(r, strings);
            });
        }
    }
}
