﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Data.SqlClient;

namespace TgimbaSeleniumTests.Tests
{
    public class BaseTest
    {
        //TODO - make configuragble
        protected int _testStepInterval = 1000;
        protected string url = string.Empty;

        #region Base Test Methods

        protected void LogOut(RemoteWebDriver browser)
        {
            IWebElement link = browser.FindElement(By.Id("MenuRequest"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("LogOut"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
        protected void AddItem(RemoteWebDriver browser, string bucketListName, string category)
        {
            IWebElement link = browser.FindElement(By.Id("MenuRequest"));
            link.Click();

            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("AddBucketListItem"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("BIItemName")).SendKeys(bucketListName);
            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement rankingItemSelect = browser.FindElement(By.Name("rankingItemSelect"));
            SelectElement selectElement = new SelectElement(rankingItemSelect);
            selectElement.SelectByText(category);
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("AddBIButtonSubmit"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
        protected void LaunchPageTest(RemoteWebDriver browser, string url)
        {
            browser.Navigate().GoToUrl(url);
            string pageText = browser.FindElement(By.TagName("body")).Text;
        }
        protected void LoginTest(RemoteWebDriver browser, string userName, string passWord, bool expectedAlert)
        {
            browser.FindElement(By.Id("loginDesktopUserName")).SendKeys(userName);
            browser.FindElement(By.Id("loginDesktopPassWord")).SendKeys(passWord);

            System.Threading.Thread.Sleep(_testStepInterval);

            IWebElement link = browser.FindElement(By.Id("loginDesktopSubmitClick"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval + 1000);

            if (expectedAlert)
                browser.SwitchTo().Alert().Accept();
        }
        protected void TestRegistration(RemoteWebDriver browser, string userName, string passWord, string email, bool expectedAlert)
        {
            IWebElement link = browser.FindElement(By.Id("registerDesktopClick"));
            link.Click();

            System.Threading.Thread.Sleep(_testStepInterval);

            browser.FindElement(By.Id("registerDesktopUserName")).SendKeys(userName);
            browser.FindElement(By.Id("registerDesktopEmail")).SendKeys(email);
            browser.FindElement(By.Id("registerDesktopPassword")).SendKeys(passWord);
            browser.FindElement(By.Id("registerDesktopConfirmPassword")).SendKeys(passWord);
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("registerDesktopSubmitClick"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            if (expectedAlert)
                browser.SwitchTo().Alert().Accept();
        }
        protected void Sort(RemoteWebDriver browser)
        {
            SelectSort(browser, "SortBtnTitle", false);
            SelectSort(browser, "SortBtnTitle", true);

            SelectSort(browser, "SortBtnRanking", false);
            SelectSort(browser, "SortBtnRanking", true);

            SelectSort(browser, "SortBtnAchieved", false);
            SelectSort(browser, "SortBtnAchieved", true);

            SelectSort(browser, "SortBtnEntered", false);
            SelectSort(browser, "SortBtnEntered", true);

            SelectSort(browser, "SortBtnClearSort", false);
            SelectSort(browser, "SortBtnClearCancel", false);
        }
        private void SelectSort(RemoteWebDriver browser, string buttonName, bool desc)
        {
            IWebElement link = browser.FindElement(By.Id("MenuRequest"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("SortBucketListItem"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            if (desc)
            {
                link = browser.FindElement(By.Id("biSortDesccb"));
                link.Click();
                System.Threading.Thread.Sleep(_testStepInterval);
            }

            link = browser.FindElement(By.Id(buttonName));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }
        protected void AddSortCategoryTestItems(RemoteWebDriver browser)
        {
            AddItem(browser, "Bucket item test 3", "Hot");
            System.Threading.Thread.Sleep(_testStepInterval);

            AddItem(browser, "Bucket item test 1", "Cool");
            System.Threading.Thread.Sleep(_testStepInterval);

            AddItem(browser, "Bucket item test 7", "Warm");
            System.Threading.Thread.Sleep(_testStepInterval);

            AddItem(browser, "Bucket item test 5", "Hot");
            System.Threading.Thread.Sleep(_testStepInterval);

            AddItem(browser, "Bucket item test 4", "Warm");
            System.Threading.Thread.Sleep(_testStepInterval);

            AddItem(browser, "Bucket item test 2", "Cool");
            System.Threading.Thread.Sleep(_testStepInterval);

            AddItem(browser, "Bucket item test 6", "Hot");
            System.Threading.Thread.Sleep(_testStepInterval);
        }
        protected void TestCategoryFilters(RemoteWebDriver browser)
        {
            IWebElement link = browser.FindElement(By.Id("DesktopHotFilterButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopWarmFilterButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopColdFilterButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);

            link = browser.FindElement(By.Id("DesktopClearFilterButton"));
            link.Click();
            System.Threading.Thread.Sleep(_testStepInterval);
        }

        #endregion

        #region Support 
        
        public void CleanUpLocal()
        {
            DeleteTestUser(Constants.TEST_USER, Constants.DB_CONN_LOCAL_HOST_BUCKETLIST);
        }
        public void CleanUpRemote()
        {
            DeleteTestUser(Constants.TEST_USER, Constants.DB_CONN);
        }
        public void Setup()
        {
            try
            {
                CreateSql(Constants.DB_CONN_LOCAL_HOST_MASTER, Constants.DROP_DB);
            }
            catch (Exception e)
            {
                if (!e.Message.Equals("Cannot drop the database 'BucketList', because it does not exist or you do not have permission."))
                    throw e;
            }
            CreateSql(Constants.DB_CONN_LOCAL_HOST_MASTER, Constants.CREATE_DB);
            CreateSql(Constants.DB_CONN_LOCAL_HOST_BUCKETLIST, Constants.CREATE_SCHEMA);
            CreateSql(Constants.DB_CONN_LOCAL_HOST_BUCKETLIST, Constants.CREATE_TABLE);
        }
        public void TearDown()
        {
            CreateSql(Constants.DB_CONN_LOCAL_HOST_MASTER, Constants.DROP_DB);
        }
        protected void CreateSql(string connectionString, string sql)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = System.Data.CommandType.Text;
            
                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }

        }
        protected void DeleteTestUser(string userName, string connectionString)
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;

            try
            {
                conn = new SqlConnection(connectionString);
                cmd = conn.CreateCommand();
                cmd.CommandText = Constants.DELETE_TEST_USER;
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.Add(new SqlParameter("@userName", userName));

                cmd.Connection.Open();

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
        }

        #endregion
    }
}