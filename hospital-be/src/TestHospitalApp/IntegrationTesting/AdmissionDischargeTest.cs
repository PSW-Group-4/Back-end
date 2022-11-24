using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.AdmissionHistory;
using HospitalLibrary.AdmissionHistories.Model;
using HospitalLibrary.AdmissionHistories.Service;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.BloodConsumptionRecords.Model;
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
    public class AdmissionDischargeTest : BaseIntegrationTest
    {   
        public AdmissionDischargeTest(TestDatabaseFactory<Startup> factory) : base(factory){ }

        private static AdmissionHistoryController SetupAdmissionDischargeController(IServiceScope scope)
        {
            return new AdmissionHistoryController(scope.ServiceProvider.GetRequiredService<IAdmissionHistoryService>(), scope.ServiceProvider.GetRequiredService<IMapper>(), scope.ServiceProvider.GetRequiredService<IAdmissionService>());
        }

        [Fact]
        public void Discharge_admission()
        {
            using var scope = Factory.Services.CreateScope();
            var admissionController = SetupAdmissionDischargeController(scope);

            AdmissionHistoryRequestDto admissionDto = new()
            {
                AdmissionId = new Guid("9b75b261-e305-4f6f-9990-97cb2d13d174"),
                DischargeDate = DateTime.Now,
                DischargeReason = "Zato sto je ozdravio"
            };

            AdmissionHistory admission = ((ObjectResult)admissionController.Create(admissionDto)).Value as AdmissionHistory; ;
            admission.ShouldNotBeNull();
        }

        [Fact]
        public void Discharge_admission_wrong_id()
        {
            using var scope = Factory.Services.CreateScope();
            var admissionController = SetupAdmissionDischargeController(scope);

            AdmissionHistoryRequestDto admissionDto = new()
            {
                AdmissionId = new Guid("9b75b111-e305-4f6f-9990-97cb2d13d174"),
                DischargeDate = DateTime.Now,
                DischargeReason = "Zato sto je ozdravio"
            };

            AdmissionHistory admission = ((ObjectResult)admissionController.Create(admissionDto))?.Value as AdmissionHistory; ;
            admission.ShouldBeNull();
        }
    }
}
