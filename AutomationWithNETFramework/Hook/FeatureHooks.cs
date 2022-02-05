
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationWithNETFramework.Hook
{
    [Binding]
    public class Featurehooks
    {
        //Appying Context Injection
        DriverHelper Driver;
        Featurehooks(DriverHelper driver) => Driver = driver;

        [BeforeScenario]
        public void beforeScenario() {
            ChromeOptions options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArguments("start-maximized");
            //options.AddArguments("--headless");
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver.driver = new ChromeDriver(options);
        }

        [AfterScenario]
        public void afterScenario()
        {
            Driver.driver.Quit();
        }
    }
}
