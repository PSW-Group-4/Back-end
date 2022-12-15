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
        private IWebElement AddButton => driver.FindElement(By.Id("addAppointment"));
        private IWebElement Table => driver.FindElement(By.Id("medicalAppointmentTable"));
        private ReadOnlyCollection<IWebElement> Rows =>
            Table.FindElements(By.TagName("tr"));
        private IWebElement LastRowUpdateButton => driver.FindElement(By.XPath("//table[@id='medicalAppointmentTable']/tbody/tr[last()]/td[6]"));
        private IWebElement PatientBox => driver.FindElement(By.XPath("//mat-select[@id='patientChoose']"));
        private IWebElement PatientBoxOpt => driver.FindElement(By.XPath("//mat-option[@id='patientPickOption']"));
        private IWebElement DateBox => driver.FindElement(By.Id("datePick"));
        private IWebElement TerminBox => driver.FindElement(By.XPath("//mat-select[@id='terminPick']"));
        private IWebElement TerminBoxOpt => driver.FindElement(By.XPath("//mat-option[@id='terminPickOption']"));
        private IWebElement AddClick => driver.FindElement(By.Id("addClick"));
        private IWebElement EditClick => driver.FindElement(By.Id("editClick"));
        private IWebElement FinishAddClick => driver.FindElement(By.Id("finishAddBtn"));
        private IWebElement FinishClick => driver.FindElement(By.Id("finishBtn"));
        public MedicalAppointmentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool AddButtonPressed()
        {
            try
            {
                AddButton.Click();
            }
            catch(NoSuchElementException)
            {
                return false;
            }
            return true;
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

        public void EnsureAddPageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return AddButton.Displayed;
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

        public bool ChoosePatient()
        {
            try
            {
                WebDriverWait waitSelect = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(2));
                waitSelect.Until(e =>{ return IsElementHasTrueAriaDisabledAttribute(e, PatientBox); });
                PatientBox.Click();
                WebDriverWait waitOption = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
                waitOption.Until(e => e.FindElement(By.Id("patientPickOption"))).Click();
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
                DateBox.Clear();
                DateBox.SendKeys(Keys.Control + "a");
                DateBox.SendKeys(date);
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
                WebDriverWait waitSelect = new WebDriverWait(driver, timeout: TimeSpan.FromSeconds(2));
                waitSelect.Until(e => { return IsElementHasTrueAriaDisabledAttribute(e, TerminBox); });
                TerminBox.Click();
                int attempts = 0;
                while (attempts < 2)
                {
                    try
                    {
                        driver.FindElement(By.XPath("//mat-option[@id='terminPickOption']")).Click();
                        break;
                    }
                    catch (StaleElementReferenceException e) {}
                    attempts++;
                }
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool CreateButtonPressed()
        {
            try
            {
                AddClick.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool FinishAddButtonPressed()
        {
            try
            {
                FinishAddClick.Click();
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
                EditClick.Click();
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
                FinishClick.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public int GetRowsCount()
        {
            return driver.FindElement(By.Id("medicalAppointmentTable")).FindElements(By.TagName("tr")).Count;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
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

        public void EnsureAddEndPageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return FinishAddClick.Displayed;
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

        public void EnsureAddEndPageIsNotDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return driver.FindElements(By.Id("finishAddBtn")).Count == 0;
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
                    return FinishClick.Displayed;
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

        public IWebElement IsElementHasTrueAriaDisabledAttribute(IWebDriver webdriver, IWebElement element)
        {
            if (element.GetAttribute("aria-disabled").Equals("false"))
            {
                return element;
            }

            return null;
        }

        public void RefreshPage() => driver.Navigate().Refresh();
        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);
    }
}
