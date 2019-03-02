using System;

namespace RESTing.Common.DTOs
{
    /// <summary>
    /// Conveys if a component operation was successfull or not, also carries
    /// a response message where necessary.
    /// This has been made into a DTO to enable ease of JSON transmission
    /// </summary>
    public class ComponentResponse
    {
        public bool TransactionSuccess { get; set; }
        public string Message { get; set; }
    }
}
