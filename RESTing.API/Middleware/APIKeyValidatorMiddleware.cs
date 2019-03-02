using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using RESTing.BusinessEntities.Security;
using RESTing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTing.API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ApiKeyValidatorsMiddleware
    {
        private readonly RequestDelegate _next;
        IRequestValidator _irequestValidator { get; set; }
        IRequestLogger _irequestLogger { get; set; }
        public ApiKeyValidatorsMiddleware(RequestDelegate next, IRequestValidator irequestvalidator, IRequestLogger irequestlogger)
        {
            _next = next;
            _irequestValidator = irequestvalidator;
            _irequestLogger = irequestlogger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                var remoteIpAddress = httpContext.Connection.RemoteIpAddress;

                if (httpContext.Request.Path.StartsWithSegments("/api"))
                {
                    var queryString = httpContext.Request.Query;
                    StringValues keyvalue;
                    queryString.TryGetValue("key", out keyvalue);

                    if (httpContext.Request.Method != "POST")
                    {
                        httpContext.Response.StatusCode = 405; //Method Not Allowed               
                        await httpContext.Response.WriteAsync("Method Not Allowed");
                        return;
                    }

                    if (keyvalue.Count == 0)
                    {
                        httpContext.Response.StatusCode = 400; //Bad Request                
                        await httpContext.Response.WriteAsync("API Key is missing");
                        return;
                    }
                    else
                    {
                        string[] serviceName = httpContext.Request.Path.Value.Split('/');



                        if (!_irequestValidator.IsValidServiceRequest(keyvalue, serviceName[2]))
                        {
                            httpContext.Response.StatusCode = 401; //UnAuthorized
                            await httpContext.Response.WriteAsync("Invalid User Key or Request");
                            return;
                        }
                        else if (!_irequestValidator.ValidateKeys(keyvalue))
                        {
                            httpContext.Response.StatusCode = 401; //UnAuthorized
                            await httpContext.Response.WriteAsync("Invalid User Key");
                            return;
                        }
                        else if (!_irequestValidator.ValidateIsServiceActive(keyvalue))
                        {
                            httpContext.Response.StatusCode = 406; //NotAcceptable
                            await httpContext.Response.WriteAsync("Service is Deactived");
                            return;
                        }
                        else if (!_irequestValidator.CalculateCountofRequest(keyvalue))
                        {
                            httpContext.Response.StatusCode = 406; //NotAcceptable
                            await httpContext.Response.WriteAsync("Request Limit Exceeded");
                            return;
                        }
                        else
                        {
                            string[] apiName = httpContext.Request.Path.Value.Split('/');

                            var log = new APIAccessLog()
                            {
                                LogID = 0,
                                ContentType = Convert.ToString(httpContext.Request.ContentType),
                                APIKey = keyvalue,
                                LogDate = DateTime.Now,
                                Host = httpContext.Request.Host.Value,
                                IsHttps = httpContext.Request.IsHttps,
                                Path = httpContext.Request.Path,
                                Method = httpContext.Request.Method,
                                Protocol = httpContext.Request.Protocol,
                                QueryString = httpContext.Request.QueryString.Value,
                                Scheme = httpContext.Request.Scheme,
                                RemoteIPAddress = Convert.ToString(httpContext.Connection.RemoteIpAddress),
                                API = apiName[2],

                            };

                            _irequestLogger.InsertLoggingData(log);

                        }
                    }


                }
                await _next.Invoke(httpContext);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
