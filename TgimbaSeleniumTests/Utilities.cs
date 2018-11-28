using OpenQA.Selenium.Remote;
using System.Collections.Generic;

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

		public static List<string> GetUrls() {
			return new List<string>{
				//"http://localhost:61755/home/HtmlVanillaJsIndex",	// Vanilla JS
				"http://localhost:61755/home/HtmlJQueryIndex",		// JQuery
				//"http://localhost:62356/",							// Angular 6
				//"http://localhost:59259/",							// React JS
			};
		}
    }
}
