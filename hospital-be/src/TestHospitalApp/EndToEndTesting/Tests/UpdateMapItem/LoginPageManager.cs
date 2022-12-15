using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Tests.UpdateMapItem
{
    public class LoginPageManager
    {
        private readonly IWebDriver driver;
        public readonly string privateURI = @"http://localhost:4200/";
        public readonly string publicURI = @"http://localhost:4200/loginPage";

        private IWebElement UsernameInput => driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("loginBtn"));

        public LoginPageManager(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnterUsernameAndPassword(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
        }

        public void PressLoginButton()
        {
            LoginButton.Click();
        }

        public void NavigatePrivate() => driver.Navigate().GoToUrl(privateURI);
        public void NavigatePublic() => driver.Navigate().GoToUrl(publicURI);
    }
}
