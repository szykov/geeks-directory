using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.Domain.SchemaFilters.Responses
{
    public class GeekProfileResponsesKitSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["pagination"] = SchemaFiltersMock.GetPaginationResponse(),
                ["data"] = SchemaFiltersMock.GetGeekProfileResponse()
            };
        }
    }
}
