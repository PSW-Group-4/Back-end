using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.AdmissionHistory;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.MedicalReport.Services;
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
    public class MedicalReportTest : BaseIntegrationTest
    {
        public MedicalReportTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static MedicalRecordReportController SetupMedicalRecordReportController(IServiceScope scope)
        {
            return new MedicalRecordReportController(scope.ServiceProvider.GetRequiredService<IMedicalRecordService>(), scope.ServiceProvider.GetRequiredService<IAdmissionHistoryService>());
        }

        [Fact]
        public void Generate_pdf()
        {
            using var scope = Factory.Services.CreateScope();
            var admissionController = SetupMedicalRecordReportController(scope);

            Guid admissionHistoryId = new Guid("11942a9c-100e-489a-8434-98704889d8ed");

            byte[] pdf = ((CreatedAtActionResult)admissionController.GenerateSeveralPdf(admissionHistoryId))?.Value as byte[];
            pdf.ShouldBeNull();
        }
    }
}
