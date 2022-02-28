using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationWithNETFramework.Pages
{
    public class LandingPage
    {
        //DriverHelper Driver;

        /*public LandingPage(DriverHelper driver)
        {
            this.Driver = driver;
        }*/

        public void clickLoginLink() {
            IWebElement el = DriverHelper.Driver.FindElement(By.Id("loginLink"));
            el.Click();
            Thread.Sleep(2000);
        } 
    }
}
