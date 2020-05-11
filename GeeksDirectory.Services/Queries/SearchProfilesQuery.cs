using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Responses;

using MediatR;

using System;
using System.Collections.Generic;

namespace GeeksDirectory.Services.Queries
{
    public class SearchProfilesQuery : IRequest<(IEnumerable<GeekProfileResponse> profiles, long total)>
    {
        public readonly QueryOptions queryOptions;

        public SearchProfilesQuery(string filter, int limit, int offset, string? orderBy, string? orderDirection)
        {
            var queryOptionsBuilder = new QueryOptionsBuilder()
                .AddQuery(filter)
                .AddLimit(limit)
                .AddOffset(offset)
                .AddOrderDirection(orderDirection);

            this.queryOptions = !String.IsNullOrEmpty(orderBy) ?
                queryOptionsBuilder.AddOrderBy<GeekProfile>(orderBy).Build() :
                queryOptionsBuilder.Build();
        }
    }
}
