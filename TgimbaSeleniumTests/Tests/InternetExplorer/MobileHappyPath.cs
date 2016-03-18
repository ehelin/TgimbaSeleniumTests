using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;

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
