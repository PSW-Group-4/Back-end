using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHospitalApp.EndToEndTesting.Pages.Maps
{
    public class BuildingMapPage
    {
        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:4200/manager/maps";
        public const string LoginURI = @"http://localhost:4200/login";

        public BuildingMapPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement buildingB => driver.FindElement(By.XPath("//*[@id='52d812c9-ab26-46ba-a4f6-17f492c71510']"));

        private IWebElement submitB => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/button"));

        private IWebElement tempButton => driver.FindElement(By.XPath("/html/body/app-root/app-manager-root/app-maps-main-container/div/div[2]/div[1]/app-buildings/div/div[2]/div/div/mat-card/button"));

        private IWebElement tempBox => driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/mat-form-field[2]/div/div[1]/div/input"));

        public void press()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("//*[@id='52d812c9-ab26-46ba-a4f6-17f492c71510']"));
            buildingB.Click();
        }
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

        public void press3()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/app-root/app-manager-root/app-maps-main-container/div/div[2]/div[1]/app-buildings/div/div[2]/div/div/mat-card/button"));
            tempButton.Click();
        }

        public void write(String s)
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/mat-form-field[2]/div/div[1]/div/input"));
            tempBox.Clear();
            tempBox.SendKeys(s);
        }

        public void press2()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/button"));
            submitB.Click();
        }

        public String read()
        {
            WebDriverWait myDynamicElement = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            myDynamicElement.Until(driver => CheckIfItExists("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/mat-form-field[2]/div/div[1]/div/input"));
            String s = driver.FindElement(By.XPath("/html/body/div[2]/div[2]/div/mat-dialog-container/app-edit-building/div/mat-form-field[2]/div/div[1]/div/input")).GetAttribute("value").ToString();
            return s;
        }

        public void Navigate() => driver.Navigate().GoToUrl(URI);
        public void NavigateStart() => driver.Navigate().GoToUrl(LoginURI);
    }
}
