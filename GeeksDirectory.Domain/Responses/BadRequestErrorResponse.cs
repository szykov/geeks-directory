using GeeksDirectory.Domain.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

namespace GeeksDirectory.Domain.Responses
{
    [SwaggerSchemaFilter(typeof(BadRequestErrorResponseSchemaFilter))]
    public class BadRequestErrorResponse : ErrorResponse { }
}
