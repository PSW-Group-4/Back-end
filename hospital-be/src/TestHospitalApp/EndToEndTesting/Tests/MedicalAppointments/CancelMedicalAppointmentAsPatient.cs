using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Feedback;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestHospitalApp.EndToEndTesting.Pages.MedicalAppointment;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.MedicalAppointments
{
    public class CancelMedicalAppointmentAsPatient : IDisposable
    {
        private IWebDriver driver;
        private ViewMedicalAppointmentsPatientPage appointmentPage;
        private LoginPage loginPage;
        private int appointmentsCount = 0;

        public CancelMedicalAppointmentAsPatient()
        {
            Login();

            appointmentPage = new ViewMedicalAppointmentsPatientPage(driver);
            appointmentPage.Navigate();
            appointmentPage.EnsurePageIsDisplayed();
            appointmentsCount = appointmentPage.GetAppointmentsCount();
            
            Assert.Equal(driver.Url, ViewMedicalAppointmentsPatientPage.URI);
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
            loginPage.NavigatePublic();
            loginPage.EnterUsernameAndPassword("gtorbeck1", "U0LHHu3X60");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.Url != loginPage.publicURI);
        }
        void IDisposable.Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Cancel_feature_appointment()
        {
            appointmentPage.CancelAppointment();
            appointmentPage.EnsureGetIsDone(appointmentsCount);
            appointmentPage.GetAppointmentsCount().ShouldBe(appointmentsCount-1);
        }

        [Fact]
        public void Cancel_less_then_24hours()
        {
            try
            {
                appointmentPage.CancelLastAppointment();
            }
            catch (UnhandledAlertException ex)
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                alertText.Contains("24").ShouldBe(true);
            }
        }      
    }
}
