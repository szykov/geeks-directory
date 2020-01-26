﻿using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Responses
{
    public class InternalServerErrorResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = SchemaFiltersMock.GetErrorResponse("InternalServerError");
        }
    }
}
