using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.Admission
{
    public class CreateAdmissionPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/doctor/admissionView";
        public const string LoginURI = @"http://localhost:4200/login";

        private IWebElement CreateAdmissionButton => driver.FindElement(By.Id("NewAdmission"));

        private IWebElement Table => driver.FindElement(By.Id("admissionTable"));
        private IWebElement PatientBox => driver.FindElement(By.XPath("//mat-select[@id='selectPatient']"));
        private IWebElement PatientBoxOpt => driver.FindElement(By.XPath("//mat-option[@id='optionPatient']"));
        private IWebElement RoomBox => driver.FindElement(By.XPath("//mat-select[@id='selectRoom']"));
        private IWebElement RoomBoxOpt => driver.FindElement(By.XPath("//mat-option[@id='optionRoom']"));
        private IWebElement Reason => driver.FindElement(By.Id("reason"));
        private IWebElement ConfirmButton => driver.FindElement(By.Id("confirm"));
        public CreateAdmissionPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool AddButtonPressed()
        {
            try
            {
                CreateAdmissionButton.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public bool ConfirmButtonPressed()
        {
            try
            {
                ConfirmButton.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool PatientBoxClick()
        {
            try
            {
                PatientBox.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool ChoosePatient()
        {
            try
            {
                WebDriverWait waitSelect = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(2));
                waitSelect.Until(e => { return IsElementHasTrueAriaDisabledAttribute(e, PatientBox); });          
                PatientBox.Click();
                WebDriverWait waitOption = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                waitOption.Until(e => e.FindElement(By.Id("optionPatient"))).Click();
                
                
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public IWebElement IsElementHasTrueAriaDisabledAttribute(IWebDriver webdriver, IWebElement element)
        {
            if (element.GetAttribute("aria-disabled").Equals("false"))
            {
                return element;
            }

            return null;
        }
        public bool ChooseRoom()
        {
            try
            {
                WebDriverWait waitSelect = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(10));
                waitSelect.Until(e => { return IsElementHasTrueAriaDisabledAttribute(e, RoomBox); });
                RoomBox.Click();
                WebDriverWait waitOption = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                waitOption.Until(e => e.FindElement(By.Id("optionRoom"))).Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public void EnsureAddEndPageIsNotDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return driver.FindElements(By.Id("NewAdmission")).Count == 0;
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

        public void EnsurePatientOptionDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(condition =>
            {
                try
                {
                    return driver.FindElements(By.Id("optionPatient")).Count != 0;
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return ConfirmButton.Displayed;
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

        public void EnsureTableIsUpdated(int rowCount)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return GetRowsCount() > rowCount;
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

        public void EnterReason(string reason)
        {
            Reason.SendKeys(reason);
            
        }

        public void MatSelectInput(String id, String value)
        {
            driver.FindElement(By.Id(id)).Click();
            driver.FindElement(By.Id(value)).Click();
        }

        public void ClickButton(String id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public int GetRowsCount()
        {
            return driver.FindElement(By.Id("admissionTable")).FindElements(By.TagName("tr")).Count;
        }
        public void RefreshPage() => driver.Navigate().Refresh();
        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);

    }
}
