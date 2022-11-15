using IntegrationLibrary.BloodBanks.Model;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestIntegrationApp.UnitTesting.BloodUsageTests
{
    public class ObjectToHtmlTest
    {
        [Fact]
        public void Checks_if_object_is_converted()
        {
            BloodBank bloodBank = new BloodBank();
            bloodBank.Id = Guid.NewGuid();
            bloodBank.Name = "TestBank";
            bloodBank.ServerAddress = "localhost:8080/TestBank";
            bloodBank.EmailAddress = "psw.integrations.g4@gmail.com";
            bloodBank.Password = "1234";
            bloodBank.ApiKey = "takll0fr5iKieWBYIwwIYcD_xeAKF_D9yguE5PyPPLI8";

            BloodUsage usageApos = new BloodUsage();
            usageApos.Id = Guid.NewGuid();
            usageApos.type = BloodType.A;
            usageApos.rHFactor = RHFactor.POSITIVE;
            usageApos.milliliters = 650;

            BloodUsage usage0neg = new BloodUsage();
            usage0neg.Id = Guid.NewGuid();
            usage0neg.type = BloodType.O;
            usage0neg.rHFactor = RHFactor.NEGATIVE;
            usage0neg.milliliters = 350;

            ReportConfiguration repConfig = new ReportConfiguration();
            repConfig.Id = Guid.NewGuid();
            repConfig.BloodBank = bloodBank;
            repConfig.RequestFrequency = ReportFrequencyTitles.MONTHLY;
            repConfig.ActiveStatus = true;

            BloodUsageReport bloodUsageReport = new BloodUsageReport();
            bloodUsageReport.Id = Guid.NewGuid();
            bloodUsageReport.BloodBank = bloodBank;
            bloodUsageReport.ReportConfiguration = repConfig;
            bloodUsageReport.BloodUsage = new List<BloodUsage>();
            bloodUsageReport.BloodUsage.Add(usage0neg);
            bloodUsageReport.BloodUsage.Add(usageApos);
            bloodUsageReport.timeOfCreation = new DateTime(1970, 1, 1, 0, 0, 0);

            String html = bloodUsageReport.GenerateHtml();

            string testHtml = System.IO.File.ReadAllText(@"/UnitTesting/BloodUsageTests/BRHtmlTest.txt");

            bool htmlsAreEqual = (html == testHtml);

            htmlsAreEqual.ShouldBe(true);
        }
    }
}
