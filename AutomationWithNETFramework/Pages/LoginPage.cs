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
        //DriverHelper Driver;
        /*public LoginPage(DriverHelper driver) { 
            this.Driver = driver;
        }*/

        public void enterUsername(string user) {
            IWebElement loginTxtbox = DriverHelper.Driver.FindElement(By.Id("UserName"));
            loginTxtbox.SendKeys(user);
        }
        public void enterPassword(string pswd) {
            IWebElement passwordTxtbox = DriverHelper.Driver.FindElement(By.Id("Password"));
            passwordTxtbox.SendKeys(pswd);
        }

        public void clickRememberMeChkBox() {
            IWebElement RememberMeChkbox = DriverHelper.Driver.FindElement(By.Id("RememberMe"));
            RememberMeChkbox.Click();
        }
        public void clicksignInBtn() {
            IWebElement signInBtn = DriverHelper.Driver.FindElement(By.CssSelector("input[type=submit]"));
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
