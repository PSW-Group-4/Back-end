using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.CancelAppointment
{
    public class CancelAppointmentPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/manager/maps";
        public const string LoginURI = @"http://localhost:4200/login";
        private IWebElement Table => driver.FindElement(By.Id("searchNameTable"));

        private ReadOnlyCollection<IWebElement> Rows =>
            Table.FindElements(By.TagName("tr"));
        private IWebElement divTest => driver.FindElement(By.Id("divDialog"));
        private IWebElement tr => driver.FindElement(By.XPath("/html/body/app-root/app-manager-root/app-maps-main-container/div/div[2]/div[2]/app-search/mat-card/mat-card-content/mat-tab-group/div/mat-tab-body[1]/div/table/tbody/tr[1]"));
        private IWebElement showRoomScheduleButton => divTest.FindElement(By.XPath("/html/body/app-root/app-manager-root/app-maps-main-container/div/div[2]/div[1]/app-rooms/div/div[3]/div/div/mat-card/button[4]"));

        private IWebElement equipmentRelocationTab => driver.FindElement(By.Id("EquipmentRelocation"));
        private IWebElement equipmentTable => driver.FindElement(By.Id("equipmentRelocationTable"));
        private IWebElement cancelMoveEquipmentAppointmentButton => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-room-schedule/div/mat-tab-group/div/mat-tab-body[1]/div/table/tbody/tr/td[3]/button"));

        public CancelAppointmentPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool ShowRoomScheduleButtonPressed() 
        {
            try
            {
                var button = showRoomScheduleButton;
                button.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public bool TrPressed()
        {
            try
            {
                var trr = tr;
                trr.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;

        }
        public bool DivSelected()
        {
            try
            {
                var trr = divTest;
                trr.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public bool CancelMoveEquipmentAppointmentButtonPressed()
        {
            try
            {
                var button = cancelMoveEquipmentAppointmentButton;
                button.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool EquipmentRelocationTabPressed()
        {
            try
            {
                var tab = equipmentRelocationTab;
                tab.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public bool EquipmentRelocationTablePressed()
        {
            try
            {
                var tab = equipmentTable;
                tab.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public void clickOutside()
        {
            Actions action = new Actions(driver);
            action.MoveByOffset(0, 0).Click().Build().Perform();
        }

        public int GetRowsCount()
        {
            return Rows.Count;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(condition =>
            {
                try
                {
                    return Table.Displayed;
                }
                
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void EnsureEndPageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(condition =>
            {
                try
                {
                    return equipmentRelocationTab.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);
        
    }
}
