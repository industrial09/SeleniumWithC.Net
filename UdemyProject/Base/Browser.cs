using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyProject.Base
{
    public class Browser
    {
        private readonly IWebDriver _driver;

        public Browser(IWebDriver driver)
        {
            _driver = driver;
        }

        public BrowserType Type { get; set; }

        public void GoToUrl(string url)
        {
            _driver.Url = url;
        }
    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
