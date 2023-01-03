using HospitalAPI;
using HospitalAPI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TestHospitalApp.Setup;
using AutoMapper;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using HospitalLibrary.Reports.Service;
using HospitalAPI.Dtos.Report;
using HospitalLibrary.Symptoms.Model;
using HospitalLibrary.Symptoms.Service;
using HospitalLibrary.Medicines.Service;
using HospitalLibrary.Medicines.Model;
using HospitalAPI.Dtos.Prescription;
using HospitalLibrary.AppointmentReport.Service;

namespace TestHospitalApp.IntegrationTesting
{
    public class CreateReport : BaseIntegrationTest
    {
        public CreateReport(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static ReportController SetupReportController(IServiceScope scope)
        {
            return new ReportController(scope.ServiceProvider.GetRequiredService<IReportService>(),scope.ServiceProvider.GetRequiredService<IMedicalAppointmentReportService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        private static SymptomController SetupSymptomController(IServiceScope scope)
        {
            return new SymptomController(scope.ServiceProvider.GetRequiredService<ISymptomService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        private static MedicineController SetupMedicineController(IServiceScope scope)
        {
            return new MedicineController(scope.ServiceProvider.GetRequiredService<IMedicineService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Creates_report()
        {
            using var scope = Factory.Services.CreateScope();
            var reportController = SetupReportController(scope);
            var symptomController = SetupSymptomController(scope);
            var medicineController = SetupMedicineController(scope);

            List<Symptom> symptoms = ((OkObjectResult)symptomController.GetAll())?.Value as List<Symptom>;
            List<Medicine> medicines = ((OkObjectResult)medicineController.GetAll())?.Value as List<Medicine>;

            PrescriptionRequestDto prescription = new PrescriptionRequestDto
            {
                Medicines = new List<Medicine>(medicines.GetRange(0, 2))
            };

            List<PrescriptionRequestDto> prescriptions = new List<PrescriptionRequestDto>();
            prescriptions.Add(prescription);

            ReportRequestDto reportRequest = new ReportRequestDto
            {
                MedicalAppointmentId = new Guid("9d01e700-70a4-4b1c-958c-2c587ec94b4b"),
                Text = "Create report test",
                Symptoms = new List<Symptom>(symptoms.GetRange(0, 2)),
                Prescriptions = prescriptions,
                DateTime = DateTime.Now,
            };
            var create = reportController.Create(reportRequest);

            var result = reportController.GetAll();

            Assert.NotNull(result);
        }
    }
}
