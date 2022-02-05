using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationWithNETFramework.Utilities
{
    public static class LibraryExtensions
    {
        public static Dictionary<string, string> deserializeResponse(this IRestResponse response)
        {
            //Remember when using global static methods Interfaces type parameters need to be passed
            var deserialize = new JsonDeserializer().Deserialize<Dictionary<string, string>>(response);
            return deserialize;
        }
    }
}
