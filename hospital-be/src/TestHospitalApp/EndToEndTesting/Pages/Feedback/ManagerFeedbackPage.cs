using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.Feedback
{
    public class ManagerFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:59714/manager/feedbacks.html";
        private IWebElement Table => driver.FindElement(By.Id("feedbacksTable"));
        private ReadOnlyCollection<IWebElement> Rows =>
            driver.FindElements(By.XPath("//table[@id='feedbacksTable']/tbody/tr\""));
        private IWebElement LastRowPatient => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[1]"));
        private IWebElement LastRowFeedbackText => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowDesiredVisibility => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[3]"));
        //vraca i dugme
        private IWebElement LastRowCurrentVisibility => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[4]"));
        public string Title => driver.Title;

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 0;
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

        public ManagerFeedbackPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int FeedbacksCount()
        {
            return Rows.Count;
        }

        public string GetLastRowPatient()
        {
            return LastRowPatient.Text;
        }

        public string GetLastRowFeedbackText()
        {
            return LastRowFeedbackText.Text;
        }

        public string GetLastRowDesiredVisibility()
        {
            return LastRowDesiredVisibility.Text;
        }

        public string GetLastRowCurrentVisibility()
        {
            return LastRowCurrentVisibility.Text;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
