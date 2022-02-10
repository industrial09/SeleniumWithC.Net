using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;
using System;

namespace AutomationWithNETFramework.Pages
{
    public class HomePage
    {
        DriverHelper Driver;

        public HomePage(DriverHelper driver) => Driver = driver;
 
        public void clickEmployeeListTab()
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement accountActivityTab = Driver.driver.FindElement(By.XPath("//a[contains(text(),'Employee List')]"));
            accountActivityTab.Click();
        }

        public void clickManageUsersTab() {
            IWebElement manageUsersTab = Driver.driver.FindElement(By.XPath("//a[contains(text(),'Manage Users')]"));
            manageUsersTab.Click();
        } 
    }
}
