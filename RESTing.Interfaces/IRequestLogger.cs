using RESTing.BusinessEntities.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace RESTing.Interfaces
{
    public interface IRequestLogger
    {
        void InsertLoggingData(APIAccessLog apiAccessLog);
    }
}
