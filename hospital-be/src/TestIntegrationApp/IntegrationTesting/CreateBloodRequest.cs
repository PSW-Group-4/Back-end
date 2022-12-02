using AutoMapper;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.Extensions.DependencyInjection;
using TestIntegrationApp.Setup;
using Xunit;
using System;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationLibrary.Common;
using IntegrationAPI.Dtos.BloodProducts;
using IntegrationAPI.Dtos.BloodTypes;

namespace TestIntegrationApp.IntegrationTesting
{
    public class CreateBloodRequest : BaseIntegrationTest
    {
        public CreateBloodRequest(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BloodRequestController SetupController(IServiceScope scope)
        {
            return new BloodRequestController(scope.ServiceProvider.GetRequiredService<IBloodRequestService>(), scope.ServiceProvider.GetRequiredService<IMapper>());
        }

        [Fact]
        public void Creates_blood_request()
        {
            using var scope = Factory.Services.CreateScope();
            var controller = SetupController(scope);
            BloodTypeDto bloodTypeDto = new BloodTypeDto("A", "POSITIVE");
            BloodProductDto bloodProductDto = new BloodProductDto(bloodTypeDto, 1000);
            BloodRequestsCreateDto bloodRequest = new BloodRequestsCreateDto
            {
                BloodProduct = bloodProductDto,
                Reasons = "Reason",
                IsUrgent = true,
                SendOnDate = DateTime.UtcNow
            };
            var create = controller.Create(bloodRequest);
            
            var result = controller.GetAll();

            Assert.NotNull(result);
        }
    }
}
