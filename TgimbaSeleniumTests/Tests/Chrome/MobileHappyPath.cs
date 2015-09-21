using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using TgimbaSeleniumTests.Tests;
using System.Drawing;

namespace TgimbaSeleniumTests.Tests.Chrome
{
    [TestClass]
    public class MobileHappyPath : BaseMobileTest
    {
        public MobileHappyPath(string pUrl)
        {
            url = pUrl;
        }
        public MobileHappyPath()
        { }

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
        public void TestHappyPathMobileChrome()
        {            
            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--test-type");
            ChromeDriver cd = new ChromeDriver(co);
            TestHappyPath(cd);
        }
    }
}
