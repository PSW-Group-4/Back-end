﻿using AutoMapper;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dtos.BloodRequests;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.Extensions.DependencyInjection;
using TestIntegrationApp.Setup;
using Xunit;
using System;

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
            BloodRequestsCreateDto bloodRequest = new BloodRequestsCreateDto
            {
                bloodType = BloodType.A,
                reasonsWhyBloodIsNeeded = "Reason",
                bloodAmountInMilliliters = 100.00,
                DateTime = DateTime.Now,
            };
            var create = controller.Create(bloodRequest);
            
            var result = controller.GetAll();

            Assert.NotNull(result);
        }
    }
}
