
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
        private ScenarioContext _scenarioContext;

        //Appying Context Injection
        //static DriverHelper Driver;
        Featurehooks(ScenarioContext scenarioContext)
        {
            //Driver = driver;
            _scenarioContext = scenarioContext;
        }
            

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
        public static void beforeFeature(FeatureContext featureContext)
        {
            featureName = extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void beforeScenario() {
            scenario = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            //string browser = ConfigurationManager.AppSettings["browser"];
            //if (browser == "chrome") {
                ChromeOptions options = new ChromeOptions();
                options.AcceptInsecureCertificates = true;
                options.AddArguments("start-maximized");
                //options.AddArguments("--headless");
                new DriverManager().SetUpDriver(new ChromeConfig());
                DriverHelper.Driver = new ChromeDriver(options);
            //}
            //else if(browser == "firefox") Driver.driver = new FirefoxDriver();

        }

        [AfterStep]
        public void afterStep() {
            //Need to know kind of step
            var steptype = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            //var steptype = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (_scenarioContext.TestError == null)
            {
                if (steptype == "Given") scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                else if (steptype == "When") scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                else if (steptype == "Then") scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                else if (steptype == "And") scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
            }
            else{
                if (steptype == "Given") scenario.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (steptype == "When") scenario.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (steptype == "Then") scenario.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                else if (steptype == "And") scenario.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
            }
        }

        [AfterScenario]
        public static void afterScenario()
        {
            DriverHelper.Driver.Quit();
        }
    }
}
