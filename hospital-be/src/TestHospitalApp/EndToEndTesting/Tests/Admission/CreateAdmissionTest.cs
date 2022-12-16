using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Admission;
using TestHospitalApp.EndToEndTesting.Pages.Feedback;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestHospitalApp.EndToEndTesting.Pages.MedicalAppointment;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Admission
{
    public class CreateAdmissionTest : IDisposable
    {
        public IWebDriver Driver;
        public CreateAdmissionPage CreateAdmissionPage;
        private LoginPage loginPage;
        public int rowCount;

        public CreateAdmissionTest()
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

            CreateAdmissionPage.Navigate();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private void LoginPrivate(ChromeOptions options)
        {
            Driver = new ChromeDriver(options);
            CreateAdmissionPage = new CreateAdmissionPage(Driver);
            loginPage = new LoginPage(Driver);
            CreateAdmissionPage.NavigateStart();
            loginPage.EnterUsernameAndPassword("doktor", "doktor");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/doctor");
        }

        [Fact]
        public void Create_new_admission()
        {
           
            rowCount = CreateAdmissionPage.GetRowsCount();
            CreateAdmissionPage.AddButtonPressed();
            CreateAdmissionPage.EnsureEndPageIsDisplayed();
            //CreateAdmissionPage.PatientBoxClick();            
            //CreateAdmissionPage.EnsurePatientOptionDisplayed();
            CreateAdmissionPage.ChoosePatient();            
            CreateAdmissionPage.ChooseRoom();
            CreateAdmissionPage.EnterReason("Glavobolja");
            CreateAdmissionPage.ConfirmButtonPressed();
            CreateAdmissionPage.Navigate();
            CreateAdmissionPage.RefreshPage();
            
            //CreateAdmissionPage.EnsureAddEndPageIsNotDisplayed();
            CreateAdmissionPage.EnsureTableIsUpdated(rowCount);

            Assert.Equal(rowCount + 1, CreateAdmissionPage.GetRowsCount());
        }
    }
}
