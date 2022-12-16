using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Shouldly;
using TestHospitalApp.EndToEndTesting.Pages.Feedback;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Feedback
{
    public class PublishFeedbackTest : IDisposable
    {
        
        private IWebDriver _driver;
        private ManagerFeedbackPage _managerFeedbackPage;
        private LoginPage _loginPage;
        
        public PublishFeedbackTest()
        {
            LoginPrivate();
            _managerFeedbackPage = new ManagerFeedbackPage(_driver);

            _managerFeedbackPage.Navigate();
            _managerFeedbackPage.EnsurePageIsDisplayed();

            // Dispose();
        }
                
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

                
        private ChromeOptions GetOptions()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("disable-infobars");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-dev-shm-usage");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-notifications");

            return options;
        }

                
        private void LoginPrivate() 
        { 
            _driver = new ChromeDriver(GetOptions());

            _loginPage = new LoginPage(_driver);
            _loginPage.NavigatePrivate();
            _loginPage.EnterUsernameAndPassword("manager1", "manager1");
            _loginPage.PressLoginButton();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.Url != _loginPage.privateURI);
        }

        [Fact]
        public void Feedback_published()
        {
            _managerFeedbackPage.PublishFeedback("Selenium publish feedback test");
            var isPublished = _managerFeedbackPage.IsFeedbackPublished("Selenium publish feedback test");
            isPublished.ShouldBe(true);
        }

    }
}