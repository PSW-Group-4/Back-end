using HospitalLibrary.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.MedicalAppointment
{
    public class ViewMedicalAppointmentsPatientPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/patient/view-appointments";
        private IWebElement Table => driver.FindElement(By.Id("appointment-table"));
        private ReadOnlyCollection<IWebElement> Rows =>
            Table.FindElements(By.TagName("tr"));

        private IWebElement CancelBtn;

        public ViewMedicalAppointmentsPatientPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 1;
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

        public void EnsureGetIsDone(int oldCount)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count != oldCount;
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

        public void CancelAppointment()
        {
            EnsurePageIsDisplayed();
            this.CancelBtn = driver.FindElement(By.Id("cacnelBtn"));
            CancelBtn.Click();
        }

        public void CancelLastAppointment()
        {
            EnsurePageIsDisplayed();
            this.CancelBtn = driver.FindElements(By.Id("cacnelBtn"))[2];
            CancelBtn.Click();
        }

        public int GetAppointmentsCount()
        {
            return Rows.Count;
        }
    }
}
