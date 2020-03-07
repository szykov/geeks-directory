#pragma warning disable CA1031

using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Responses;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Midlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex) when (ex.GetBaseException() is SocketException)
            {
                httpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                this.logger.LogWarning("Client tried to access unavailable resource. {0}", httpContext.Request.Path);
            }
            catch (Exception ex)
            {
                if (!httpContext.Response.HasStarted)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    logger.LogError(ex, $"Internal server error");
                }
            }
            finally
            {
                this.logger.LogWarning("Server returned status code {0}", httpContext.Response.StatusCode);

                var code = (ExceptionCode)httpContext.Response.StatusCode;
                var jsonSerializerOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true
                };

                var jsonResult = JsonSerializer.Serialize(new ErrorResponse(code), jsonSerializerOptions);

                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(jsonResult);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
