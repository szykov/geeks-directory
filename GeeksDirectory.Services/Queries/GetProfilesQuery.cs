using GeeksDirectory.SharedTypes.Responses;

using MediatR;

namespace GeeksDirectory.Services.Queries
{
    public class GetProfilesQuery : IRequest<GeekProfilesResponse>
    {
        public readonly int Limit;
        public readonly int Offset;
        public readonly string? OrderBy;
        public readonly string? OrderDirection;

        public GetProfilesQuery(int limit, int offset, string? orderBy, string? orderDirection)
        {
            this.Limit = limit;
            this.Offset = offset;
            this.OrderBy = orderBy;
            this.OrderDirection = orderDirection;
        }
    }
}
