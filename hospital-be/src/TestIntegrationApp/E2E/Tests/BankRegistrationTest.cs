using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestIntegrationApp.E2E.Pages;
using Xunit;

namespace TestIntegrationApp.E2E.Tests
{
    public class BankRegistrationTest : IDisposable
    {
        public IWebDriver Driver { get; set; }
        public BankRegistrationPage Page { get; set; }

        public BankRegistrationTest()
        {
            ChromeOptions options = new ChromeOptions();
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
        
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }
        
        [Fact]
        public void Registration_success()
        {
            Page.EnterInformation("Bankicaa", "isaproject202223@gmail.com", "localhost:8080");
            Page.PressSubmitButton();
            
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            
            wait.Until(drv => drv.FindElement(By.ClassName("table-title")));

            Assert.Equal(@"http://localhost:4200/bloodBanks", Driver.Url);
        }
    }
}