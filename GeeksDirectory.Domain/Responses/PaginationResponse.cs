using GeeksDirectory.Domain.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

namespace GeeksDirectory.Domain.Responses
{
    [SwaggerSchemaFilter(typeof(PaginationResponseSchemaFilter))]
    public class PaginationResponse
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }
    }
}
