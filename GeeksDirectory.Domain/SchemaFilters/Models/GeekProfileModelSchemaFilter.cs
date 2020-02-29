using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.Domain.SchemaFilters.Models
{
    public class GeekProfileModelSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = new OpenApiObject()
            {
                ["name"] = new OpenApiString("Sergey"),
                ["surname"] = new OpenApiString("Zykov"),
                ["middleName"] = new OpenApiString("Sergey Zykov Aleksandrovich"),
                ["city"] = new OpenApiString("Moscow"),
            };
        }
    }
}
