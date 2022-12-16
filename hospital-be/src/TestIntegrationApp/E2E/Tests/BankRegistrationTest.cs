using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestIntegrationApp.E2E.Pages;
using Xunit;

namespace TestIntegrationApp.E2E.Tests
{
    public class BankRegistrationTest : IDisposable
    {
        public BankRegistrationTest()
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

            Page = new BankRegistrationPage(Driver);
            Page.Navigate();
        }

        public IWebDriver Driver { get; set; }
        public BankRegistrationPage Page { get; set; }
        public LoginPage LoginPage { get; set; }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void Registration_success()
        {
            LoginAsManager();
            Page = new(Driver);
            Page.Navigate();
            Page.EnterInformation("Bankicaa2", "isaproject2022233@gmail.com", "localhost:8080");
            Page.PressSubmitButton();

            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));

            wait.Until(drv => drv.FindElement(By.ClassName("table-title")));

            Assert.Equal(@"http://localhost:4200/manager/bloodBanks", Driver.Url);
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