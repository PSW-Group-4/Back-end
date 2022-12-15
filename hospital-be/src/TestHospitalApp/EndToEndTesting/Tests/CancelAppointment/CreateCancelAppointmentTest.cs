using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.CancelAppointment;
using TestHospitalApp.EndToEndTesting.Pages.Consilium;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.CancelAppointment
{
    public class CreateCancelAppointmentTest
    {
        public IWebDriver Driver;
        public CancelAppointmentPage CancelAppointmentPage;
        private LoginPage loginPage;
        public int rowCount;

        public CreateCancelAppointmentTest() {

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications

            LoginPrivate(options);

            CancelAppointmentPage.Navigate();
        }

        private void LoginPrivate(ChromeOptions options)
        {
            Driver = new ChromeDriver(options);
            CancelAppointmentPage = new CancelAppointmentPage(Driver);
            loginPage = new LoginPage(Driver);
            CancelAppointmentPage.NavigateStart();
            loginPage.EnterUsernameAndPassword("manager1", "manager1");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/manager");
        }

        [Fact]
        public void Cancel_move_equipment_appointment()
        {
            CancelAppointmentPage.EnsurePageIsDisplayed();
            
            rowCount = CancelAppointmentPage.GetRowsCount();
            //CancelAppointmentPage.TrPressed();
            
            Assert.True(CancelAppointmentPage.TrPressed());
            //CancelAppointmentPage.NavigateRoom();
            //CancelAppointmentPage.DivSelected();
            //Assert.True(CancelAppointmentPage.DivSelected());
            CancelAppointmentPage.ShowRoomScheduleButtonPressed();
            //Assert.True(CancelAppointmentPage.ShowRoomScheduleButtonPressed());
            //CancelAppointmentPage.EnsureEndPageIsDisplayed();
            CancelAppointmentPage.EquipmentRelocationTabPressed();
            CancelAppointmentPage.EquipmentRelocationTablePressed();
            CancelAppointmentPage.CancelMoveEquipmentAppointmentButtonPressed();

            //
            //Assert.True(CancelAppointmentPage.CancelMoveEquipmentAppointmentButtonPressed());
            //Assert.True(CancelAppointmentPage.DivSelected());

            //Assert.Equal(rowCount, CancelAppointmentPage.GetRowsCount());
        }
    }
}
