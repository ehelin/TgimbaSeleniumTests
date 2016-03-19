using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class RunAll
    {        
        [TestMethod]
        public void RunAllLocalTests()
        {
            BaseTest bt = new BaseTest();
            bt.Setup();

            CleanUpLocal();
            RunAllTestsLocalMobile("http://localhost:12738/WebBucketList/Mobile");

            CleanUpLocal();
            RunAllTestsLocalDesktop("http://localhost:12738/WebBucketList/Desktop");
        }
        
        public void CleanUpLocal()
        {
            BaseTest bt = new BaseTest();
            bt.CleanUpLocal();
        }
        
        private void RunAllTestsLocalDesktop(string url)
        {
            Chrome.DesktopHappyPath chromeDesk = new Chrome.DesktopHappyPath(url);
            chromeDesk.TestHappyPathChrome();
            CleanUpLocal();

            Firefox.DesktopHappyPath firefoxDesk = new Firefox.DesktopHappyPath(url);
            firefoxDesk.TestHappyPathFireFox();
            CleanUpLocal();

            InternetExplorer.DesktopHappyPath ieDesk = new InternetExplorer.DesktopHappyPath(url);
            ieDesk.TestHappyPathInternetExplorer();
            CleanUpLocal();
        }

        private void RunAllTestsLocalMobile(string url)
        {
            Chrome.MobileHappyPath chromeDesk = new Chrome.MobileHappyPath(url);
            chromeDesk.TestHappyPathMobileChrome();
            CleanUpLocal();

            Firefox.MobileHappyPath firefoxMobile = new Firefox.MobileHappyPath(url);
            firefoxMobile.TestHappyPathMobileFireFox();
            CleanUpLocal();

            InternetExplorer.MobileHappyPath ieDesk = new InternetExplorer.MobileHappyPath(url);
            ieDesk.TestHappyPathMobileInternetExplorer();
            CleanUpLocal();
        }        
    }
}
