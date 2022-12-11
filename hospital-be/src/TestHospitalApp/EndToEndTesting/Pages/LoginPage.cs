using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/loginPage";

        private IWebElement UsernameInput => driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.Id("loginBtn"));

        public LoginPage(IWebDriver driver)
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

        public void Navigate() => driver.Navigate().GoToUrl(URI);
    }
}
