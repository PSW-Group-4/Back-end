using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Feedback;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Feedback
{
    public class CreateFeedbackTest : IDisposable
    {
        private IWebDriver driver;
        private ManagerFeedbackPage feedbackPage;
        private CreateFeedbackPage createFeedbackPage;
        private LoginPage loginPage;
        private int feedbacksCount = 0;

        public CreateFeedbackTest()
        {
            LoginPrivate();
            feedbackPage = new ManagerFeedbackPage(driver);

            feedbackPage.Navigate();
            feedbackPage.EnsurePageIsDisplayed();
            feedbacksCount = feedbackPage.GetFeedbacksCount();

            Dispose();

            LoginPublic();

            createFeedbackPage = new CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();

            Assert.Equal(driver.Url, CreateFeedbackPage.URI);
            Assert.True(createFeedbackPage.TextElementDisplayed());
            Assert.True(createFeedbackPage.AnonymousCheckboxElementDisplayed());
            Assert.True(createFeedbackPage.PublicCheckboxElementDisplayed());
            Assert.True(createFeedbackPage.SendButtonElementDisplayed());
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

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        private void LoginPrivate() 
        { 
            driver = new ChromeDriver(GetOptions());

            loginPage = new LoginPage(driver);
            loginPage.NavigatePrivate();
            loginPage.EnterUsernameAndPassword("manager1", "manager1");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.Url != loginPage.privateURI);
        }

        private void LoginPublic() 
        {
            driver = new ChromeDriver(GetOptions());

            loginPage = new LoginPage(driver);
            loginPage.NavigatePublic();
            loginPage.EnterUsernameAndPassword("salamahd", "salama9000");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(driver => driver.Url != loginPage.publicURI);
        }

        [Fact]
        public void Test_Invalid_Text()
        {
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForErrorMessage();

            Assert.Equal("Please enter the feedback text!", createFeedbackPage.GetErrorMessage());
            Assert.Equal(driver.Url, CreateFeedbackPage.URI);
        }

        [Fact]
        public void TestSuccessfulSend_No_Anon_No_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            Dispose();

            LoginPrivate();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);

            newFeedbacksPage.Navigate();
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.GetFeedbacksCount());
            Assert.Equal("Stefan Apostolovic", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Private", newFeedbacksPage.GetLastRowDesiredVisibility());
            Assert.Equal("Hidden", newFeedbacksPage.GetLastRowCurrentVisibility().Split(" ")[0]);
            Assert.False(newFeedbacksPage.PublishButtonDisplayed());
            Assert.False(newFeedbacksPage.HideButtonDisplayed());
        }

        [Fact]
        public void TestSuccessfulSend_No_Anon_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.ClickPublic();
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            Dispose();

            LoginPrivate();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);

            newFeedbacksPage.Navigate();
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.GetFeedbacksCount());
            Assert.Equal("Stefan Apostolovic", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Public", newFeedbacksPage.GetLastRowDesiredVisibility());
            Assert.Equal("Pending", newFeedbacksPage.GetLastRowCurrentVisibility().Split(" ")[0]);
            Assert.True(newFeedbacksPage.PublishButtonDisplayed());
            Assert.True(newFeedbacksPage.HideButtonDisplayed());
        }

        [Fact]
        public void TestSuccessfulSend_Anon_No_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.ClickAnonymous();
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            Dispose();

            LoginPrivate();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);

            newFeedbacksPage.Navigate();
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.GetFeedbacksCount());
            Assert.Equal("Anonymous", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Private", newFeedbacksPage.GetLastRowDesiredVisibility());
            Assert.Equal("Hidden", newFeedbacksPage.GetLastRowCurrentVisibility().Split(" ")[0]);
            Assert.False(newFeedbacksPage.PublishButtonDisplayed());
            Assert.False(newFeedbacksPage.HideButtonDisplayed());
        }

        [Fact]
        public void TestSuccessfulSend_Anon_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.ClickPublic();
            createFeedbackPage.ClickAnonymous();
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            Dispose();

            LoginPrivate();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);

            newFeedbacksPage.Navigate();
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.GetFeedbacksCount());
            Assert.Equal("Anonymous", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Public", newFeedbacksPage.GetLastRowDesiredVisibility());
            Assert.Equal("Pending", newFeedbacksPage.GetLastRowCurrentVisibility().Split(" ")[0]);
            Assert.True(newFeedbacksPage.PublishButtonDisplayed());
            Assert.True(newFeedbacksPage.HideButtonDisplayed());
        }
    }
}
