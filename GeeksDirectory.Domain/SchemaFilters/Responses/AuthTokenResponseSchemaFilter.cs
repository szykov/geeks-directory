using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.Domain.SchemaFilters.Responses
{
    public class AuthTokenResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["token_type"] = new OpenApiString("Bearer"),
                ["access_token"] = new OpenApiString("CfDJ8HSQou_vc21JsI......cmGdpmmTGSSlCzhNaudYDdJpQ"),
                ["expires_in"] = new OpenApiInteger(3600)
            };
        }
    }
}
