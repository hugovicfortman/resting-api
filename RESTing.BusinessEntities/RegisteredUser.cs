using System;
using System.Collections.Generic;
using System.Text;
using RESTing.BusinessEntities.Base;
using RESTing.Common.Enums;

namespace RESTing.BusinessEntities
{
    public class RegisteredUser : BusinessEntity
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
