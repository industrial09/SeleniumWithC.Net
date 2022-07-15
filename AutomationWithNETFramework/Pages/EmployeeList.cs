using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Locators;
using AutomationWithNETFramework.Utilities;
using AutomationWithNETFramework.Utilities.DBQueries;
using Newtonsoft.Json;
using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using UdemyProject.Base;
using UdemyProject.Extensions;

namespace AutomationWithNETFramework.Pages
{
    public class EmployeeList
    {
        //public DriverHelper Driver;
        public ServerSettings serverSettings;
        public EmployeeListQueries queries;
        public LoginPage loginpage;
        //public EmployeeListLocators locs;

        //LoginPage loginpage = new LoginPage();
        public DBConexion dbCon;

        public EmployeeList(ServerSettings serverSettings) {
            //this.Driver = driver;
            //locs = new EmployeeListLocators();
            this.serverSettings = serverSettings;
            loginpage = new LoginPage();
            dbCon = new DBConexion();
        }

        static IWebElement valueExpected = DriverContext.Driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]"));
        private string letter;

        public string Letter {
            get { return letter; }
            set { letter = value; }
        }

        public void searchForAValue(string valueToSearchFor) {
            EmployeeListLocators.searchForAnItem(valueToSearchFor);
        }

        public bool validateDataDisplayed(string valueToFind)
        {
            return EmployeeListLocators.validateFirstRowUiData(valueToFind);
        }

        public bool validateGetRequestDataDisplayed(string endpoint, string variableSegment, List<string> keysToValidate)
        {
            IRestResponse res = getGETResponseData(endpoint, variableSegment);
            var author = res.deserializeResponse()[keysToValidate[0]];
            Console.WriteLine("Author to be validated is: "+author);
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            bool state = false;
            string uiAuthor;
            if (valueExpected.Displayed)
            {
                uiAuthor = valueExpected.Text;
                if (author == uiAuthor) state = true;
            }
            return state;
        }

        public void createANewEmployee(string name, string salary, string durationWorked, string grade, string email) {
            IWebElement createNewBtn = DriverContext.Driver.FindElement(By.XPath("//*[contains(text(), 'Create New')]"));
            createNewBtn.Click();
            IWebElement nameTbx = DriverContext.Driver.FindElement(By.Id("Name"));
            nameTbx.SendKeys(name);
            IWebElement salaryTbx = DriverContext.Driver.FindElement(By.Id("Salary"));
            salaryTbx.SendKeys(salary);
            IWebElement durationWorkedTbx = DriverContext.Driver.FindElement(By.Id("DurationWorked"));
            durationWorkedTbx.SendKeys(durationWorked);
            IWebElement gradeTbx = DriverContext.Driver.FindElement(By.Id("Grade"));
            gradeTbx.SendKeys(grade);
            IWebElement emailTbx = DriverContext.Driver.FindElement(By.Id("Email"));
            emailTbx.SendKeys(email);
            IWebElement createBtn = DriverContext.Driver.FindElement(By.CssSelector("input[value='Create']"));
            createBtn.Click();
        }

        public IRestResponse getGETResponseData(string endpoint, string number) {
            var dataFromJsonFile = loginpage.getDataFromJsonFile();
            var data = JsonConvert.DeserializeObject<ExternalData>(dataFromJsonFile);
            serverSettings.client = new RestClient(data.serverurl);
            serverSettings.request = new RestRequest(endpoint, Method.GET);
            serverSettings.request.AddUrlSegment("Id", Convert.ToInt32(number));
            var res1 = serverSettings.client.ExecuteAsyncRequest<Data>(serverSettings.request).GetAwaiter().GetResult();
            //var res = serverSettings.client.Execute(serverSettings.request);
            return res1;
        }

        public string getUiAuthorData()
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //IWebElement valueExpected = DriverHelper.Driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]"));
            string text="";
            if (valueExpected.Displayed) text = valueExpected.Text;
            return text;
        }

        public SqlDataReader executeDBQuery(string option, string variableVar) {
            SqlConnection conn = dbCon.connectToDB();
            queries = new EmployeeListQueries();
            SqlCommand cmd = new SqlCommand(queries.getQuery(option, variableVar), conn);
            SqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public bool validateDBDataAgainstUIData(string queryOption, string variableValue, string dataToCompare) {
            SqlDataReader data = executeDBQuery(queryOption, variableValue);
            bool state = false;
            string author="";
            while (data.Read()) {
                author = data[0].ToString();
            }
            if(author == dataToCompare) state = true;
            return state;
        }
    }
}
