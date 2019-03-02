using System;

namespace RESTing.BusinessEntities.Security
{
    public class APIManagedKey
    {
        public int TokenID { get; set; }
        public string APIKey { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserID { get; set; }
        public int KeyStatus { get; set; }
    }
}
