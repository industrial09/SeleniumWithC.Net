using AutomationWithNETFramework.Hook;
using AutomationWithNETFramework.Pages;
using AutomationWithNETFramework.Utilities;
using TechTalk.SpecFlow;

[Binding]
public class ManageUsersStepDefs {
    DriverHelper Driver;
    HomePage homepage;
    ManageUsers manageusers;

    public ManageUsersStepDefs(DriverHelper driver, ServerSettings serverSettings)
    {
        this.Driver = driver;
        homepage = new HomePage(this.Driver);
        manageusers = new ManageUsers(this.Driver);
    }

    [Given(@"I navigate to Manage users page")]
    public void GivenINavigateToManagaUsersPage()
    {
        homepage.clickManageUsersTab();
    }

    [Then(@"I assign a (.*) for (.*)")]
    public void ThenIAssignARoleForEmployee(string role, string employeeName)
    {
        manageusers.assignRoleToAUser(employeeName, role);
    }
}