using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestHospitalApp.EndToEndTesting.Pages.Consilium;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Consilium
{
    public class CreateConsiliumTest
    {
        public IWebDriver Driver;
        public ConsiliumPage ConsiliumPage;
        private LoginPage loginPage;
        public int rowCount;

        public CreateConsiliumTest()
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

            ConsiliumPage.Navigate();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private void LoginPrivate(ChromeOptions options)
        {
            Driver = new ChromeDriver(options);
            ConsiliumPage = new ConsiliumPage(Driver);
            loginPage = new LoginPage(Driver);
            ConsiliumPage.NavigateStart();
            loginPage.EnterUsernameAndPassword("doktor", "doktor");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/doctor");
        }

        [Fact]
        public void Create_consilium_with_doctors()
        {
            ConsiliumPage.EnsurePageIsDisplayed();
            rowCount = ConsiliumPage.GetRowsCount();
            ConsiliumPage.AddConsiliumButtonPressed();
            ConsiliumPage.EnsureEndPageIsDisplayed();
            ConsiliumPage.ChooseReason("Treba mi pomoch");
            ConsiliumPage.ChooseStartDate("12.19.2022.");
            ConsiliumPage.ChooseEndDate("12.21.2022.");
            ConsiliumPage.ChooseDuration("1");
            ConsiliumPage.DoctorRadionButtonPressed();
            ConsiliumPage.ChooseDoctorCombo();
            ConsiliumPage.clickOutside();
            ConsiliumPage.CreateConsiliumButtonPressed();

            Assert.Equal(rowCount, ConsiliumPage.GetRowsCount());
        }
    }
}
