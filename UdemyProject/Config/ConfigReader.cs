using Microsoft.Extensions.Configuration;
using System.IO;

namespace UdemyProject.Config
{
    public class ConfigReader
    {
        public static void SetFrameworkSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(@"C:\Users\Christian Bautista\OneDrive - Cox Automotive\Documents\nagarro\RestSharp and RestAssured\SeleniumWithSharpNet\AutomationWithNETFramework\")
                .AddJsonFile("appsettings.json");


            IConfigurationRoot configurationRoot = builder.Build();


            Settings.AUT = configurationRoot.GetSection("testSettings").Get<TestSettings>().AUT;
            Settings.BrowserType = configurationRoot.GetSection("testSettings").Get<TestSettings>().Browser;

            /*Settings.AUT = EATestConfiguration.EASettings.TestSettings["staging"].AUT;
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), EATestConfiguration.EASettings.TestSettings["staging"].Browser);*/

        }
    }
}
