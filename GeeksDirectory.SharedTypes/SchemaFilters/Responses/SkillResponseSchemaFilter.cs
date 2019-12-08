using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Responses
{
    internal class SkillResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["id"] = new OpenApiInteger(1),
                ["name"] = new OpenApiString("python"),
                ["description"] = new OpenApiString("Excepteur sint in culpa id est laborum."),
                ["averageScore"] = new OpenApiInteger(4),
                ["assessments"] = SchemaFiltersMock.GetAssessments()
            };
        }
    }
}
