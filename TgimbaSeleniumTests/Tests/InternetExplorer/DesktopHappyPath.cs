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
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;

            InternetExplorerDriver ied = new InternetExplorerDriver(options);
            TestHappyPath(ied);
        }
    }
}
