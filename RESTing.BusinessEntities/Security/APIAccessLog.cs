using System;
using System.Collections.Generic;
using System.Text;

namespace RESTing.BusinessEntities.Security
{
    public class APIAccessLog
    {
        public int LogID { get; set; }
        public string API { get; set; }
        public string APIKey { get; set; }
        public DateTime LogDate { get; set; }
        public string Host { get; set; }
        public string Protocol { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public string Scheme { get; set; }
        public string QueryString { get; set; }
        public bool IsHttps { get; set; }
        public string RemoteIPAddress { get; set; }
    }
}
