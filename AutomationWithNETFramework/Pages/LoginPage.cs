using AutomationWithNETFramework.Hook;
using OpenQA.Selenium;

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
    }
}
