using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;

namespace BrowserInitialization
{
    public class Browser
    {
        private static ChromeDriver browser;

        private Browser() { }        

        public static ChromeDriver GetBrowser()
        {
            if (browser == null)
            {
                browser = new ChromeDriver();
            }
            return browser;
        }
    }
}
