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

        private IWebElement rejectVacationButton => driver.FindElement(By.XPath("/html/body/app-root/app-manager-root/app-manager-vacations/table/tbody/tr[1]/td[7]/button/span[1]/mat-icon"));

        private IWebElement submitCommentButton => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-comment/div/button"));

        private IWebElement commentInput => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-comment/div/mat-form-field[2]/div/div[1]/div/textarea"));

        public void PressRejectButton()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/app-root/app-manager-root/app-manager-vacations/table/tbody/tr[1]/td[7]/button/span[1]/mat-icon"));
            rejectVacationButton.Click();
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
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/div[2]/div[2]/div/mat-dialog-container/app-comment/div/mat-form-field[2]/div/div[1]/div"));
            commentInput.Clear();
            commentInput.SendKeys(comment);
        }

        public String read()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/div[2]/div[2]/div/mat-dialog-container/app-comment/div/mat-form-field[2]/div/div[1]/div"));
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
