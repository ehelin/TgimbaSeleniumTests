using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TgimbaSeleniumTests.Tests.Chrome;
using TgimbaSeleniumTests.Tests.Firefox;
using TgimbaSeleniumTests.Tests.InternetExplorer;
using TgimbaSeleniumTests.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TgimbaSeleniumTests.Tests
{
    [TestClass]
    public class RunAll
    {
        [TestMethod]
        public void RunAllRemoteTests()
        {
            CleanUpRemote();
            RunAllTestsRemote("http://www.tgimba.com/");
        }
        
        [TestMethod]
        public void RunAllLocalTests()
        {
            RunAllTestsLocal("http://localhost:51468/");
        }

        public void CleanUpRemote()
        {
            BaseTest bt = new BaseTest();
            bt.CleanUpRemote();
        }

        public void CleanUpLocal()
        {
            BaseTest bt = new BaseTest();
            bt.CleanUpLocal();
        }
        
        private void RunAllTestsLocal(string url)
        {
            BaseTest bt = new BaseTest();
            bt.Setup();

            CleanUpRemote();

            Chrome.DesktopHappyPath chromeDesk = new Chrome.DesktopHappyPath(url);
            chromeDesk.TestHappyPathChrome();
            CleanUpLocal();

            Firefox.DesktopHappyPath firefoxDesk = new Firefox.DesktopHappyPath(url);
            firefoxDesk.TestHappyPathFireFox();
            CleanUpLocal();

            InternetExplorer.DesktopHappyPath ieDesk = new InternetExplorer.DesktopHappyPath(url);
            ieDesk.TestHappyPathInternetExplorer();
            CleanUpLocal();

            int flipToMobile = 1;

            Chrome.MobileHappyPath chromeMobile = new Chrome.MobileHappyPath(url);
            chromeMobile.TestHappyPathMobileChrome();
            CleanUpLocal();

            Firefox.MobileHappyPath firefoxMobile = new Firefox.MobileHappyPath(url);
            firefoxMobile.TestHappyPathMobileFireFox();
            CleanUpLocal();

            InternetExplorer.MobileHappyPath ieMobile = new InternetExplorer.MobileHappyPath(url);
            ieMobile.TestHappyPathMobileInternetExplorer();
            CleanUpLocal();
        }

        private void RunAllTestsRemote(string url)
        {
            CleanUpRemote();

            Chrome.DesktopHappyPath chromeDesk = new Chrome.DesktopHappyPath(url);
            chromeDesk.TestHappyPathChrome();
            CleanUpRemote();

            Firefox.DesktopHappyPath firefoxDesk = new Firefox.DesktopHappyPath(url);
            firefoxDesk.TestHappyPathFireFox();
            CleanUpRemote();

            InternetExplorer.DesktopHappyPath ieDesk = new InternetExplorer.DesktopHappyPath(url);
            ieDesk.TestHappyPathInternetExplorer();
            CleanUpRemote();
        }
    }
}
