using System;
using System.Collections.Generic;
using System.Text;

namespace RESTing.BusinessEntities.Base
{
    public class Customer : BusinessEntity
    {
        public int CustomerID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Address { get; set; }
        public int? PersonID { get; set; }
        public virtual Person Person { get; set; }
        public int? CompanyID { get; set; }
        public virtual Company Company { get; set; }
    }
}
