﻿using GeeksDirectory.SharedTypes.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

namespace GeeksDirectory.SharedTypes.Responses
{
    [SwaggerSchemaFilter(typeof(AssessmentResponseSchemaFilter))]
    public class AssessmentResponse
    {
        public int Id { get; set; }

        public string? Author { get; set; }

        public int Score { get; set; }
    }
}