using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using TestHospitalApp.EndToEndTesting.Pages.Login;
using TestHospitalApp.EndToEndTesting.Pages.ScheduleRenovation;
using Xunit;

namespace TestHospitalApp.EndToEndTesting.Tests.ScheduleRenovation
{
    public class ScheduleRenovationTest
    {
        public IWebDriver Driver;
        public ScheduleRenovationPage ScheduleRenovationPage;
        private LoginPage loginPage;

        public ScheduleRenovationTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");            // open Browser in maximized mode
            options.AddArguments("disable-infobars");           // disabling infobars
            options.AddArguments("--disable-extensions");       // disabling extensions
            options.AddArguments("--disable-gpu");              // applicable to windows os only
            options.AddArguments("--disable-dev-shm-usage");    // overcome limited resource problems
            options.AddArguments("--no-sandbox");               // Bypass OS security model
            options.AddArguments("--disable-notifications");    // disable notifications
            
            LoginPrivate(options);

            ScheduleRenovationPage.Navigate();
        }

        public void Dispose()
        {
            Driver.Quit();
            Driver.Dispose();
        }

        private void LoginPrivate(ChromeOptions options) 
        { 
            Driver = new ChromeDriver(options);
            ScheduleRenovationPage = new ScheduleRenovationPage(Driver);
            loginPage = new LoginPage(Driver);
            ScheduleRenovationPage.NavigateStart();
            loginPage.EnterUsernameAndPassword("manager1", "manager1");
            loginPage.PressLoginButton();

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.Url == "http://localhost:4200/manager");
        }

        [Fact]
        public void Schedule_Renovation_Merge()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            // First step
            ScheduleRenovationPage.MatSelectInput("TypeOfRenovation","Merge");
            ScheduleRenovationPage.ClickButton("FirstStepButtonNext");
            
            // Second step
            wait.Until(driver => driver.FindElement(By.Id("ChooseBuilding")).Displayed);
            ScheduleRenovationPage.MatSelectInput("ChooseBuilding","Zgrada A");
            wait.Until(driver => {
                driver.FindElement(By.Id("ChooseFloor")).Click();
                return driver.FindElement(By.Id("Sprat 1"));
            }).Click();

            wait.Until(driver => {
                driver.FindElement(By.Id("ChooseRoom1")).Click();
                return driver.FindElement(By.Id("Name 03ChooseRoom1"));
            }).Click();

            wait.Until(driver => {
                driver.FindElement(By.Id("ChooseRoom2")).Click();
                return driver.FindElement(By.Id("Name 04ChooseRoom2"));
            }).Click();
            ScheduleRenovationPage.ClickButton("SecondStepButtonNext");

            // Third step
            wait.Until(driver => driver.FindElement(By.Id("DatePicker")).Displayed);
            DateTime time = DateTime.Now.AddDays(3);
            Driver.FindElement(By.Id("DatePicker")).SendKeys(time.ToShortDateString());
            Driver.FindElement(By.Id("DaysDuration")).SendKeys("1");
            Driver.FindElement(By.Id("HoursDuration")).SendKeys("0");
            Driver.FindElement(By.Id("MinutesDuration")).SendKeys("0");
            ScheduleRenovationPage.ClickButton("ThirdStepButtonNext");

            // Forth step
            wait.Until(driver => driver.FindElement(By.Id("DatePickerSpecificDate")).Displayed);
            wait.Until(driver => {
                driver.FindElement(By.Id("DatePickerSpecificDate")).Click();
                return driver.FindElement(By.Id("date"));
            }).Click();
            ScheduleRenovationPage.ClickButton("ForthStepButtonNext");

            //FifthStep
            wait.Until(driver => driver.FindElement(By.Id("AddRoom3Name")).Displayed);
            Driver.FindElement(By.Id("AddRoom3Name")).SendKeys("NewRoom");
            Driver.FindElement(By.Id("AddRoom3Description")).SendKeys("Yes");
            Driver.FindElement(By.Id("AddRoom3Number")).SendKeys("123");
            ScheduleRenovationPage.ClickButton("FifthStepButtonNext");
            
            //Finish
            wait.Until(driver => driver.FindElement(By.Id("FinishButton")).Displayed);
            ScheduleRenovationPage.ClickButton("FinishButton");
            Assert.True(true);
            Dispose();
        }

        [Fact]
        public void Schedule_Renovation_Split()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            // First step
            ScheduleRenovationPage.MatSelectInput("TypeOfRenovation","Split");
            ScheduleRenovationPage.ClickButton("FirstStepButtonNext");
            
            // Second step
            wait.Until(driver => driver.FindElement(By.Id("ChooseBuilding")).Displayed);
            ScheduleRenovationPage.MatSelectInput("ChooseBuilding","Zgrada A");
            wait.Until(driver => {
                driver.FindElement(By.Id("ChooseFloor")).Click();
                return driver.FindElement(By.Id("Sprat 1"));
            }).Click();

            wait.Until(driver => {
                driver.FindElement(By.Id("ChooseRoom1")).Click();
                return driver.FindElement(By.Id("Name 03ChooseRoom1"));
            }).Click();

            ScheduleRenovationPage.ClickButton("SecondStepButtonNext");

            // Third step
            wait.Until(driver => driver.FindElement(By.Id("DatePicker")).Displayed);
            DateTime time = DateTime.Now.AddDays(7);
            Driver.FindElement(By.Id("DatePicker")).SendKeys(time.ToShortDateString());
            Driver.FindElement(By.Id("DaysDuration")).SendKeys("1");
            Driver.FindElement(By.Id("HoursDuration")).SendKeys("0");
            Driver.FindElement(By.Id("MinutesDuration")).SendKeys("0");
            ScheduleRenovationPage.ClickButton("ThirdStepButtonNext");

            // Forth step
            wait.Until(driver => driver.FindElement(By.Id("DatePickerSpecificDate")).Displayed);
            wait.Until(driver => {
                driver.FindElement(By.Id("DatePickerSpecificDate")).Click();
                return driver.FindElement(By.Id("date"));
            }).Click();
            ScheduleRenovationPage.ClickButton("ForthStepButtonNext");

            //FifthStep
            wait.Until(driver => driver.FindElement(By.Id("AddRoom1Name")).Displayed);
            Driver.FindElement(By.Id("AddRoom1Name")).SendKeys("NewRoom1");
            Driver.FindElement(By.Id("AddRoom1Description")).SendKeys("Yes");
            Driver.FindElement(By.Id("AddRoom1Number")).SendKeys("123");

            Driver.FindElement(By.Id("AddRoom2Name")).SendKeys("NewRoom2");
            Driver.FindElement(By.Id("AddRoom2Description")).SendKeys("Yes");
            Driver.FindElement(By.Id("AddRoom2Number")).SendKeys("123");

            ScheduleRenovationPage.ClickButton("FifthStepButtonNext");
            
            //Finish
            wait.Until(driver => driver.FindElement(By.Id("FinishButton")).Displayed);
            ScheduleRenovationPage.ClickButton("FinishButton");
            Assert.True(true);
            Dispose();
        }
    }
}