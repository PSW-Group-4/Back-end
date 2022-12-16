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
        public readonly string Url = "http://localhost:4200/manager/viewRequests";


        public BloodRequestReviewPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement RejectButton => driver.FindElement(By.Name("reject"));
        private IWebElement AcceptButton => driver.FindElement(By.Name("accept"));
        private IWebElement RejectionCommentInput => driver.FindElement(By.Name("rejectionComment"));
        private IWebElement SubmitButton => driver.FindElement(By.Name("submit"));

        public void EnterInformation(string rejectionComment)
        {
            RejectionCommentInput.SendKeys(rejectionComment);
     
        }
        public void PressAcceptButton() {
            AcceptButton.Click();
        }
        public void PressRejectButton() {
            RejectButton.Click();
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
