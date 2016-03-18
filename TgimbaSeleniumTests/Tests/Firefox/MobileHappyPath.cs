using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;

namespace TgimbaSeleniumTests.Tests.Firefox
{
    [TestClass]
    public class MobileHappyPath : BaseMobileTest
    {
        public MobileHappyPath(string pUrl)
        {
            url = pUrl;
        }
        public MobileHappyPath()
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
        public void TestHappyPathMobileFireFox()
        {
            TestHappyPath(new FirefoxDriver());
        }
    }
}
