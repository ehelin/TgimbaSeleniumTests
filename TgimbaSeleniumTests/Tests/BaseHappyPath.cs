using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.UI;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class BaseHappyPath : BaseTest
    {
        public BaseHappyPath() {}

        protected void TestHappyPath(RemoteWebDriver browser)
        {
            browser.Manage().Window.Maximize();

            LaunchPageTest(browser, url);
            System.Threading.Thread.Sleep(_testStepInterval);
            
            //login/registration -----------------------------------------------
            LoginTest(browser, "test", "test", true);
            System.Threading.Thread.Sleep(_testStepInterval);

            TestRegistration(browser, "testUser", "testUser23", "test@aol.com", false);
            System.Threading.Thread.Sleep(_testStepInterval);							 

            LoginTest(browser, "testUser", "testUser23", false);	   
            System.Threading.Thread.Sleep(_testStepInterval);	 
														
            //menu tests -------------------------------------------------------  
			ClickAction(browser, "btnMainMenu");	 		
			ClickAction(browser, "hvJsCancelBtn");	

			// show add screen, cancel and reshow add screen
			ClickAction(browser, "btnMainMenu");				
			ClickAction(browser, "hvJsAddBucketListItemBtn");				
			ClickAction(browser, "hvJsAddCancellBtn");			
												  
			// main grid tests --------------------------------------------------
			// add item	  	
            AddItem(browser, "Bucket item test 1", "Hot", true, "1.2", "2.1");
            System.Threading.Thread.Sleep(_testStepInterval);	  

			// edit item
			EditItem(browser, "Updated Bucket item test 1", "Warm", "3.4", "10.9");
            System.Threading.Thread.Sleep(_testStepInterval);
				   			
			// delete item
			ClickAction(browser, "hvJsFormDeleteBtn");	
				  
            //sort ----------------------------------------------------------
			// show sort menu and return to main bucket list
			ClickAction(browser, "btnMainMenu");	   				// main menu button
			ClickAction(browser, "hvJsSortBucketListItemBtn");		// sort button				  
			ClickAction(browser, "hvJsCancelBtn");					// cancel button		
															
            AddSortCategoryTestItems(browser);	   
			System.Threading.Thread.Sleep(_testStepInterval);

            Sort(browser);			   
			System.Threading.Thread.Sleep(_testStepInterval);

           // logout and close browser
			ClickAction(browser, "btnMainMenu");						  
			ClickAction(browser, "hvJsLogOutBtn");	// logout 	
            Utilities.CloseBrowser(browser);
        }
		
		// TODO - update once implemented on website(s)	   
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
    }
}
