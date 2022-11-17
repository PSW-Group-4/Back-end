using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.BloodSupplies.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.Setup;
using Xunit;
using Shouldly;
using HospitalLibrary.Admissions.Model;
using Microsoft.AspNetCore.Mvc;

namespace TestHospitalApp.IntegrationTesting
{
    public class AdmissionViewTest : BaseIntegrationTest
    {
        public AdmissionViewTest(TestDatabaseFactory<Startup> factory) : base(factory){ }

        private static AdmissionController SetupAdmissionController(IServiceScope scope)
        {
            return new AdmissionController(scope.ServiceProvider.GetRequiredService<IAdmissionService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Return_all_admissions()
        {
            using var scope = Factory.Services.CreateScope();
            var admissionController = SetupAdmissionController(scope);

            List<Admission> result = ((OkObjectResult)admissionController.GetAll())?.Value as List<Admission>;
            result.ShouldNotBeNull(); 
        }
    }
}
