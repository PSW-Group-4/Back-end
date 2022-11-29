using IntegrationAPI;
using IntegrationAPI.Communications;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.Tenders.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestIntegrationApp.Setup;
using Xunit;
namespace TestIntegrationApp.IntegrationTesting
{
    public class TenderTests : BaseIntegrationTest
    {

        public TenderTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static TenderController SetupController(IServiceScope scope)
        {
            return new TenderController(scope.ServiceProvider.GetRequiredService<ITenderService>());
        }

        [Fact]

        public void Creates_tender()
        {
            using var scope = Factory.Services.CreateScope();
            TenderController tenderController = SetupController(scope);

            TenderDto tenderDto = new TenderDto
            {
                BloodType = IntegrationLibrary.BloodBanks.Model.BloodType.AB,
                RHFactor = IntegrationLibrary.BloodBanks.Model.RHFactor.NEGATIVE,
                Amount = 5000.0,
                DatePosted = DateTime.Now,
                Deadline = DateTime.Now.AddDays(3)
            };

            tenderController.Create(tenderDto);
            var result = tenderController.GetAll();

            Assert.NotNull(result);
        }
    }
}
