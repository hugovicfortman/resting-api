using System;
using System.Collections.Generic;
using System.Text;

namespace RESTing.BusinessEntities.Base
{
    public abstract class Company : BusinessEntity
    {
        public string CompanyName { get; set; }
    }
}
