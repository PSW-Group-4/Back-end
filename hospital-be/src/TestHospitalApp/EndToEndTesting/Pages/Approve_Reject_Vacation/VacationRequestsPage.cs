using HospitalLibrary.Vacations.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.Approve_Reject_Vacation
{
    public class VacationRequestsPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/manager/vacationRequests";
        public const string LoginURI = @"http://localhost:4200/login";

        public VacationRequestsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement approveVacationButton => driver.FindElement(By.Id("approveButton"));
        private IWebElement rejectVacationButton => driver.FindElement(By.Id("rejectButton"));

        private IWebElement submitCommentButton => driver.FindElement(By.Id("commentSubmitButton"));

        private IWebElement commentInput => driver.FindElement(By.Id("commentField"));

        public bool PressApproveButton()
        {
            try
            {
                approveVacationButton.Click();
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool PressRejectButton()
        {
            try
            {
                rejectVacationButton.Click();
                
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public bool PressSubmitButton()
        {
            try
            {
                submitCommentButton.Click();

            }
            catch (NoSuchElementException)
            {
                return false;
            }
            return true;
        }

        public void writeComment(String comment)
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            //myDynamicElement.Until(driver => CheckIfItExists("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/mat-form-field[2]/div/div[1]/div/input"));
            commentInput.Clear();
            commentInput.SendKeys(comment);
        }

        public String read()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/mat-form-field[2]/div/div[1]/div/input"));
            String s = commentInput.GetAttribute("value").ToString();
            return s;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);

        public bool CheckIfItExists(string ElementId)
        {
            try
            {
                driver.FindElement(By.XPath(ElementId));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

    }
}
