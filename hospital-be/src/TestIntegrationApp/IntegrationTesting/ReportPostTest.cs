using IntegrationAPI;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodBanks.Service;
using IntegrationLibrary.BloodReport.Service;
using IntegrationLibrary.BloodUsages.Service;
using IntegrationLibrary.Exceptions;
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
    public class ReportPostTest : BaseIntegrationTest
    {
        public ReportPostTest(TestDatabaseFactory<Startup> factory) : base(factory)
        {
        }

        private static BbReportService SetupService(IServiceScope scope)
        {
            return new BbReportService(scope.ServiceProvider.GetRequiredService<IBbReportRepository>(),
                scope.ServiceProvider.GetRequiredService<IBloodUsageService>(),
                scope.ServiceProvider.GetRequiredService<IBloodBankService>(),
                scope.ServiceProvider.GetRequiredService<IBbReportConfigService>()
                );
        }

        [Fact]
        public void Posts_to_all_banks()
        {
            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);

            List<String> bankIds = new List<String>();
            //TODO change to real db test data
            bankIds.Add("guid1");
            bankIds.Add("guid2");

            var result = service.CreateMultiple(bankIds);

            Assert.NotNull(result);
        }
        [Fact]
        public void Fails_to_post_404()
        {
            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);

            List<String> bankIds = new List<String>();
            //TODO change to real db test data
            bankIds.Add("guid1");

            Assert.Throws<NotFoundException>(() => service.CreateMultiple(bankIds));
        }
    }
}
