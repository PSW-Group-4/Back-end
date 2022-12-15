using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.AppointmentReport.Service;
using HospitalLibrary.MedicalReport.Services;
using HospitalLibrary.Reports.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using Xunit;

namespace TestHospitalApp.IntegrationTesting
{
    public class AppointmentReportPdfTest : BaseIntegrationTest
    {
        public AppointmentReportPdfTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static ReportController SetupReportController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<IReportService>(), scope.ServiceProvider.GetRequiredService<IMedicalAppointmentReportService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Generate_pdf_patient_diagnose()
        {
            using var scope = Factory.Services.CreateScope();
            var reportController = SetupReportController(scope);

            Guid reportId = new Guid("058eb841-3975-4c7a-83ad-8b81dd6744d9");
            string[] s = { "pacijent", "dijagnoza" };
            List<String> settings = new List<string>(s);

            byte[] pdf = ((CreatedAtActionResult)reportController.GenerateSeveralPdf(reportId,settings))?.Value as byte[];
            pdf.ShouldBeNull();
        }

        [Fact]
        public void Generate_pdf_drugs()
        {
            using var scope = Factory.Services.CreateScope();
            var reportController = SetupReportController(scope);

            Guid reportId = new Guid("058eb841-3975-4c7a-83ad-8b81dd6744d9");
            string[] s = { "lek" };
            List<String> settings = new List<string>(s);

            byte[] pdf = ((CreatedAtActionResult)reportController.GenerateSeveralPdf(reportId, settings))?.Value as byte[];
            pdf.ShouldBeNull();
        }

        [Fact]
        public void Generate_pdf_empty()
        {
            using var scope = Factory.Services.CreateScope();
            var reportController = SetupReportController(scope);

            Guid reportId = new Guid("058eb841-3975-4c7a-83ad-8b81dd6744d9");
            string[] s = { "" };
            List<String> settings = new List<string>(s);

            byte[] pdf = ((CreatedAtActionResult)reportController.GenerateSeveralPdf(reportId, settings))?.Value as byte[];
            pdf.ShouldBeNull();
        }
    }
}
