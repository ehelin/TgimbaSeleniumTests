using OpenQA.Selenium.Remote;

namespace TgimbaSeleniumTests
{
    public class Utilities
    {
        public static void CloseBrowser(RemoteWebDriver browser)
        {
            if (browser != null)
            {
                browser.Close();
                browser.Dispose();
                browser = null;
            }
        }
    }
}
