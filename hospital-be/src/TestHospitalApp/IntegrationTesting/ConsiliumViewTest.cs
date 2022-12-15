using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
using HospitalAPI.Dtos.Consilium;
using HospitalLibrary.Admissions.Model;
using HospitalLibrary.Admissions.Service;
using HospitalLibrary.Consiliums.Model;
using HospitalLibrary.Consiliums.Service;
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
    public class ConsiliumViewTest : BaseIntegrationTest
    {
        public ConsiliumViewTest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static ConsiliumController SetupConsiliumController(IServiceScope scope)
        {
            return new ConsiliumController(scope.ServiceProvider.GetRequiredService<IConsiliumService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Return_all_consiliums()
        {
            using var scope = Factory.Services.CreateScope();
            var consiliumController = SetupConsiliumController(scope);

            List<Consilium> result = ((OkObjectResult)consiliumController.GetAll())?.Value as List<Consilium>;
            result.ShouldNotBeNull();
        }


        [Fact]
        public void Add_new_consilium_with_doctors()
        {
            using var scope = Factory.Services.CreateScope();
            var consiliumController = SetupConsiliumController(scope);
            List<Guid> doctorsID = new List<Guid>();
            Guid dr = new Guid("5c125fba-1318-4f4b-b153-90d75e60625e");

            doctorsID.Add(dr);
            ConsiliumRequestDto consiliumRequest = new ConsiliumRequestDto()
            {
                Reason = "Pomoch",
                DateStart = DateTime.Today,
                DateEnd = DateTime.Today.AddDays(1),
                Duration = 1,
                isDoctor = true,
                Specialities = new List<string>(),
                DoctorsId = doctorsID
            };


            Consilium result1 = ((OkObjectResult)consiliumController.Create(consiliumRequest))?.Value as Consilium;
            result1.ShouldNotBeNull();
            List<Consilium> result = ((OkObjectResult)consiliumController.GetAll())?.Value as List<Consilium>;
            result.Count().ShouldBe(1);
        }

        [Fact]
        public void Add_new_consilium_with_specialities()
        {
            using var scope = Factory.Services.CreateScope();
            var consiliumController = SetupConsiliumController(scope);

            List<string> spec = new List<string>();
            spec.Add("Surgeon");
            ConsiliumRequestDto consiliumRequest = new ConsiliumRequestDto()
            {
                Reason = "Pomoch",
                DateStart = DateTime.Today,
                DateEnd = DateTime.Today.AddDays(1),
                Duration = 1,
                isDoctor = false,
                Specialities = spec,
                DoctorsId = new List<Guid>(),
            };


            Consilium result1 = ((OkObjectResult)consiliumController.Create(consiliumRequest))?.Value as Consilium;
            result1.ShouldNotBeNull();
            List<Consilium> result = ((OkObjectResult)consiliumController.GetAll())?.Value as List<Consilium>;
            result.Count().ShouldBe(1);
        }
    }
}
