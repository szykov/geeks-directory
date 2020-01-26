using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Responses
{
    public class AssessmentResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["id"] = new OpenApiInteger(1),
                ["author"] = new OpenApiString("78988724-2d03-41b2-b678-df86c7332a5d"),
                ["score"] = new OpenApiInteger(5)
            };
        }
    }
}
