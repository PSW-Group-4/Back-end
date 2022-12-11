using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.Feedback
{
    public class CreateFeedbackPage
    {
        private readonly IWebDriver driver;
        public const string URI = "http://localhost:4200/patient/createFeedback";
        private IWebElement TextElement => driver.FindElement(By.Id("feedbackText"));
        private IWebElement AnonymousCheckboxElement => driver.FindElement(By.Id("anonymous"));
        private IWebElement PublicCheckboxElement => driver.FindElement(By.Id("public"));
        private IWebElement SendButtonElement => driver.FindElement(By.Id("sendFeedback"));

        public const string InvalidTextMessage = "Please enter the feedback text!";

        public CreateFeedbackPage(IWebDriver driver) 
        {
            this.driver = driver;
        }

        public bool TextElementDisplayed()
        {
            return TextElement.Displayed;
        }

        public bool AnonymousCheckboxElementDisplayed()
        {
            return AnonymousCheckboxElement.Displayed;
        }

        public bool PublicCheckboxElementDisplayed()
        {
            return PublicCheckboxElement.Displayed;
        }

        public bool SendButtonElementDisplayed()
        {
            return SendButtonElement.Displayed;
        }

        public void InsertText(string text) 
        {
            TextElement.SendKeys(text);
        }

        public void ClickAnonymous()
        {
            AnonymousCheckboxElement.Click();
        }

        public void ClickPublic()
        {
            PublicCheckboxElement.Click();
        }

        public void SendFeedback()
        {
            SendButtonElement.Click();
        }

        public void WaitForErrorMessage()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            wait.Until(driver => driver.FindElement(By.Id("errorMessage")).Displayed);
        }

        public string GetErrorMessage()
        {
            return driver.FindElement(By.Id("errorMessage")).Text;
        }

        public void WaitForSendFeedback()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(driver => driver.Url != URI);
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);

        internal void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
            wait.Until(condition =>
            {
                try
                {
                    return TextElement.Text.Equals("");
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
    }
}
