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
				"http://localhost:61755/home/HtmlVanillaJsIndex",	// Vanilla JS
				"http://localhost:61755/home/HtmlJQueryIndex",		// JQuery
				//"https://localhost:44367/",							// Angular 6
				//"https://localhost:44340/",							// React JS
			};
		}
    }
}
