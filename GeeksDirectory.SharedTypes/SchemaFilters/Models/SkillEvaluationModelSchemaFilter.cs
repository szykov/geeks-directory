using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Models
{
    class SkillEvaluationModelSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["name"] = new OpenApiString("python"),
                ["description"] = new OpenApiString("Excepteur sint in culpa id est laborum."),
                ["score"] = new OpenApiInteger(5),
            };
        }
    }
}
