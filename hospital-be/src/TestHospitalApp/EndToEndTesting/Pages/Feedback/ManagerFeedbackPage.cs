using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.Feedback
{
    public class ManagerFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:59198/manager/feedbacks";
        private IWebElement Table => driver.FindElement(By.Id("feedbacksTable"));
        private ReadOnlyCollection<IWebElement> FeedbacTableRows =>
            Table.FindElements(By.TagName("tr"));
        private IWebElement LastRowPatient => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[2]"));
        private IWebElement LastRowFeedbackText => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[3]"));
        private IWebElement LastRowDesiredVisibility => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[4]"));
        //vraca i dugmad
        private IWebElement LastRowCurrentVisibility => driver.FindElement(By.XPath("//table[@id='feedbacksTable']/tbody/tr[last()]/td[5]"));
        public string Title => driver.Title;
        
        
        private IWebElement FeedbackTable => driver.FindElement(By.Id("feedbacksTable"));
        private ReadOnlyCollection<IWebElement> FeedbackTableRows =>
            FeedbackTable.FindElements(By.TagName("tr"));
        

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(condition =>
            {
                try
                {
                    return LastRowPatient.Displayed;
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

        public void EnsureTableDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(condition =>
            {
                try
                {
                    return FeedbackTableRows.Count > 1;
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

        public bool PublishButtonDisplayed()
        {
            try
            {
                var button = LastRowCurrentVisibility.FindElement(By.Id("publishButton"));
            }
            catch(NoSuchElementException) 
            {
                return false;
            }
            return true;
        }

        public bool HideButtonDisplayed()
        {
            try
            {
                var button = LastRowCurrentVisibility.FindElement(By.Id("hideButton"));
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public int GetFeedbacksCount()
        {
            return FeedbacTableRows.Count;
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

        public void PublishFeedback(string feedbackText)
        {
            EnsureTableDisplayed();
            var feedbackRow = -1;
            for (int i = 1; i < FeedbacTableRows.Count; i++)
            {
                var td = FeedbacTableRows[i].FindElements(By.TagName("td"))[2];
                var text = td.Text;
                if (!text.Equals(feedbackText)) continue;
                feedbackRow = i;
                break;
            }
            if (feedbackRow == -1) return;

            var publishButton = FeedbackTableRows[feedbackRow].FindElement(By.Id("publishButton"));
            publishButton.Click();
        }
            
        public bool IsFeedbackPublished(string feedbackText)
        {
            EnsureTableDisplayed();
            Thread.Sleep(3000);
            var feedbackRow = -1;
            for (int i = 1; i < FeedbacTableRows.Count; i++)
            {
                var td = FeedbacTableRows[i].FindElements(By.TagName("td"))[2];
                var text = td.Text;
                if (!text.Equals(feedbackText)) continue;
                feedbackRow = i;
                break;
            }

            var visibilityElement = FeedbackTableRows[feedbackRow].FindElement(By.ClassName("currentVisibilityWidth"));
            var visibility = visibilityElement.Text.Split(" ")[0];
            return visibility.Equals("Published");
        }
    }
}
