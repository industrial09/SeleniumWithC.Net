using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;
using System;
using UdemyProject.Base;

namespace AutomationWithNETFramework.Pages
{
    public class HomePage
    {
        //DriverHelper Driver;

        /*public HomePage(DriverHelper driver) {
            Driver = driver;
        }*/ 
 
        public void clickEmployeeListTab()
        {
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            IWebElement accountActivityTab = DriverContext.Driver.FindElement(By.XPath("//a[contains(text(),'Employee List')]"));
            accountActivityTab.Click();
        }

        public void clickManageUsersTab() {
            IWebElement manageUsersTab = DriverContext.Driver.FindElement(By.XPath("//a[contains(text(),'Manage Users')]"));
            manageUsersTab.Click();
        } 
    }
}
