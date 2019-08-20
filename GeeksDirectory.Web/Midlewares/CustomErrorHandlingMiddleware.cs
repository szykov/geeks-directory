using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Responses;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using System.Threading.Tasks;

namespace GeeksDirectory.Web.Midlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;

        public CustomErrorHandlingMiddleware(RequestDelegate next, ILogger<InternalServerErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await this.next.Invoke(httpContext);

            if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
            {
                this.logger.LogWarning("Client tried to access unavailable resource. {0}", httpContext.Request.Path);

                return;
            }

            if (!httpContext.Response.HasStarted)
            {
                this.logger.LogWarning("Server returned status code {0}", httpContext.Response.StatusCode);

                var code = (ExceptionCode)httpContext.Response.StatusCode;

                var jsonResult = JsonConvert.SerializeObject(
                    new ErrorResponse()
                    {
                        Code = code.ToString(),
                        Message = "We can't seem to find the answer you're looking for."
                    },
                    new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });

                httpContext.Response.ContentType = "application/json";

                await httpContext.Response.WriteAsync(jsonResult);
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomErrorHandlingMiddleware>();
        }
    }
}
