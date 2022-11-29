using AutoMapper;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationLibrary.BloodBanks.Model;
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
        [Fact]
        public void Retrieves_not_approved()
        {
            bool success = true;
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            var result = ((OkObjectResult)controller.GetUnapproved())?.Value as IEnumerable<BloodRequest>;
            if (result != null)
                foreach (BloodRequest request in result)
                {
                    success = success && !request.IsApproved;
                }
            else success = false;
            Assert.True(success);
        }
        [Fact]
        public void Update()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodRequestsCreateDto bloodRequest = new BloodRequestsCreateDto
            {
                BloodType = new BloodType(BloodGroup.A, RHFactor.NEGATIVE),
                ReasonsWhyBloodIsNeeded = "Reason",
                BloodAmountInMilliliters = 100.00,
                DateTime = DateTime.Now,
            };
            var create = controller.Create(bloodRequest);
            var request = (((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodRequestEditDto>).First();
            request.BloodAmountInMilliliters = 200.00;
            var result = ((OkObjectResult)controller.Update(request))?.Value as BloodRequestEditDto;
            Assert.True(result.BloodAmountInMilliliters == 200.00);

        }
       
    }
}
