using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyProject.Base;

namespace UdemyProject.Config
{
    [JsonObject("testSettings")]
    public class TestSettings
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("aut")]
        public string AUT { get; set; }


        [JsonProperty("browser")]
        public BrowserType Browser { get; set; }


        [JsonProperty("testType")]
        public string TestType { get; set; }
    }
}
