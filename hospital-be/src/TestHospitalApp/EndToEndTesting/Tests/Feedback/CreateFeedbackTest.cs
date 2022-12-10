using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHospitalApp.EndToEndTesting.Pages.Feedback;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.Feedback
{
    public class CreateFeedbackTest : IDisposable
    {
        private readonly IWebDriver driver;
        private CreateFeedbackPage createFeedbackPage;
        private int feedbacksCount = 0;

        public CreateFeedbackTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            
            options.AddArguments("disable-infobars");           
            options.AddArguments("--disable-extensions");       
            options.AddArguments("--disable-gpu");             
            options.AddArguments("--disable-dev-shm-usage"); 
            options.AddArguments("--no-sandbox");            
            options.AddArguments("--disable-notifications");

            driver = new ChromeDriver(options);

            createFeedbackPage = new CreateFeedbackPage(driver);
            createFeedbackPage.Navigate();
            //mozda treba nisam siguran
            //createFeedbackPage.EnsurePageIsDisplayed();
            var test = driver.Url;
            Assert.Equal(driver.Url, CreateFeedbackPage.URI);
            Assert.True(createFeedbackPage.TextElementDisplayed());
            Assert.True(createFeedbackPage.AnonymousCheckboxElementDisplayed());
            Assert.True(createFeedbackPage.PublicCheckboxElementDisplayed());
            Assert.True(createFeedbackPage.SendButtonElementDisplayed());
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Fact]
        public void Test_Invalid_Text()
        {
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForErrorMessage();
            //Dodao
            Assert.Equal("Please enter the feedback text!", createFeedbackPage.GetErrorMessage());
            Assert.Equal(driver.Url, CreateFeedbackPage.URI);
        }

        [Fact]
        public void TestSuccessfulSend_No_Anon_No_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.FeedbacksCount());
            Assert.Equal("Anonymous", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Private", newFeedbacksPage.GetLastRowDesiredVisibility());
            //Promeni
            Assert.Equal("Hidden", newFeedbacksPage.GetLastRowCurrentVisibility());
        }

        [Fact]
        public void TestSuccessfulSend_No_Anon_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.ClickPublic();
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.FeedbacksCount());
            Assert.Equal("Anonymous", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Public", newFeedbacksPage.GetLastRowDesiredVisibility());
            //Promeni
            Assert.Equal("Pending", newFeedbacksPage.GetLastRowCurrentVisibility());
        }

        [Fact]
        public void TestSuccessfulSend_Anon_No_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.ClickAnonymous();
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.FeedbacksCount());
            //Promeni za ime
            Assert.Equal("Stefan Apostolovic", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Private", newFeedbacksPage.GetLastRowDesiredVisibility());
            //Promeni
            Assert.Equal("Hidden", newFeedbacksPage.GetLastRowCurrentVisibility());
        }

        [Fact]
        public void TestSuccessfulSend_Anon_Public()
        {
            createFeedbackPage.InsertText("selenium test");
            createFeedbackPage.ClickPublic();
            createFeedbackPage.ClickAnonymous();
            createFeedbackPage.SendFeedback();
            createFeedbackPage.WaitForSendFeedback();

            ManagerFeedbackPage newFeedbacksPage = new ManagerFeedbackPage(driver);
            newFeedbacksPage.EnsurePageIsDisplayed();

            Assert.Equal(feedbacksCount + 1, newFeedbacksPage.FeedbacksCount());
            //Promeni za ime
            Assert.Equal("Stefan Apostolovic", newFeedbacksPage.GetLastRowPatient());
            Assert.Equal("selenium test", newFeedbacksPage.GetLastRowFeedbackText());
            Assert.Equal("Public", newFeedbacksPage.GetLastRowDesiredVisibility());
            //Promeni
            Assert.Equal("Pending", newFeedbacksPage.GetLastRowCurrentVisibility());
        }
    }
}
