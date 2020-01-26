using GeeksDirectory.SharedTypes.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

using System.Collections.Generic;

namespace GeeksDirectory.SharedTypes.Responses
{
    [SwaggerSchemaFilter(typeof(SkillResponseSchemaFilter))]
    public class SkillResponse
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int AverageScore { get; set; }

        public IEnumerable<AssessmentResponse> Assessments { get; set; } = new List<AssessmentResponse>();
    }
}
