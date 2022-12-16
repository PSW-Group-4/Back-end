using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIntegrationApp.E2E.Pages
{
    public class ReportConfigurationPage
    {
        private readonly IWebDriver driver;
        public readonly string Url = "http://localhost:4200/manager/report-configs";

        private IWebElement LastEntry => driver.FindElements(By.ClassName("item-wrapper")).Last();

        public ReportConfigurationPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        public bool NewButtonClick()
        {
            try
            {
                IWebElement button = driver.FindElement(By.Id("newButton"));
                button.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public bool SaveButtonClick()
        {
            try
            {
                IWebElement button = driver.FindElement(By.Id("saveButton"));
                button.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public void SelectInformation(string bankid, string activeStatus, string frequency)
        {
            IWebElement bank = driver.FindElement(By.Id("bankSelect"));
            var selectBank = new SelectElement(bank);
            selectBank.SelectByValue(bankid);

            IWebElement status = driver.FindElement(By.Id("activeSelect"));
            var selectStatus = new SelectElement(status);
            selectStatus.SelectByValue(activeStatus);

            IWebElement activeFrequency = driver.FindElement(By.Id("frequencySelect"));
            var selectFrequency = new SelectElement(activeFrequency);
            selectFrequency.SelectByValue(frequency);
        }
        public void Navigate()
        {
            driver.Navigate().GoToUrl(Url);
        }
        public bool ValidateNewEntry(string bank,string status, string frequency)
        {
            if (ValidateBankName(bank) && ValidateStatus(status) && ValidateFrequency(frequency)) return true;
            return false;
        }

        private bool ValidateBankName(string bank)
        {
            string bankTitleString = LastEntry.FindElement(By.TagName("p")).Text;
            if (bankTitleString != null) if (bankTitleString.Equals("Bloodbank name: " + bank)) return true;
            return false;
        }
        private bool ValidateStatus(string status)
        {
            string activeStatus = LastEntry.FindElements(By.TagName("select")).First().Selected.ToString();
            if (activeStatus != null) if (activeStatus.Equals(status)) return true;
            return false;
        }
        private bool ValidateFrequency(string frequency)
        {
            string frequencyString = LastEntry.FindElements(By.TagName("select")).Last().Selected.ToString();
            if (frequencyString != null) if (frequencyString.Equals(frequency)) return true;
            return false;
        }
    }
}
