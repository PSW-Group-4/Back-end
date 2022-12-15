using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Feedback;
using TestHospitalApp.EndToEndTesting.Pages.Maps;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.UpdateMapItem
{
    public class UpdateBuildingTest
    {

        public IWebDriver Driver;
        public BuildingMapPage mapPage;
        private LoginPageManager loginPage;
        public int rowCount;

        public UpdateBuildingTest()
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

            MapNavigate(options);
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private void LoginPrivate(ChromeOptions options)
        {
            Driver = new ChromeDriver(options);
            mapPage = new BuildingMapPage(Driver);
            loginPage = new LoginPageManager(Driver);
            mapPage.NavigateStart();
            loginPage.EnterUsernameAndPassword("manager1", "manager1");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/manager");
        }

        private void MapNavigate(ChromeOptions options)
        {
            mapPage.Navigate();
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/manager/maps");
        }

        [Fact]
        public void UpdateBuilding()
        {
            String newName = "Zgrada BB";
            mapPage.press();
            mapPage.press3();
            mapPage.write(newName);
            mapPage.press2();
            mapPage.press3();
            Assert.Equal(newName, mapPage.read());
        }
    }
}
