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
        LoginPage lp;
        public DBConexion() {
            lp = new LoginPage();
        }


        public SqlConnection connectToDB() {
            string dataFromJsonFile = lp.getDataFromJsonFile();
            var data = JsonConvert.DeserializeObject<ExternalData>(dataFromJsonFile);
            SqlConnection con = new SqlConnection(data.databaseurl+data.databasename+data.security);
            con.Open();
            return con;
        }
    }
}
