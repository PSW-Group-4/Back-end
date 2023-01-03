using IntegrationAPI;
using IntegrationAPI.Communications;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dtos;
using IntegrationAPI.Dtos.BloodProducts;
using IntegrationAPI.Dtos.BloodTypes;
using IntegrationAPI.Dtos.Tenders;
using IntegrationLibrary.BloodRequests.Model;
using IntegrationLibrary.BloodRequests.Repository;
using IntegrationLibrary.BloodRequests.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository;
using IntegrationLibrary.Tendering.Service;
using TestIntegrationApp.Setup;
using Xunit;
namespace TestIntegrationApp.IntegrationTesting
{
    public class TenderTests : BaseIntegrationTest
    {

        public TenderTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static TenderController SetupController(IServiceScope scope)
        {
            return new TenderController(scope.ServiceProvider.GetRequiredService<ITenderService>(), new TenderConverter());
        }
        private static TenderService SetupService(IServiceScope scope)
        {
            return new TenderService(scope.ServiceProvider.GetRequiredService<ITenderRepository>());
        }

        [Fact]

        public void Creates_tender()
        {
            using var scope = Factory.Services.CreateScope();
            TenderController tenderController = SetupController(scope);
            List<BloodDto> bloodProductDtos = new()
            {
                new BloodDto(new BloodTypeDto("A", "POSITIVE"), 5000)
            };

            TenderDto tenderDto = new()
            {
                Blood = bloodProductDtos,
                Deadline = DateTime.Now.AddDays(3).ToString(),
            };

            tenderController.Create(tenderDto);
            IEnumerable<Tender> result = ((OkObjectResult)tenderController.GetAll())?.Value as IEnumerable<Tender>;

            Assert.Single(result);
        }
    }
}
