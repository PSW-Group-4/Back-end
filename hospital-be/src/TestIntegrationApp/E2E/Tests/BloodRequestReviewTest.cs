using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
    public class BloodRequestReviewTest
    {
        public BloodRequestReviewTest() 
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

                Page = new BloodRequestReviewPage(Driver);
                Page.Navigate();
        }
            public IWebDriver Driver { get; set; }
            public BloodRequestReviewPage Page { get; set; }
            public LoginPage LoginPage { get; set; }
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
        [Fact]
        public void Reject_success()
        {
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            LoginAsManager();
            Page = new(Driver);
            Page.Navigate();
            Page.PressRejectButton();
            Page.EnterInformation("I reject");
            Page.PressSubmitButton();
            Assert.Equal(@"http://localhost:4200/manager/viewRequests", Driver.Url);
        }
        [Fact]
        public void Accept_success()
        {
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            LoginAsManager();
            Page = new(Driver);
            Page.Navigate();
            Page.PressAcceptButton();
            Assert.Equal(@"http://localhost:4200/manager/viewRequests", Driver.Url);
        }
        private ChromeOptions GetOptions()
        {
            ChromeOptions options = new();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            return options;
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
