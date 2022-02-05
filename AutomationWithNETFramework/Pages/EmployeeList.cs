using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Utilities;
using OpenQA.Selenium;
using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace AutomationWithNETFramework.Pages
{
    public class EmployeeList
    {
        public DriverHelper Driver;
        public ServerSettings serverSettings;
        public EmployeeList(DriverHelper driver, ServerSettings serverSettings) {
            this.Driver = driver;
            this.serverSettings = serverSettings;
        }

        public void searchForAValue(string valueToSearchFor) {
            IWebElement searchTbx = Driver.driver.FindElement(By.Name("searchTerm"));
            searchTbx.SendKeys(valueToSearchFor);
            IWebElement searchBtn = Driver.driver.FindElement(By.CssSelector("input[type=submit]"));
            searchBtn.Click();
        }

        public bool validateDataDisplayed(string valueToFind)
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement valueExpected = Driver.driver.FindElement(By.XPath("//table/tbody/tr[2]"));
            bool state = false;
            string rowText;
            if (valueExpected.Displayed)
            {
                rowText = valueExpected.Text;
                Console.WriteLine(rowText);
                if (rowText.Contains(valueToFind)) state = true;
            }
            return state;
        }

        public bool validateDataDisplayed()
        {
            IRestResponse res = getResponseData("posts/{Id}", "1");
            var author = res.deserializeResponse()["author"];
            Console.WriteLine("Autohr to be validated is: ");
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement valueExpected = Driver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]"));
            bool state = false;
            string uiAuthor;
            if (valueExpected.Displayed)
            {
                uiAuthor = valueExpected.Text;
                Console.WriteLine(uiAuthor);
                if (author.Contains(uiAuthor)) state = true;
            }
            return state;
        }

        public void createANewEmployee(string name, string salary, string durationWorked, string grade, string email) {
            IWebElement createNewBtn = Driver.driver.FindElement(By.XPath("//*[contains(text(), 'Create New')]"));
            createNewBtn.Click();
            IWebElement nameTbx = Driver.driver.FindElement(By.Id("Name"));
            nameTbx.SendKeys(name);
            IWebElement salaryTbx = Driver.driver.FindElement(By.Id("Salary"));
            salaryTbx.SendKeys(salary);
            IWebElement durationWorkedTbx = Driver.driver.FindElement(By.Id("DurationWorked"));
            durationWorkedTbx.SendKeys(durationWorked);
            IWebElement gradeTbx = Driver.driver.FindElement(By.Id("Grade"));
            gradeTbx.SendKeys(grade);
            IWebElement emailTbx = Driver.driver.FindElement(By.Id("Email"));
            emailTbx.SendKeys(email);
            IWebElement createBtn = Driver.driver.FindElement(By.CssSelector("input[value='Create']"));
            createBtn.Click();
        }

        public IRestResponse getResponseData(string endpoint, string number) {
            //string baseUrl = ConfigurationManager.AppSettings["baseUrl"];
            serverSettings.client = new RestClient("http://localhost:3000/");
            serverSettings.request = new RestRequest(endpoint, Method.GET);
            serverSettings.request.AddUrlSegment("Id", Convert.ToInt32(number));
            var res = serverSettings.client.Execute(serverSettings.request);
            return res;
        }
    }
}
