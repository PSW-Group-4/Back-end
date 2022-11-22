using AutoMapper;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegrationApp.Setup;
using Xunit;

namespace TestIntegrationApp.IntegrationTesting
{
   public class BloodRequestTests : BaseIntegrationTest
    {
        public BloodRequestTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodRequestService SetupService(IServiceScope scope)
        {
            return new BloodRequestService(scope.ServiceProvider.GetRequiredService<IBloodRequestRepository>());
        }
        private static BloodRequestController SetupController(IServiceScope scope)
        {
            return new BloodRequestController(scope.ServiceProvider.GetRequiredService<IBloodRequestService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }
        [Fact]
        public void Retrieves_all_requests()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            var result = ((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodRequest>;
            Assert.NotNull(result);
        }
       
    }
}
