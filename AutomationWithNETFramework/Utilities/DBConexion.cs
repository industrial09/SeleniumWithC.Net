using System.Data.SqlClient;
using System.Data;
using System.Linq;
using AutomationWithNETFramework.Pages;
using Newtonsoft.Json;
using AutomationWithNETFramework.Hook;

namespace AutomationWithNETFramework.Utilities
{
    public class DBConexion
    {
        public DBConexion(DriverHelper driver) {
            Driver = driver;
            lp = new LoginPage(Driver);
        }

        LoginPage lp;
        DriverHelper Driver;


        public SqlConnection connectToDB() {
            string dataFromJsonFile = lp.getDataFromJsonFile();
            var data = JsonConvert.DeserializeObject<ExternalData>(dataFromJsonFile);
            SqlConnection con = new SqlConnection(data.databaseurl+data.databasename+data.security);
            con.Open();
            return con;
        }
    }
}
