using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace TgimbaSeleniumTests.Tests.Chrome
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
        public void TestHappyPathChrome()
        {
            ChromeOptions co = new ChromeOptions();
            co.AddArgument("--test-type");
            ChromeDriver cd = new ChromeDriver("C:\\Users\\ehelin\\Downloads\\chromedriver_win32", co);
            TestHappyPath(cd);
        }
    }
}
