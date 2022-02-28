using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Locators;
using AutomationWithNETFramework.Pages;
using AutomationWithNETFramework.Utilities;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace AutomationWithNETFramework
{
    [Binding]
    public class AccountActivityStepDefinitions
    {
        //DriverHelper Driver;
        LandingPage landingpage;
        LoginPage loginpage;
        HomePage homepage;
        //EmployeeListLocators locs;
        EmployeeList employeeList;
        ServerSettings ServerSettings;

        string valueGottenFromUI;

        //Appying Context Injection
        AccountActivityStepDefinitions(ServerSettings serverSettings) {
            this.ServerSettings = serverSettings;
            landingpage = new LandingPage();
            loginpage = new LoginPage();
            homepage = new HomePage();
            employeeList = new EmployeeList(ServerSettings);
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
            List<string> list = new List<string>();
            list.Add("author");
            Assert.That(employeeList.validateGetRequestDataDisplayed("posts/{Id}", "1", list), Is.True);
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

        [Then(@"I search for any value (.*)")]
        public void ThenISearchForAnyValue(string valueToSearchFor)
        {
            employeeList.searchForAValue(valueToSearchFor);
            valueGottenFromUI = employeeList.getUiAuthorData();
        }

        [Then(@"I validate data displayed against database data (.*)")]
        public void ThenIValidateDataDisplayedAgainstDatabaseData(string variableValue)
        {
            employeeList.validateDBDataAgainstUIData("getOneAuthor", variableValue, valueGottenFromUI);
        }

    }
}
