using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestHospitalApp.EndToEndTesting.Pages.MedicalAppointment;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.MedicalAppointments
{
    public class CreateAppointmentTest : IDisposable
    {
        public IWebDriver Driver;
        public MedicalAppointmentPage MedicalAppointmentPage;
        private LoginPage loginPage;
        public int rowCount;

        public CreateAppointmentTest()
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

            MedicalAppointmentPage.Navigate();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private void LoginPrivate(ChromeOptions options)
        {
            Driver = new ChromeDriver(options);
            MedicalAppointmentPage = new MedicalAppointmentPage(Driver);
            loginPage = new LoginPage(Driver);
            MedicalAppointmentPage.NavigateStart();
            loginPage.EnterUsernameAndPassword("doktor", "doktor");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/doctor");
        }

        [Fact]
        public void Create_new_appointment()
        {
            rowCount = MedicalAppointmentPage.GetRowsCount();
            MedicalAppointmentPage.AddButtonPressed();
            MedicalAppointmentPage.EnsureAddPageIsDisplayed();
            MedicalAppointmentPage.ChoosePatient();
            MedicalAppointmentPage.ChooseDate("12-15-2022");
            MedicalAppointmentPage.ChooseTermin();
            MedicalAppointmentPage.CreateButtonPressed();
            MedicalAppointmentPage.EnsureAddEndPageIsDisplayed();
            MedicalAppointmentPage.FinishAddButtonPressed();
            MedicalAppointmentPage.EnsureAddEndPageIsNotDisplayed();
            MedicalAppointmentPage.RefreshPage();
            MedicalAppointmentPage.EnsurePageIsDisplayed();
            MedicalAppointmentPage.EnsureTableIsUpdated(rowCount);

            Assert.Equal(rowCount + 1, MedicalAppointmentPage.GetRowsCount());
        }
    }
}
