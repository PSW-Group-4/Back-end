using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestIntegrationApp.E2E.Pages;
using Xunit;

namespace TestIntegrationApp.E2E.Tests
{
    public class BloodSuppliesTest : IDisposable
    {
        public BloodSuppliesTest()
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

            Page = new BloodSuppliesPage(Driver);
            Page.Navigate();
        }

        public IWebDriver Driver { get; set; }
        public BloodSuppliesPage Page { get; set; }
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
            WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));
            wait.Until(drv => drv.FindElement(By.Id("email")));
            Page.PressOpenDialogButton();
            Page.EnterInformation("0-", "10");
            Page.PressSubmitButton();

            //WebDriverWait wait = new(Driver, TimeSpan.FromSeconds(10));

            //wait.Until(drv => drv.FindElements(By.Id("checkSupplies")));
            //   WebElement firstResult = new WebDriverWait(driver, Duration.ofSeconds(10));

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

        public static Func<IWebDriver, IWebElement> ElementIsClickable(By locator)
        {
            return driver =>
            {
                var element = driver.FindElement(locator);
                return (element != null && element.Displayed && element.Enabled) ? element : null;
            };
        }
    }
}