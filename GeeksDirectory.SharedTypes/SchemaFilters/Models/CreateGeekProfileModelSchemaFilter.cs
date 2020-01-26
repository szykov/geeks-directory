using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Models
{
    public class CreateGeekProfileModelSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["email"] = new OpenApiString("sergey.zykov@mail.some"),
                ["password"] = new OpenApiString("Pa$$w0rd")
            };
        }
    }
}
