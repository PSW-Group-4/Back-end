using OpenQA.Selenium;

namespace TestIntegrationApp.E2E.Pages
{
    public class BankRegistrationPage
    {
        private readonly IWebDriver driver;
        public readonly string Url = "http://localhost:4200/manager/bloodBanks/add";

        public BankRegistrationPage(IWebDriver driver)
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