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

        private IWebElement Table => driver.FindElement(By.XPath("/html/body/app-root/app-manager-root/app-maps-main-container/div/div[2]/div[2]/app-search/mat-card/mat-card-content/mat-tab-group/div/mat-tab-body[1]/div/table"));
        private ReadOnlyCollection<IWebElement> Rows =>
            Table.FindElements(By.TagName("tr"));
        private IWebElement divTest;
        private IWebElement tr => driver.FindElement(By.XPath("/html/body/app-root/app-manager-root/app-maps-main-container/div/div[2]/div[2]/app-search/mat-card/mat-card-content/mat-tab-group/div/mat-tab-body[1]/div/table/tbody/tr[1]/td[1]"));
        private IWebElement showRoomScheduleButton  ;
        private IWebElement cancelMoveEquipmentAppointmentButton => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-room-schedule/div/mat-tab-group/div/mat-tab-body[1]/div/table/tbody/tr[1]/td[3]/button"));

        private IWebElement tableMoveEquipmentAppointment => driver.FindElement(By.XPath("//*[@id=\"equipmentRelocationTable\"]"));
        private ReadOnlyCollection<IWebElement> RowsMoveEquipmentAppointment =>
            tableMoveEquipmentAppointment.FindElements(By.TagName("tr"));

        private IWebElement tableRenovationAppointment => driver.FindElement(By.XPath("//*[@id=\"equipmentRelocationTable\"]"));
        private ReadOnlyCollection<IWebElement> RowsRenovationAppointment =>
            tableRenovationAppointment.FindElements(By.TagName("tr"));
        public CancelAppointmentPage(IWebDriver driver)
        {
            this.driver = driver;
        }
  
        public bool ShowRoomScheduleButtonPressed() 
        {
            try
            {

                showRoomScheduleButton = driver.FindElement(By.XPath("//*[@id=\"divDialog\"]/div/div/mat-card/button[4]"));
                showRoomScheduleButton.Click();
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
        
        public int GetRowsCountForMoveEquipment() {
            return RowsMoveEquipmentAppointment.Count;
        }

        public int GetRowsCountForRenovation()
        {
            return RowsRenovationAppointment.Count;
        }
        

        public int GetRowsCount()
        {
            return Rows.Count;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count >0;
                }

                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void EnsureEndPageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            wait.Until(condition =>
            {
                try
                {
                    return cancelMoveEquipmentAppointmentButton.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public void RefreshPage() => driver.Navigate().Refresh();
        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);
        
    }
}
