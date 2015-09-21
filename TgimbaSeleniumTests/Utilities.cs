using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
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
