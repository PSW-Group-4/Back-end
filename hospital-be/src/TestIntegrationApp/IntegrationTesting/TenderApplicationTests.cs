using AutoMapper;
using IntegrationAPI;
using IntegrationAPI.Controllers;
using IntegrationAPI.Dtos.TenderApplications;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.TenderApplications.Model;
using IntegrationLibrary.TenderApplications.Repository;
using IntegrationLibrary.TenderApplications.Service;
using IntegrationLibrary.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository;
using IntegrationLibrary.Tendering.Service;
using TestIntegrationApp.Setup;
using Xunit;
using IntegrationLibrary.Tendering.DomainEvents.Base;
using IntegrationLibrary.EventSourcing;

namespace TestIntegrationApp.IntegrationTesting
{
   public class TenderApplicationTests : BaseIntegrationTest
    {
        public TenderApplicationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static TenderApplicationController SetupController(IServiceScope scope)
        {
            return new TenderApplicationController(scope.ServiceProvider.GetRequiredService<ITenderApplicationService>(), scope.ServiceProvider.GetRequiredService<ITenderService>(), scope.ServiceProvider.GetRequiredService<IBloodBankService>());
        }

        [Fact]

        public void Submits_tender_application()
        {
            using var scope = Factory.Services.CreateScope();
            TenderApplicationController tenderApplicationController = SetupController(scope);
            ApplyForTenderDto applicationDto = new()
            {
                BloodBank = "isaproject202223@gmail.com",
                TenderId = Guid.Parse("3d606bff-4875-4140-9b81-17ae261d698c"),
                Price = new Price(30000, "RSD")
            };

            tenderApplicationController.Submit(applicationDto);
            IEnumerable<TenderApplication> result = ((OkObjectResult)tenderApplicationController.GetAll())?.Value as IEnumerable<TenderApplication>;

            Assert.Single(result);
        }
    }
}
