using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Approve_Reject_Vacation;
using TestHospitalApp.EndToEndTesting.Pages.Maps;
using TestHospitalApp.EndToEndTesting.Tests.UpdateMapItem;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Approve_Reject_Vacation
{
    public class ApproveRejectTest
    {
        public IWebDriver Driver;
        private LoginPageManager loginPage;
        public VacationRequestsPage vacationPage;
        public int rowCount;

        public ApproveRejectTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            LoginPrivate(options);

            VacationNavigate(options);
        }


        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private void LoginPrivate(ChromeOptions options)
        {
            Driver = new ChromeDriver(options);
            vacationPage = new VacationRequestsPage(Driver);
            loginPage = new LoginPageManager(Driver);
            vacationPage.NavigateStart();
            loginPage.EnterUsernameAndPassword("manager1", "manager1");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/manager");
        }

        private void VacationNavigate(ChromeOptions options)
        {
            vacationPage.Navigate();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/manager/vacationRequests");
        }

        [Fact]
        public void RejectVacation()
        {
            vacationPage.PressRejectButton();
            string komentar = "Testiramo da li radi komentar";
            vacationPage.writeComment(komentar);

            vacationPage.PressSubmitButton();

            vacationPage.Navigate();
            
            vacationPage.PressRejectButton();

            Assert.Equal(komentar, vacationPage.read());
        }
    }
}
