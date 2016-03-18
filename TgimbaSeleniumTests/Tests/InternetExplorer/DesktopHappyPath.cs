using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;

namespace TgimbaSeleniumTests.Tests.InternetExplorer
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
        public void TestHappyPathInternetExplorer()
        {
            TestHappyPath(new InternetExplorerDriver());
        }
    }
}
