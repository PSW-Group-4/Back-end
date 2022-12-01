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
using IntegrationLibrary.Tenders.Model;
using IntegrationLibrary.Tenders.Repository;
using IntegrationLibrary.Tenders.Service;
using IntegrationLibrary.Utilities;
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
   public class TenderApplicationTests : BaseIntegrationTest
    {
        public TenderApplicationTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static TenderApplicationController SetupController(IServiceScope scope)
        {
            return new TenderApplicationController(scope.ServiceProvider.GetRequiredService<ITenderApplicationService>(), scope.ServiceProvider.GetRequiredService <IMapper>());
        }
        private static TenderApplicationService SetupService(IServiceScope scope)
        {
            return new TenderApplicationService(scope.ServiceProvider.GetRequiredService<ITenderApplicationRepository>());
        }
        private static BloodBankService SetupBloodBankService(IServiceScope scope)
        {
            return new BloodBankService(scope.ServiceProvider.GetRequiredService<IBloodBankRepository>(), scope.ServiceProvider.GetRequiredService<IPasswordHandler>());
        }
        private static TenderService SetupTenderService(IServiceScope scope)
        {
            return new TenderService(scope.ServiceProvider.GetRequiredService<ITenderRepository>());
        }
        [Fact]

        public void Creates_tender_application()
        {
            using var scope = Factory.Services.CreateScope();
            TenderApplicationController tenderApplicationController = SetupController(scope);
            BloodBankService bloodBankService = SetupBloodBankService(scope);
            TenderService tenderService = SetupTenderService(scope);
            IEnumerable<BloodBank> banks = bloodBankService.GetAll();
            IEnumerable<Tender> tenders = tenderService.GetAll();
            ApplyForTenderDto applicationDto = new()
            {
                BloodBankId = banks.First().Id,
                TenderId = tenders.First().Id,
                PriceInRSD = 30000
            };

            tenderApplicationController.Apply(applicationDto);
            IEnumerable<TenderApplication> result = ((OkObjectResult)tenderApplicationController.GetAll())?.Value as IEnumerable<TenderApplication>;

            Assert.Single(result);
        }
    }
}
