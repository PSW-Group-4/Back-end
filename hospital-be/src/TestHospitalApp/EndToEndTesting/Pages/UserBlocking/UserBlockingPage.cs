using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace TestHospitalApp.EndToEndTesting.Pages.UserBlocking
{
    public class UserBlockingPage
    {

        private readonly IWebDriver driver;
        public const string URI = @"http://localhost:59198/manager/user-blocking";

        public void Navigate() => driver.Navigate().GoToUrl(URI);
        private IWebElement Table => driver.FindElement(By.Id("usersTable"));
        private ReadOnlyCollection<IWebElement> Rows =>
            Table.FindElements(By.TagName("tr"));

        private IWebElement BlockButton;

        public UserBlockingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void EnsurePageIsDisplayed()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(condition =>
            {
                try
                {
                    return Rows.Count > 1;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
        public void Wait()
        {
            Thread.Sleep(3000);


        }

        public void BlockUser(string userToBlock)
        {
            EnsurePageIsDisplayed();
            var usersRow = -1;
            for (int i = 1; i < Rows.Count; i++)
            {
                var td = Rows[i].FindElements(By.TagName("td"))[0];
                var text = td.Text;
                if (!text.Equals(userToBlock)) continue;
                usersRow = i;
                break;
            }
            if (usersRow == -1) return;
            var blockButton = Rows[usersRow].FindElements(By.TagName("button"))[0];
            blockButton.Click();

        }


        public bool IsUserBlocked(string userToBlock)
        {
            EnsurePageIsDisplayed();
            for (var i = 1; i < Rows.Count; i++)
            {
                var td = Rows[i].FindElements(By.TagName("td"))[0];
                var text = td.Text;
                if (!text.Equals(userToBlock)) continue;
               
                var blockField = Rows[i].FindElements(By.TagName("td"))[2];
                var textBlocked = blockField.Text;
                var nesto = textBlocked.Equals("true");
                return nesto;


            }
            return false;
        }

        internal void UnblockUser(string userToUnblock)
        {
            EnsurePageIsDisplayed();
            var usersRow = -1;
            for (int i = 1; i < Rows.Count; i++)
            {
                var td = Rows[i].FindElements(By.TagName("td"))[0];
                var text = td.Text;
                if (!text.Equals(userToUnblock)) continue;
                usersRow = i;
                break;
            }
            if (usersRow == -1) return;
            var blockButton = Rows[usersRow].FindElements(By.TagName("button"))[0];
            blockButton.Click();
        }
    }
}
