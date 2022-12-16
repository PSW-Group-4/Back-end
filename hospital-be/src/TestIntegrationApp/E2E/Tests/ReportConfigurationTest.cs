using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestIntegrationApp.E2E.Pages;
using Xunit;

namespace TestIntegrationApp.E2E.Tests
{
    public class ReportConfigurationTest : IDisposable
    {
        public ReportConfigurationTest()
        {
            ChromeOptions options = new();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            Driver = new ChromeDriver(options);

            Page = new ReportConfigurationPage(Driver);
            Page.Navigate();
        }
        public IWebDriver Driver { get; set; }
        public ReportConfigurationPage Page { get; set; }
        public LoginPage LoginPage { get; set; }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void Configuration_success()
        {
            LoginAsManager();
            Page = new(Driver);
            Page.Navigate();
            Page.NewButtonClick();
            Page.SelectInformation("34361aaf-b0fa-4ade-a00e-9b46a8db177a", "true", "1");
            Page.SaveButtonClick();
            Page.Navigate(); //ref

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));

            wait.Until(drv => drv.FindElements(By.ClassName("item-wrapper")));

            Assert.Equal(@"http://localhost:4200/manager/bloodBanks", Driver.Url);
            Page.ValidateNewEntry("34361aaf-b0fa-4ade-a00e-9b46a8db177a", "true", "1").ShouldBe(true);

        }
        private void LoginAsManager()
        {
            LoginPage = new LoginPage(Driver);
            Driver.Navigate().GoToUrl("http://localhost:4200/login");
            LoginPage.EnterUsernameAndPassword("manager1", "manager1");
            LoginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.Url == "http://localhost:4200/manager");
        }

    }
}

