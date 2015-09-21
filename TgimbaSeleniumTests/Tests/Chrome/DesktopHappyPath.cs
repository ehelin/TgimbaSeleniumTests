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

namespace TgimbaSeleniumTests.Tests.Chrome
{
    [TestClass]
    public class DesktopHappyPath : BaseDesktopTest
    {
        public DesktopHappyPath(string pUrl)
        {
            url = pUrl;
        }
        public DesktopHappyPath()
        {
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
        public void TestHappyPathChrome()
        {
            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--test-type");
            ChromeDriver cd = new ChromeDriver(co);
            TestHappyPath(cd);
        }
    }
}
