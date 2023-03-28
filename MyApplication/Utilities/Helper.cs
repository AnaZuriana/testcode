using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace MyApplication.Utilities
{
    public class Helper
    {
        public static string GetApiUrl()
        {
            return ConfigurationManager.AppSettings["HostProtocol"] + "://" + ConfigurationManager.AppSettings["HostAddress"];
        }
    }
}