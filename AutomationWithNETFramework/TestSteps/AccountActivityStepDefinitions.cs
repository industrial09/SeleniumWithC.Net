using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Pages;
using AutomationWithNETFramework.Utilities;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace AutomationWithNETFramework
{
    [Binding]
    public class AccountActivityStepDefinitions
    {
        DriverHelper Driver;
        LandingPage landingpage;
        LoginPage loginpage;
        HomePage homepage;
        EmployeeList employeeList;
        ServerSettings ServerSettings;

        //Appying Context Injection
        AccountActivityStepDefinitions(DriverHelper driver, ServerSettings serverSettings) { 
            Driver = driver;
            this.ServerSettings = serverSettings;
            landingpage = new LandingPage(Driver);
            loginpage = new LoginPage(Driver);
            homepage = new HomePage(Driver);
            employeeList = new EmployeeList(Driver, ServerSettings);
        }

        [Given(@"I navigate to Landing page")]
        public void GivenINaviageToLandingPage()
        {
            Driver.driver.Navigate().GoToUrl("http://eaapp.somee.com/");
        }

        [When(@"I login to site")]
        public void WhenILoginToSite()
        {
            landingpage.clickLoginLink();
            loginpage.enterUsername("admin");
            loginpage.enterPassword("password");
            loginpage.clickRememberMeChkBox();
            loginpage.clicksignInBtn();
        }

        [Given(@"I click Employee List tab")]
        public void GivenIClickEmployeeListTab()
        {
            homepage.clickEmployeeListTab();
        }

        [Then(@"I validate data displayed includes ""([^""]*)""")]
        public void ThenIValidateDataDisplayed(string expectedValue)
        {
            Assert.That(employeeList.validateDataDisplayed(expectedValue), Is.True);
        }

        [Then(@"I validate data displayed against server data")]
        public void ThenIValidateDataDisplayedAgainstServerData()
        {
            Assert.That(employeeList.validateDataDisplayed(), Is.True);
        }

        [Then(@"I search for a value ""([^""]*)""")]
        public void ThenISearchForAValue(string valueToSearchFor)
        {
            employeeList.searchForAValue(valueToSearchFor);
        }

        [When(@"I create a new employee with (.*), (.*), (.*), (.*), (.*)")]
        public void WhenICreateANewEmployeeWithData(string name, string salary, string durationWorked, string grade, string email)
        {
            employeeList.createANewEmployee(name, salary, durationWorked, grade, email);
        }

        [Then(@"I validate new employee has been added as (.*)")]
        public void ThenIValidateNewEmployeeHasBeenAddedAs(string name)
        {
            employeeList.searchForAValue(name);
            Assert.That(employeeList.validateDataDisplayed(name), Is.True);
        }
    }
}
