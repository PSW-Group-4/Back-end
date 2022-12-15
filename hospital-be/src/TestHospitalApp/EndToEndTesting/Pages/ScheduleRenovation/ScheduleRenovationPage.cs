using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace TestHospitalApp.EndToEndTesting.Pages.ScheduleRenovation
{
    public class ScheduleRenovationPage
    {
        
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/manager/room-renovation";
        public const string LoginURI = @"http://localhost:4200/login";
        
        public ScheduleRenovationPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void MatSelectInput(String id, String value) {
            driver.FindElement(By.Id(id)).Click();
            driver.FindElement(By.Id(value)).Click();
        }

        public void ClickButton(String id) {
            driver.FindElement(By.Id(id)).Click();
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);
    }
}