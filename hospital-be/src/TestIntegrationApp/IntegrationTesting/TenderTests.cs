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
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.Utilities;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.EventSourcing;
using IntegrationLibrary.Tendering.DomainEvents.Base;

namespace TestIntegrationApp.IntegrationTesting
{
    public class TenderTests : BaseIntegrationTest
    {

        public TenderTests(TestDatabaseFactory<Startup> factory) : base(factory) { }
        private static TenderController SetupController(IServiceScope scope)
        {
            return new TenderController(scope.ServiceProvider.GetRequiredService<ITenderService>(), new TenderConverter(), new BloodBankService(scope.ServiceProvider.GetRequiredService<IBloodBankRepository>(), scope.ServiceProvider.GetRequiredService<IPasswordHandler>()));
        }
        private static TenderService SetupService(IServiceScope scope)
        {
            return new TenderService(scope.ServiceProvider.GetRequiredService<ITenderRepository>(), scope.ServiceProvider.GetRequiredService<IEventStore<TenderingEvent>>());
        }
        public TenderDto CreateTenderDto()
        {
            List<BloodDto> bloodProductDtos = new()
            {
                new BloodDto(new BloodTypeDto("A", "POSITIVE"), 5000)
            };

            TenderDto tenderDto = new()
            {
                Blood = bloodProductDtos,
                Deadline = DateTime.Now.AddDays(3).ToString(),
            };

            return tenderDto;
        }

        [Fact]

        public void Creates_tender()
        {
            using var scope = Factory.Services.CreateScope();
            TenderController tenderController = SetupController(scope);
            TenderDto tenderDto = CreateTenderDto();
            tenderController.Create(tenderDto);
            IEnumerable<Tender> result = ((OkObjectResult)tenderController.GetAll())?.Value as IEnumerable<Tender>;

            Assert.Single(result);
        }

        [Fact]
        public void Chooses_Winner()
        {
            using var scope = Factory.Services.CreateScope();
            TenderController tenderController = SetupController(scope);
            TenderDto tenderDto = CreateTenderDto();
            tenderController.Create(tenderDto);
            Tender tender = (((OkObjectResult)tenderController.GetAll())?.Value as IEnumerable<Tender>).First();
            tenderController.ChooseWinner(tender.Id.ToString(), "37ae7862-f847-4a39-b39f-f8ff31452b5e");
            
            Assert.True(tender.Winner.Id.ToString().Equals("37ae7862-f847-4a39-b39f-f8ff31452b5e") && tender.Status.Equals(TenderStatus.PENDING_WINNER_CONFIRMATION));
        }

        [Fact]
        public void Confirms_Winner()
        {
            using var scope = Factory.Services.CreateScope();
            TenderController tenderController = SetupController(scope);
            TenderDto tenderDto = CreateTenderDto();
            tenderController.Create(tenderDto);
            Tender tender = (((OkObjectResult)tenderController.GetAll())?.Value as IEnumerable<Tender>).First();
            tenderController.ChooseWinner(tender.Id.ToString(), "37ae7862-f847-4a39-b39f-f8ff31452b5e");
            tenderController.ConfirmWinner(tender.Id);
            Assert.True(tender.Status.Equals(TenderStatus.COMPLETED));
        }
    }
}
