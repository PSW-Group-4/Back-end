using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.MedicalAppointment
{
    public class MedicalAppointmentPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/doctor/appointments";
        public const string LoginURI = @"http://localhost:4200/login";
        private IWebElement Table => driver.FindElement(By.Id("medicalAppointmentTable"));
        private ReadOnlyCollection<IWebElement> Rows =>
            Table.FindElements(By.TagName("tr"));
        private IWebElement LastRowUpdateButton => driver.FindElement(By.XPath("//table[@id='medicalAppointmentTable']/tbody/tr[last()]/td[6]"));
        private IWebElement dateBox => driver.FindElement(By.Id("datePick"));
        private IWebElement terminBox => driver.FindElement(By.XPath("//mat-select[@id='terminPick']"));
        private IWebElement terminBoxOpt => driver.FindElement(By.XPath("//mat-option[@id='terminPickOption']"));
        private IWebElement editClick => driver.FindElement(By.Id("editClick"));
        private IWebElement finishClick => driver.FindElement(By.Id("finishBtn"));
        public MedicalAppointmentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool UpdateButtonPressed()
        {
            try
            {
                var button = LastRowUpdateButton.FindElement(By.Id("editButton"));
                button.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool ChooseDate(string date)
        {
            try
            {
                dateBox.SendKeys(Keys.Control + "a");
                dateBox.SendKeys(Keys.Delete);
                dateBox.SendKeys(date);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool ChooseTermin()
        {
            try
            {
                terminBox.Click();
                terminBoxOpt.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool FinishButtonPressed()
        {
            try
            {
                editClick.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }
        public bool EndButtonPressed()
        {
            try
            {
                finishClick.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public int GetRowsCount()
        {
            return Rows.Count;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return LastRowUpdateButton.Displayed;
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
                    return finishClick.Displayed;
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

        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);
    }
}
