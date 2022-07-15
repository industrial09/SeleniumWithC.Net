using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyProject.Base;

namespace AutomationWithNETFramework.Locators
{
    public class EmployeeListLocators
    {
        //public DriverHelper Driver;
        //public EmployeeListLocators(DriverHelper driver) => Driver = driver 

        public static void searchForAnItem(string valueToEnter) {
            IWebElement searchTbx = DriverContext.Driver.FindElement(By.Name("searchTerm"));
            IWebElement searchBtn = DriverContext.Driver.FindElement(By.CssSelector("input[type=submit]"));
            searchTbx.SendKeys(valueToEnter);
            searchBtn.Click();
        }

        public static bool validateFirstRowUiData(string valueToFind) {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            bool state = false;
            string rowText;
            IWebElement valueExpected = DriverContext.Driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]"));
            if (valueExpected.Displayed)
            {
                rowText = valueExpected.Text;
                Console.WriteLine(rowText);
                if (rowText == valueToFind) state = true;
            }
            return state;
        }

        public void clickOnElement(IWebElement el) => el.Click();

        public void clearField(IWebElement el) => el.Clear();
    }
}
