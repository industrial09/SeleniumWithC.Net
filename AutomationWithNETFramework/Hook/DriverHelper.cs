using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Hook
{
    public static class DriverHelper
    {
        //public IWebDriver driver { get; set; }
        private static IWebDriver driver;

        public static IWebDriver Driver { get => driver; set => driver = value; }
    }
}
