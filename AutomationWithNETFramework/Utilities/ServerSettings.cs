using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Utilities
{
    public class ServerSettings
    {
        public RestClient client { get; set; }
        public RestRequest request { get; set; }
    }
}
