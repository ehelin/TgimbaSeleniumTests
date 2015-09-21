using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using TgimbaSeleniumTests.Tests;
using System.Drawing;

namespace TgimbaSeleniumTests.Tests.InternetExplorer
{
    [TestClass]
    public class MobileHappyPath : BaseMobileTest
    {
        public MobileHappyPath()
        {
        }
               
        public MobileHappyPath(string pUrl)
        {
            url = pUrl;
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void TestHappyPathMobileInternetExplorer()
        {
            TestHappyPath(new InternetExplorerDriver());
        }
    }
}
