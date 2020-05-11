using GeeksDirectory.Domain.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

namespace GeeksDirectory.Domain.Responses
{
    [SwaggerSchemaFilter(typeof(AssessmentResponseSchemaFilter))]
    public class AssessmentResponse
    {
        public int Id { get; set; }

        public string Email { get; set; } = default!;

        public int Score { get; set; }
    }
}