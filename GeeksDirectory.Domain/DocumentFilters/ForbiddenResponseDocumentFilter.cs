using GeeksDirectory.Domain.Responses;
using GeeksDirectory.Domain.SchemaFilters;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.Domain.DocumentFilters
{
    public class ForbiddenResponseDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Components.Schemas.Add(
                key: nameof(ForbiddenErrorResponse),
                value: new OpenApiSchema()
                {
                    Example = SchemaFiltersMock.GetErrorResponse("Forbidden")
                });
        }
    }
}
