using AutoMapper;

using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Mappings;
using GeeksDirectory.SharedTypes.Responses;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System.Text.Json;
using System.Threading.Tasks;

namespace GeeksDirectory.Web.Midlewares
{
    public class LogicErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger logger;
        private readonly IMapper mapper;

        public LogicErrorHandlingMiddleware(RequestDelegate next, ILogger<InternalServerErrorHandlingMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ExceptionMapProfile>();
            });

            mapper = new Mapper(config);
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (LogicException ex)
            {
                if (!httpContext.Response.HasStarted)
                {
                    httpContext.Response.StatusCode = ex.StatusCode;
                    httpContext.Response.ContentType = "application/json";

                    logger.LogError(ex, $"Logic Exception appeared in ${httpContext.GetEndpoint().DisplayName}");

                    var jsonSerializerOptions = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        IgnoreNullValues = true
                    };

                    var jsonResult = JsonSerializer.Serialize(mapper.Map<ErrorResponse>(ex), jsonSerializerOptions);

                    await httpContext.Response.WriteAsync(jsonResult);
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class LogicErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogicErrorHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogicErrorHandlingMiddleware>();
        }
    }
}
