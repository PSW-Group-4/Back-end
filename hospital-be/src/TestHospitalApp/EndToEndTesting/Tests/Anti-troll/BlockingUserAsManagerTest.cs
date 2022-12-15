using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using TestHospitalApp.EndToEndTesting.Pages.CancelAppointment;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestHospitalApp.EndToEndTesting.Pages.MedicalAppointment;
using TestHospitalApp.EndToEndTesting.Pages.UserBlocking;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Anti_troll
{
    public class BlockingUserAsManagerTest
    {
        private IWebDriver driver;
   
        private LoginPage loginPage;
        private UserBlockingPage userBlockingPage;


        public BlockingUserAsManagerTest()
        {
            Login();
            userBlockingPage = new UserBlockingPage(driver);
            userBlockingPage.Navigate();
            userBlockingPage.EnsurePageIsDisplayed();

            Assert.Equal(driver.Url, UserBlockingPage.URI);
        }
        private ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            return options;
        }

        private void Login()
        {
            driver = new ChromeDriver(GetOptions());
            loginPage = new LoginPage(driver);
            loginPage.NavigatePrivate();
            loginPage.EnterUsernameAndPassword("manager1", "manager1");
            loginPage.PressLoginButton();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(driver => driver.Url != loginPage.privateURI);
        }


        [Fact]
        public void BlockingUser()
        {
            userBlockingPage.BlockUser("blockHim");
            userBlockingPage.Wait();
            var isBlocked = userBlockingPage.IsUserBlocked("blockHim");
            isBlocked.ShouldBe(true);
        }

        [Fact]
        public void UnblockingUser()
        {
            userBlockingPage.unblockUser("unblockHim");
            userBlockingPage.Wait();
            var isBlocked = userBlockingPage.IsUserBlocked("unblockHim");
            isBlocked.ShouldBe(false);
        }

    }
}
