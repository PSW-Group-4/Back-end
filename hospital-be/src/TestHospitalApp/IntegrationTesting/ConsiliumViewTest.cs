using AutoMapper;
using HospitalAPI;
using HospitalAPI.Controllers;
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
    }
}
