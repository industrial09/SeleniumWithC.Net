using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UdemyProject.Config;

namespace UdemyProject.Base
{
    public class TestInitializeHook
    {
        public static void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

            //Open Browser
            OpenBrowser(Settings.BrowserType);

        }

        private static void OpenBrowser(BrowserType browserType = BrowserType.FireFox)
        {
            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    DriverContext.Driver = new InternetExplorerDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.FireFox:
                    /*var binary = new FirefoxBinary(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
                    var profile = new FirefoxProfile();
                    DriverContext.Driver = new FirefoxDriver(binary, profile);*/
                    DriverContext.Driver = new FirefoxDriver();
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AcceptInsecureCertificates = true;
                    options.AddArguments("start-maximized");
                    //options.AddArguments("--headless");
                    //new DriverManager().SetUpDriver(new ChromeConfig());
                    var driverDir = Environment.GetEnvironmentVariable("CHROMEDRIVER_HOME");
                    /*var driverPath = !string.IsNullOrWhiteSpace(driverDir)
                        ? Path.Combine(driverDir, "chromedriver.exe")
                        : "relative/path"; // see below */

                    // init the driver or add to options
                    DriverContext.Driver = new ChromeDriver(driverDir);
                    DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }

        }
    }
}
