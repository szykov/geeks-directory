using GeeksDirectory.SharedTypes.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

namespace GeeksDirectory.SharedTypes.Responses
{
    [SwaggerSchemaFilter(typeof(BadRequestErrorResponseSchemaFilter))]
    public class BadRequestErrorResponse : ErrorResponse { }
}
