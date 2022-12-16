using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIntegrationApp.E2E.Pages
{
   public class BloodRequestReviewPage
    {
        
        private readonly IWebDriver driver;
        public readonly string Url = "http://localhost:4200/manager/viewRequests;

        public BloodRequestReviewPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement NameInput => driver.FindElement(By.Name("name"));
        private IWebElement EmailInput => driver.FindElement(By.Name("email"));
        private IWebElement ServerAddressInput => driver.FindElement(By.Name("serverAddress"));
        private IWebElement SubmitButton => driver.FindElement(By.TagName("BUTTON"));

        public void EnterInformation(string name, string email, string serverAddress)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            ServerAddressInput.SendKeys(serverAddress);
        }

        public void PressSubmitButton()
        {
            SubmitButton.Click();
        }

        public void Navigate()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
