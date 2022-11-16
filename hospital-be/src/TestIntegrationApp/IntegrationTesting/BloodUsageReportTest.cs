using IntegrationAPI;
using IntegrationLibrary.BloodBanks.Repository;
using IntegrationLibrary.BloodReport.Service;
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

        private static BbReportService SetupService(IServiceScope scope)
        {
            return new BbReportService(scope.ServiceProvider.GetRequiredService<IBbReportRepository>());
        }

        [Fact]
        public void Checks_propper_data_retrieval()
        {

        }
        [Fact]
        public void Checks_propper_data_send()
        {

        }

    }
}
