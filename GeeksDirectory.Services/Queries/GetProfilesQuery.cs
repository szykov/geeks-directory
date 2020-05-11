using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Extensions;
using GeeksDirectory.Domain.Responses;

using MediatR;
using System;
using System.Collections.Generic;

namespace GeeksDirectory.Services.Queries
{
    public class GetProfilesQuery : IRequest<(IEnumerable<GeekProfileResponse> profiles, long total)>
    {
        public readonly QueryOptions queryOptions;

        public GetProfilesQuery(int limit, int offset, string? orderBy, string? orderDirection)
        {
            var queryOptionsBuilder = new QueryOptionsBuilder()
                .AddLimit(limit)
                .AddOffset(offset)
                .AddOrderDirection(orderDirection);

            this.queryOptions = !String.IsNullOrEmpty(orderBy) ?
                queryOptionsBuilder.AddOrderBy<GeekProfile>(orderBy.FirstCharToUpper()).Build() :
                queryOptionsBuilder.Build();
        }
    }
}
