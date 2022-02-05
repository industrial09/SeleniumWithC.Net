using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationWithNETFramework
{   
    [TestFixture]
    public class Tests: DriverHelper
    {
        [SetUp]
        public void setup() {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://zero.webappsecurity.com/");
            /*LandingPage.clickLoginLink();
            LoginPage.enterUsername("username");
            LoginPage.enterPassword("password");
            LoginPage.clickKeepMeSignedIn();
            LoginPage.clicksignInBtn();
            HandleInsecurePage.clickUnsafeProceedToPage();*/
        }

        [Test]
        public void accountActivityTest()
        {
            /*AccountSummary.clickAccountActivityTab();
            AccountActivity.selectAccountType("Loan");
            //Look for NUnit Docs https://docs.nunit.org/2.6.4/assertions.html
            Assert.That(AccountActivity.validateDataDisplayed("RENT"), Is.True);*/
        }

        /*[Test]
        public void TransferFundsTest() {
            TransferFunds.clickTransferFundsTab();
        }

        [Test]
        public void payBillsTest()
        {
            AccountSummary.clickPayBillsTab();
            PayBills.selectPayee("Bank of America");
            PayBills.selectAccount("Credit Card");
            PayBills.enterAmount(349);
            PayBills.enterDate("06-02-2022");
            PayBills.enterDescription("Internet payment");
            PayBills.clickPayButton();
        }

        [TearDown]
        public void close() {
            LandingPage.closeBrowser();
        }*/
    }
}