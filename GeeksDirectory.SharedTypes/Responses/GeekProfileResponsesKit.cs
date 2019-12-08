using GeeksDirectory.SharedTypes.SchemaFilters.Responses;

using Swashbuckle.AspNetCore.Annotations;

using System.Collections.Generic;

namespace GeeksDirectory.SharedTypes.Responses
{
    [SwaggerSchemaFilter(typeof(GeekProfileResponsesKitSchemaFilter))]
    public class GeekProfileResponsesKit
    {
        public PaginationResponse Pagination { get; set; } = new PaginationResponse();

        public IEnumerable<GeekProfileResponse> Data { get; set; } = new List<GeekProfileResponse>();
    }
}
