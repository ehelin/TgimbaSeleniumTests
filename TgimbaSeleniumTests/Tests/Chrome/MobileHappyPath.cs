﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

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
