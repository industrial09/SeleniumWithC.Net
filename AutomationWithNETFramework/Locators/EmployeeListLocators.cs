using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Locators
{
    public class EmployeeListLocators
    {
        public DriverHelper Driver;
        public EmployeeListLocators(DriverHelper driver) => Driver = driver;

        public void searchForAnItem(string valueToEnter) {
            IWebElement searchTbx = Driver.driver.FindElement(By.Name("searchTerm"));
            searchTbx.SendKeys(valueToEnter);
            IWebElement searchBtn = Driver.driver.FindElement(By.CssSelector("input[type=submit]"));
            searchBtn.Click();
        }

        public bool validateFirstRowUiData(string valueToFind) {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement valueExpected = Driver.driver.FindElement(By.XPath("//table/tbody/tr[2]/td[1]"));
            bool state = false;
            string rowText;
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
