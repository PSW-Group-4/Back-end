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
                scope.ServiceProvider.GetRequiredService<IReportConfigurationService>()
                );
        }

        [Fact]
        public void Posts_to_all_banks()
        {
            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);

            List<String> bankIds = new List<String>();
            //TODO change to real db test data
            bankIds.Add("32db7839-f8a4-4c8b-9486-80f783ed6746");
            //bankIds.Add("guid2");

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
            bankIds.Add("9de4cbb3-6eca-458d-86cf-f9683f6c9fb4");

            Assert.Throws<NotFoundException>(() => service.CreateMultiple(bankIds));
        }
    }
}
