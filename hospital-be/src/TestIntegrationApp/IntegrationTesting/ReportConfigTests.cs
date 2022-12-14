using IntegrationAPI;
using IntegrationAPI.Communications.Pdf;
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
    public class ReportConfigTests : BaseIntegrationTest
    {
        public ReportConfigTests(TestDatabaseFactory<Startup> factory) : base(factory) { }

        private static BbReportService SetupService(IServiceScope scope)
        {
            return new BbReportService(scope.ServiceProvider.GetRequiredService<IBbReportRepository>(), scope.ServiceProvider.GetRequiredService<IBloodUsageService>(),
                scope.ServiceProvider.GetRequiredService<IBloodBankService>(), scope.ServiceProvider.GetRequiredService<IReportConfigurationService>());
        }


        [Fact]
        public void Gets_ids_for_report_creation()
        {
            using var scope = Factory.Services.CreateScope();
            var service = SetupService(scope);

            var result = service.CreateAllTimeElapsed();
            foreach(var report in result)
            {
                PdfSender.SendPdf(IntegrationLibrary.Settings.PdfSenderResources.isaUrl, report.ReportPath);
            }
           
            Assert.NotNull(result);
        }
    }
}
