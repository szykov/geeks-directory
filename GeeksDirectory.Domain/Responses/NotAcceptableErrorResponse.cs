using GeeksDirectory.Domain.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

namespace GeeksDirectory.Domain.Responses
{
    [SwaggerSchemaFilter(typeof(NotAcceptableErrorResponseSchemaFilter))]
    public class NotAcceptableErrorResponse : ErrorResponse { }
}
