using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class BaseDesktopTest : BaseTest
    {
        public BaseDesktopTest() {}

        protected void TestHappyPath(RemoteWebDriver browser)
        {
            browser.Manage().Window.Maximize();

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
            AddItemFromEditMenu(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            EditItem(browser);
            System.Threading.Thread.Sleep(_testStepInterval);

            DeleteItem(browser);
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

            TestCategoryFilters(browser);

            Sort(browser);
            
            Utilities.CloseBrowser(browser);
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

            link = browser.FindElement(By.Id("ProcessEdit0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopDeleteButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("SearchTerm")).SendKeys("drive");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("searchButtonSubmit"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("ProcessEdit0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopEditButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("BIItemName")).SendKeys(" edited item value");
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement rankingItemSelect = browser.FindElement(By.Name("rankingItemSelect"));
            SelectElement selectElement = new SelectElement(rankingItemSelect);
            selectElement.SelectByText("Warm");
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("EditBIButtonSubmit"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
        protected void AddItemFromEditMenu(RemoteWebDriver browser)
        {
            IWebElement link = browser.FindElement(By.Id("blAHrefLink0"));
            link.Click();

            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopAddButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("BIItemName")).SendKeys("Bucket List Item 2");
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement rankingItemSelect = browser.FindElement(By.Name("rankingItemSelect"));
            SelectElement selectElement = new SelectElement(rankingItemSelect);
            selectElement.SelectByText("Cool");

            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("AddBIButtonSubmit"));
            link.Click();
        }
        protected void EditItem(RemoteWebDriver browser)
        {
            IWebElement link = browser.FindElement(By.Id("blAHrefLink0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopEditButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("BIItemName")).Clear();
            browser.FindElement(By.Id("BIItemName")).SendKeys("Bucket item test 1 with edited item value");
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
            IWebElement link = browser.FindElement(By.Id("blAHrefLink0"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopDeleteButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
    }
}
