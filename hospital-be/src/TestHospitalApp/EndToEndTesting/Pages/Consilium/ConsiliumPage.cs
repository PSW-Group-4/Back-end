using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.Consilium
{
    public class ConsiliumPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/doctor/consiliums";
        public const string LoginURI = @"http://localhost:4200/login";
        private IWebElement Table => driver.FindElement(By.Id("consiliumTable"));
        private ReadOnlyCollection<IWebElement> Rows =>
            Table.FindElements(By.TagName("tr"));
        private IWebElement addConsiliumDialogButton => driver.FindElement(By.Id("addConsiliumButton"));
        private IWebElement reasonInput => driver.FindElement(By.Id("reason"));
        private IWebElement startDate => driver.FindElement(By.Id("start"));
        private IWebElement endDate => driver.FindElement(By.Id("end"));
        private IWebElement durationInput => driver.FindElement(By.Id("numberOfTermins"));
        //private IWebElement doctorRadio => driver.FindElement(By.Id("doctorRadio"));
        private IWebElement doctorRadio => driver.FindElement(By.XPath("//mat-radio-button[@id='doctorRadio']"));
        //private IWebElement doctorCombo => driver.FindElement(By.Id("doctorCombo"));
        private IWebElement doctorCombo => driver.FindElement(By.XPath("//mat-select[@id='doctorCombo']"));
        private IWebElement doctorOption => driver.FindElement(By.XPath("//mat-option[@id='doctorOption']"));
        private IWebElement createConsiliumButton => driver.FindElement(By.Id("createConsilium"));
        public ConsiliumPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool AddConsiliumButtonPressed()
        {
            try
            {
                //var button = LastRowUpdateButton.FindElement(By.Id("editButton"));
                var button = addConsiliumDialogButton;
                button.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool ChooseReason(string reason)
        {
            try
            {
                reasonInput.SendKeys(reason);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }


        public bool ChooseStartDate(string date)
        {
            try
            {
                startDate.SendKeys(Keys.Control + "a");
                startDate.SendKeys(Keys.Delete);
                startDate.SendKeys(date);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool ChooseEndDate(string date)
        {
            try
            {
                endDate.SendKeys(Keys.Control + "a");
                endDate.SendKeys(Keys.Delete);
                endDate.SendKeys(date);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool ChooseDuration(string duration)
        {
            try
            {
                durationInput.SendKeys(duration);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool DoctorRadionButtonPressed()
        {
            try
            {
                doctorRadio.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool ChooseDoctorCombo()
        {
            try
            {
                doctorCombo.Click();
                doctorOption.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool CreateConsiliumButtonPressed()
        {
            try
            {
                createConsiliumButton.Click();
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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return addConsiliumDialogButton.Displayed;
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
                    return createConsiliumButton.Displayed;
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
