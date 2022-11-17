using IntegrationAPI;
using IntegrationLibrary.BloodBanks.Model;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.BloodReport.Service;
using IntegrationLibrary.BloodUsages.Service;
using IntegrationLibrary.ReportConfigurations.Service;
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
    public class BloodUsageReportTest : BaseIntegrationTest
    {
        public BloodUsageReportTest(TestDatabaseFactory<Startup> factory) : base(factory) {}

        private static BbReportService SetupReportService(IServiceScope scope)
        {
            return new BbReportService(scope.ServiceProvider.GetRequiredService<IBbReportRepository>(), scope.ServiceProvider.GetRequiredService<IBloodUsageService>(),
                scope.ServiceProvider.GetRequiredService<IBloodBankService>(), scope.ServiceProvider.GetRequiredService<IBbReportConfigService>());
        }

        [Fact]
        public void Checks_propper_data_retrieval()
        {
            using var scope = Factory.Services.CreateScope();
            BbReportService reportService = SetupReportService(scope);

            var result = reportService.GetAll();

            Assert.NotNull(result);
        }
        [Fact]
        public void Checks_propper_data_send()
        {
            using var scope = Factory.Services.CreateScope();
            BbReportService reportService = SetupReportService(scope);

            BloodBank bloodBankTest = new BloodBank();
            bloodBankTest.Id = new Guid("32db7839-f8a4-4c8b-9486-80f783ed6746");
            BloodUsageReport bloodUsageReportTest = new BloodUsageReport();
            bloodUsageReportTest.BloodBank = bloodBankTest;
            bloodUsageReportTest.timeOfCreation = DateTime.Now;
            var result = reportService.Create(bloodUsageReportTest);

            Assert.NotNull(result);
        }
        [Fact]
        public void Checks_inpropper_data_send()
        {
            using var scope = Factory.Services.CreateScope();
            BbReportService reportService = SetupReportService(scope);

            BloodBank bloodBankTest = new BloodBank();
            bloodBankTest.Id = new Guid("42db7839-f8a4-4c8b-9486-80f783ed6746"); //this Guid does not exist in db
            BloodUsageReport bloodUsageReportTest = new BloodUsageReport();
            bloodUsageReportTest.BloodBank = bloodBankTest;
            bloodUsageReportTest.timeOfCreation = DateTime.Now;
            var result = reportService.Create(bloodUsageReportTest);

            Assert.Null(result);
        }
    }
}
