using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Pages
{
    public  class ManageUsers
    {
        DriverHelper Driver;
        public ManageUsers(DriverHelper driver) => this.Driver = driver;

        public void assignRoleToAUser(string userToAssingARole, string roleToBeAssigned) {
            IWebElement table = Driver.driver.FindElement(By.XPath("//table"));
            var rows = table.FindElements(By.TagName("tr"));
            foreach (var row in rows) {
                var cells = row.FindElements(By.TagName("td"));
                for (int i=0; i<cells.Count; i++) {
                    string cellText = cells[1].Text;
                    if (cellText == userToAssingARole)
                    {
                        IWebElement dropdown = cells[2].FindElement(By.TagName("select"));
                        SelectElement select = new SelectElement(dropdown);
                        select.SelectByText(roleToBeAssigned);
                        IWebElement assignButton = cells[3].FindElement(By.TagName("input"));
                        assignButton.Click();
                    }
                } 
            }
        }
    }
}
