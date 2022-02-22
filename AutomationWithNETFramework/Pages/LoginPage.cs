using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Utilities;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace AutomationWithNETFramework.Pages
{
    public class LoginPage
    {
        DriverHelper Driver;
        public LoginPage(DriverHelper driver) { 
            this.Driver = driver;
        }

        public void enterUsername(string user) {
            IWebElement loginTxtbox = Driver.driver.FindElement(By.Id("UserName"));
            loginTxtbox.SendKeys(user);
        }
        public void enterPassword(string pswd) {
            IWebElement passwordTxtbox = Driver.driver.FindElement(By.Id("Password"));
            passwordTxtbox.SendKeys(pswd);
        }

        public void clickRememberMeChkBox() {
            IWebElement RememberMeChkbox = Driver.driver.FindElement(By.Id("RememberMe"));
            RememberMeChkbox.Click();
        }
        public void clicksignInBtn() {
            IWebElement signInBtn = Driver.driver.FindElement(By.CssSelector("input[type=submit]"));
            signInBtn.Click();
        }

        public string getDataFromJsonFile() {
            string dataFromJsonFile="";
            using (var reader = new StreamReader(@"C:\Users\Christian Bautista\source\repos\AutomationWithNETFramework\AutomationWithNETFramework\Utilities\externalData.json")) { 
                dataFromJsonFile = reader.ReadToEnd();
                //var data = JsonConvert.DeserializeObject<ExternalData>(dataFromJsonFile);
                /*string user = data.username;
                string password = data.password;*/
            }
                return dataFromJsonFile;
        }
    }
}
