
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace AutomationWithNETFramework.Hook
{
    [Binding]
    public class Featurehooks
    {
        private static ExtentReports extentReports;
        private static ExtentTest featureName;
        private ExtentTest scenario;

        //Appying Context Injection
        static DriverHelper Driver;
        Featurehooks(DriverHelper driver) => Driver = driver;

        [BeforeTestRun]
        public static void beforeTestRun() {
            //1st step: create html container reporter
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Christian Bautista\source\repos\AutomationWithNETFramework\AutomationWithNETFramework\ExtentReport.html");
            //2nd step: create ExtentReport and attach report created
            extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void afterTestrun() { 
            extentReports.Flush();
        }

        [BeforeFeature]
        public static void beforeFeature()
        {
            featureName = extentReports.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void beforeScenario() {
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            //string browser = ConfigurationManager.AppSettings["browser"];
            //if (browser == "chrome") {
                ChromeOptions options = new ChromeOptions();
                options.AcceptInsecureCertificates = true;
                options.AddArguments("start-maximized");
                //options.AddArguments("--headless");
                new DriverManager().SetUpDriver(new ChromeConfig());
                Driver.driver = new ChromeDriver(options);
            //}
            //else if(browser == "firefox") Driver.driver = new FirefoxDriver();

        }

        [AfterStep]
        public void afterStep() {
            //Need to know kind of step
            var steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (steptype == "Given") scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (steptype == "When") scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (steptype == "Then") scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (steptype == "And") scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else{
                if (steptype == "Given") scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (steptype == "When") scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (steptype == "Then") scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                else if (steptype == "And") scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
            }
        }

        [AfterScenario]
        public static void afterScenario()
        {
            Driver.driver.Quit();
        }
    }
}
