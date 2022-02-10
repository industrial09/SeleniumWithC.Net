using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Pages;
using AutomationWithNETFramework.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AutomationWithNETFramework.TestSteps
{
    [Binding]
    public class CommomStepDefinitions
    {
        DriverHelper Driver;
        LandingPage landingpage;
        LoginPage loginpage;

        //Appying Context Injection
        CommomStepDefinitions(DriverHelper driver)
        {
            Driver = driver;
            landingpage = new LandingPage(Driver);
            loginpage = new LoginPage(Driver);
        }

        [Given(@"I navigate to Landing page")]
        public void GivenINaviageToLandingPage()
        {
            var dataFromJsonFile = loginpage.getDataFromJsonFile();
            var data = JsonConvert.DeserializeObject<ExternalData>(dataFromJsonFile);
            Driver.driver.Navigate().GoToUrl(data.url);
        }

        [When(@"I login to site")]
        public void WhenILoginToSite()
        {
            landingpage.clickLoginLink();
            var dataFromJsonFile = loginpage.getDataFromJsonFile();
            var data = JsonConvert.DeserializeObject<ExternalData>(dataFromJsonFile);
            loginpage.enterUsername(data.username);
            loginpage.enterPassword(data.password);
            loginpage.clickRememberMeChkBox();
            loginpage.clicksignInBtn();
        }
    }
}
