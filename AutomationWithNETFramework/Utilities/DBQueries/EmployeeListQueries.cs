using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Utilities.DBQueries
{
    public class EmployeeListQueries
    {
        public string getQuery(string option, string variableVar) {
            switch (option) {
                case "getOneAuthor": return "select author from authordata where author = '"+variableVar+"'";
                    break;
                default: return "Not a valid option";
                    break;
            }
        }
        //public static string selectAuthor = "select author from authordata where author = 'Karthik KK'";
    }
}
