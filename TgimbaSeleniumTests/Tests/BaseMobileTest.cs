using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using OpenQA.Selenium.Support.UI;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class BaseMobileTest : BaseTest
    {
        public BaseMobileTest() {}

        protected void TestHappyPath(RemoteWebDriver browser)
        {
            browser.Manage().Window.Size = new Size(450, 600);

            LaunchPageTest(browser, url);
            System.Threading.Thread.Sleep(_testStepInterval);

            //login/registration -----------------------------------------------
            LoginTest(browser, "test", "test", true);
            System.Threading.Thread.Sleep(_testStepInterval);

            TestRegistration(browser, "testUser", "testUser23", "test@aol.com", true);
            System.Threading.Thread.Sleep(_testStepInterval);

            LoginTest(browser, "testUser", "testUser23", false);
            System.Threading.Thread.Sleep(_testStepInterval);

            LogOut(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            LoginTest(browser, "testUser", "testUser23", false);
            System.Threading.Thread.Sleep(_testStepInterval);

            //menu tests -------------------------------------------------------
            AddItem(browser, "Bucket item test 1", "Hot");
            System.Threading.Thread.Sleep(_testStepInterval);

            //edit detail tests -----------------------------------------------
            EditItem(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            DeleteItem(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            //search ----------------------------------------------------------
            AddItem(browser, "Bucket drive item test 1", "Hot");
            System.Threading.Thread.Sleep(_testStepInterval);

            AddItem(browser, "Bucket drive item test 2", "Hot");
            System.Threading.Thread.Sleep(_testStepInterval);

            Search(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            DeleteItem(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            //sort ----------------------------------------------------------
            AddSortCategoryTestItems(browser);

            Sort(browser);

            Utilities.CloseBrowser(browser);
        }
         
        protected void EditItem(RemoteWebDriver browser)
        {
            IWebElement link = browser.FindElement(By.Id("btnEdit0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("BIItemName")).SendKeys("edited item value");
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement rankingItemSelect = browser.FindElement(By.Name("rankingItemSelect"));
            SelectElement selectElement = new SelectElement(rankingItemSelect);
            selectElement.SelectByText("Warm");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("EditBIButtonSubmit"));
            link.Click();
        }
        protected void DeleteItem(RemoteWebDriver browser)
        {
            IWebElement link = browser.FindElement(By.Id("btnDelete0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
        protected void Search(RemoteWebDriver browser)
        {
            browser.FindElement(By.Id("SearchTerm")).SendKeys("drive");
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement link = browser.FindElement(By.Id("searchButtonSubmit"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("CancelSearchResultDisplay"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("SearchTerm")).SendKeys("drive");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("searchButtonSubmit"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("btnSearchEdit0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
            
            browser.FindElement(By.Id("BIItemName")).SendKeys("edited item value");
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement rankingItemSelect = browser.FindElement(By.Name("rankingItemSelect"));
            SelectElement selectElement = new SelectElement(rankingItemSelect);
            selectElement.SelectByText("Warm");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("EditBIButtonSubmit"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
            
            browser.FindElement(By.Id("SearchTerm")).SendKeys("drive");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("searchButtonSubmit"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("btnSearchDelete0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);            
        }
    }
}
