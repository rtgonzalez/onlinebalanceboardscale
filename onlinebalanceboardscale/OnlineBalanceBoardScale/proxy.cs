using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Configuration;

namespace OnlineBalanceBoardScale
{
    public class proxy : IWebProxy
    {
        public System.Net.ICredentials Credentials
        {
            get
            {
                return new NetworkCredential(ConfigurationSettings.AppSettings.Get("ProxyUser"), ConfigurationSettings.AppSettings.Get("ProxyPass"), ConfigurationSettings.AppSettings.Get("ProxyDomain"));

            }
            set
            {
            }
        }
        public Uri GetProxy(System.Uri destination)
        {
            return new Uri(ConfigurationSettings.AppSettings.Get("ProxyAddress"));
        }
        public Boolean IsBypassed(System.Uri host)
        {
            return false;
        }
    }
}
