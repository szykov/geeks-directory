using GeeksDirectory.SharedTypes.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

namespace GeeksDirectory.SharedTypes.Responses
{
    [SwaggerSchemaFilter(typeof(PaginationResponseSchemaFilter))]
    public class PaginationResponse
    {
        public int Offset { get; set; }

        public int Limit { get; set; }

        public int Total { get; set; }
    }
}
