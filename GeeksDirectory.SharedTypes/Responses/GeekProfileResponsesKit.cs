using System.Collections.Generic;

namespace GeeksDirectory.SharedTypes.Responses
{
    public class GeekProfileResponsesKit
    {
        public PaginationResponse Pagination { get; set; } = new PaginationResponse();

        public IEnumerable<GeekProfileResponse> Data { get; set; } = new List<GeekProfileResponse>();
    }
}
