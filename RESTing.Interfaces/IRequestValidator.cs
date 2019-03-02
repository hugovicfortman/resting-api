using System;
using System.Collections.Generic;
using System.Text;

namespace RESTing.Interfaces
{
    public interface IRequestValidator
    {
        bool ValidateKeys(string Key);

        bool IsValidServiceRequest(string Key, string ServiceName);

        bool ValidateIsServiceActive(string Key);

        bool CalculateCountofRequest(string Key);
    }
}
