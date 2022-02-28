using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Locators
{
    public class EmployeeListLocators
    {
        //public DriverHelper Driver;
        //public EmployeeListLocators(DriverHelper driver) => Driver = driver;

        static IWebElement searchTbx = DriverHelper.Driver.FindElement(By.Name("searchTerm"));
        static IWebElement searchBtn = DriverHelper.Driver.FindElement(By.CssSelector("input[type=submit]"));

        public static void searchForAnItem(string valueToEnter) {
            searchTbx.SendKeys(valueToEnter);
            searchBtn.Click();
        }

        public static bool validateFirstRowUiData(string valueToFind) {
            DriverHelper.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            bool state = false;
            string rowText;
            IWebElement valueExpected = DriverHelper.Driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]"));
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
