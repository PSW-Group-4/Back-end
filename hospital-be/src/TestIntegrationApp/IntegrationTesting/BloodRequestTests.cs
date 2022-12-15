using AutoMapper;
using IntegrationAPI;
using IntegrationAPI.Communications.Consumer;
using IntegrationAPI.Communications.Consumer.BloodRequestResponse;
using IntegrationAPI.Communications.Producer;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dtos.BloodProducts;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationAPI.Dtos.BloodTypes;
using IntegrationLibrary.BloodBankNews.Model;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Service;
using IntegrationLibrary.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections;
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
            return new BloodRequestController(scope.ServiceProvider.GetRequiredService<IBloodRequestService>(),
                scope.ServiceProvider.GetRequiredService<IBloodBankService>(),
                scope.ServiceProvider.GetRequiredService<IProducer>());
        }

        [Fact]
        public void Creates_blood_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodTypeDto bloodTypeDto = new BloodTypeDto("A", "POSITIVE");
            BloodDto bloodDto = new BloodDto(bloodTypeDto, 1000);
            BloodRequestsCreateDto bloodRequest = new BloodRequestsCreateDto
            {
                BloodDto = bloodDto,
                Reasons = "Reason",
                IsUrgent = true,
                SendOnDate = DateTime.UtcNow
            };
            var create = controller.Create(bloodRequest);

            var result = controller.GetAll();

            Assert.NotNull(result);
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
            var service = SetupService(scope);
            BloodTypeDto bloodTypeDto = new("A", "POSITIVE");
            BloodDto bloodDto = new(bloodTypeDto, 1000);
            BloodRequestsCreateDto bloodRequest = new()
            {
                BloodDto = bloodDto,
                Reasons = "Reason",
                IsUrgent = true,
                SendOnDate = DateTime.UtcNow
            };
            controller.Create(bloodRequest);
            var request = (((OkObjectResult)controller.GetAll())?.Value as IEnumerable<BloodRequest>).First();
            BloodRequestEditDto bloodRequestEditDto = new()
            {
                Id = request.Id,
                IsApproved = true,
            };
            controller.Manage(bloodRequestEditDto);
            var result = service.GetById(request.Id);
            Assert.True(result.IsApproved == true);

        }
    }
}
