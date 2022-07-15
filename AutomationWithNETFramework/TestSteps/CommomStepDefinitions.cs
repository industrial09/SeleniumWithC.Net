using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Pages;
using AutomationWithNETFramework.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using UdemyProject.Base;

namespace AutomationWithNETFramework.TestSteps
{
    [Binding]
    public class CommomStepDefinitions
    {
        //DriverHelper Driver;
        LandingPage landingpage;
        LoginPage loginpage;
        //ExternalData data;

        //Appying Context Injection
        CommomStepDefinitions()
        {
            //Driver = driver;
            landingpage = new LandingPage();
            loginpage = new LoginPage();
        }

        [Given(@"I navigate to Landing page")]
        public void GivenINaviageToLandingPage()
        {
            var dataFromJsonFile = loginpage.getDataFromJsonFile();
            var data = JsonConvert.DeserializeObject<ExternalData>(dataFromJsonFile);
            DriverContext.Browser.GoToUrl(data.siteurl);
            //DriverHelper.Driver.Navigate().GoToUrl(data.siteurl);
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
