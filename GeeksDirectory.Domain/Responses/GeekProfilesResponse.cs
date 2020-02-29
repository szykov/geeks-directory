using GeeksDirectory.Domain.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

using System.Collections.Generic;

namespace GeeksDirectory.Domain.Responses
{
    [SwaggerSchemaFilter(typeof(GeekProfileResponsesKitSchemaFilter))]
    public class GeekProfilesResponse
    {
        public PaginationResponse Pagination { get; set; } = new PaginationResponse();

        public IEnumerable<GeekProfileResponse> Data { get; set; } = new List<GeekProfileResponse>();
    }
}
