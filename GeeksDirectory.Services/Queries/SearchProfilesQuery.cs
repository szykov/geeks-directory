using GeeksDirectory.Domain.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class SearchProfilesQuery : IRequest<GeekProfilesResponse>
    {
        public readonly string Filter;
        public readonly int Limit;
        public readonly int Offset;
        public readonly string? OrderBy;
        public readonly string? OrderDirection;

        public SearchProfilesQuery(string filter, int limit, int offset, string? orderBy, string? orderDirection)
        {
            this.Filter = filter;
            this.Limit = limit;
            this.Offset = offset;
            this.OrderBy = orderBy;
            this.OrderDirection = orderDirection;
        }
    }
}
