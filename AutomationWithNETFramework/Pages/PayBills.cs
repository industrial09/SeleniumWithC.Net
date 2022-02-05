using AutomationWithNETFramework.Hook;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Pages
{
    public class PayBills
    {
        /*static IWebElement payeeDropdown = driver.FindElement(By.Id("sp_payee"));
        static IWebElement accountDropdown = driver.FindElement(By.Id("sp_account"));
        static IWebElement amountTbox = driver.FindElement(By.Id("sp_amount"));
        static IWebElement dateTbox = driver.FindElement(By.Id("sp_date")); 
        static IWebElement descriptionTbox = driver.FindElement(By.Id("sp_description"));
        static IWebElement payButton = driver.FindElement(By.Id("pay_saved_payees"));
        static IWebElement successfulPaymentAlert = driver.FindElement(By.Id("alert_content"));

        public static void selectPayee(string payeeOption) {
            SelectElement select = new SelectElement(payeeDropdown);
            select.SelectByText(payeeOption);
        }

        public static void selectAccount(string accountOption)
        {
            SelectElement select = new SelectElement(accountDropdown);
            select.SelectByText(accountOption);
        }

        public static void enterAmount(int amountToenter) => amountTbox.SendKeys(Convert.ToString(amountToenter));

        public static void enterDate(string date) => dateTbox.SendKeys(date);

        public static void enterDescription(string description) => descriptionTbox.SendKeys(description);

        public static void clickPayButton() => payButton.Click();

        public static void validateSuccessfulPayment() {
            bool state = successfulPaymentAlert.Displayed;
            Assert.That(state, Is.True);
        }*/
    }
}
