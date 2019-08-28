using GeeksDirectory.SharedTypes.Classes;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Midlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class InternalServerErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public InternalServerErrorHandlingMiddleware(RequestDelegate next, ILogger<InternalServerErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception ex) when (ex.GetBaseException() is SocketException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            catch (Exception ex)
            {
                if (!httpContext.Response.HasStarted)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    httpContext.Response.ContentType = "application/json";

                    this.logger.LogError(ex, $"Internal server error");

                    var jsonSerializer = new JsonSerializerSettings()
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore,
                    };
                    var jsonResult = JsonConvert.SerializeObject(ExceptionCode.InternalServerError, jsonSerializer);

                    await httpContext.Response.WriteAsync(jsonResult);
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class InternalServerErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseInternalServerErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<InternalServerErrorHandlingMiddleware>();
        }
    }
}
