using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Responses
{
    public class BadRequestErrorResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["code"] = new OpenApiString("BadRequest"),
                ["message"] = new OpenApiString("Model state is invalid"),
                ["details"] = new OpenApiArray()
                {
                    new OpenApiObject()
                    {
                        ["message"] = new OpenApiString("The field Name is required."),
                        ["target"] = new OpenApiString("Name")
                    },
                    new OpenApiObject()
                    {
                        ["message"] = new OpenApiString("The field Name must be a string with a minimum length of 3 and a maximum length of 100."),
                        ["target"] = new OpenApiString("Name")
                    },
                    new OpenApiObject()
                    {
                        ["message"] = new OpenApiString("The field Password must be a string with a minimum length of 10 and a maximum length of 255."),
                        ["target"] = new OpenApiString("Password")
                    },
                    new OpenApiObject()
                    {
                        ["message"] = new OpenApiString("The field Password should have special characters."),
                        ["target"] = new OpenApiString("Password")
                    }
                }
            };
        }
    }
}
