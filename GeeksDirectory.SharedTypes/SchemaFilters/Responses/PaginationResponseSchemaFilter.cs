﻿using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace GeeksDirectory.SharedTypes.SchemaFilters.Responses
{
    internal class PaginationResponseSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            schema.Example = SchemaFiltersMock.GetPaginationResponse();
        }
    }
}
