using System;
using System.Collections.Generic;
using System.Text;
using RESTing.BusinessEntities.Utility;

namespace RESTing.BusinessEntities.Base
{
    public abstract class Person : BusinessEntity
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderID { get; set; }
        public virtual Gender Gender { get; set; }
        public int? Age { get; set; }
    }
}
