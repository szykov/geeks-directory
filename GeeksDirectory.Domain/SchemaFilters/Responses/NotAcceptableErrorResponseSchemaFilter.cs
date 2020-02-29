using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.Domain.SchemaFilters.Responses
{
    public class NotAcceptableErrorResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = SchemaFiltersMock.GetErrorResponse("NotAcceptable");
        }
    }
}
