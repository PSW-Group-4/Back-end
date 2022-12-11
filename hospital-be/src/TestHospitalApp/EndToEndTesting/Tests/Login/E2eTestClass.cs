using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Login
{
    public class E2eTestClass : IDisposable
    {
        public IWebDriver Driver;
        public LoginPage LoginPage;

        public E2eTestClass()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            Driver = new ChromeDriver(options);


            LoginPage = new LoginPage(Driver);      // create ProductsPage
            LoginPage.NavigatePrivate();
        }
        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        [Fact]
        public void Login_with_valids_username_and_password()
        {
            LoginPage.EnterUsernameAndPassword("gtorbeck1", "U0LHHu3X60");
            LoginPage.PressLoginButton();

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(drv => drv.FindElement(By.ClassName("grid")));

            Assert.Equal(@"http://localhost:4200/patient/info", Driver.Url);
        }
    }
}
