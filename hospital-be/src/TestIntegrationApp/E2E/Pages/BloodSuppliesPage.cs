using OpenQA.Selenium;
using System.Collections.Generic;

namespace TestIntegrationApp.E2E.Pages
{
    public class BloodSuppliesPage
    {
        private readonly IWebDriver driver;
        public readonly string Url = "http://localhost:4200/manager/bloodBanks";

        public BloodSuppliesPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IList<IWebElement> OpenDialogButtons => driver.FindElements(By.Id("checkSupplies"));
        private IWebElement OpenDialogButton => OpenDialogButtons[0];
        private IWebElement BloodTypeInput => driver.FindElement(By.Id("bloodType"));
        private IWebElement QuantityInput => driver.FindElement(By.Id("quantity"));
        private IWebElement SubmitButton => driver.FindElement(By.Id("submit"));

        public void EnterInformation(string bloodType, string quantity)
        {
            QuantityInput.SendKeys(quantity);
            BloodTypeInput.SendKeys(bloodType);
        }

        public void PressOpenDialogButton()
        {
            OpenDialogButton.Click();
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