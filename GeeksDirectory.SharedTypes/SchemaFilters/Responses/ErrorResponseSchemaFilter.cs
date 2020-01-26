using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Responses
{
    public class ErrorResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["code"] = new OpenApiString("Namespace.SomeException"),
                ["message"] = new OpenApiString("Oops! Something went wrong."),
                ["target"] = new OpenApiString("Get"),
                ["innerException"] = new OpenApiObject()
                {
                    ["code"] = new OpenApiString("SomeException"),
                    ["message"] = new OpenApiString("Oops! Entity is already there."),
                }
            };
        }
    }
}
