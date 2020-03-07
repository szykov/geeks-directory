#pragma warning disable CS1998

using AutoMapper;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Responses;

using MediatR;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class SearchHandler : IRequestHandler<SearchQuery, GeekProfilesResponse>
    {
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public SearchHandler(IProfilesRepository repository, IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<GeekProfilesResponse> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            var queryOptionsBuilder = new QueryOptionsBuilder()
                .AddQuery(request.Filter)
                .AddLimit(request.Limit)
                .AddOffset(request.Offset)
                .AddOrderDirection(request.OrderDirection);

            var queryOptions = !String.IsNullOrEmpty(request.OrderBy) ?
                queryOptionsBuilder.AddOrderBy<GeekProfile>(request.OrderBy).Build() :
                queryOptionsBuilder.Build();

            var profiles = this.repository.Search(queryOptions, out var total);
            var profileResponses = this.mapper.Map<IEnumerable<GeekProfileResponse>>(profiles);

            return new GeekProfilesResponse()
            {
                Pagination = new PaginationResponse() { Limit = request.Limit, Offset = request.Offset, Total = total },
                Data = profileResponses
            };
        }
    }
}
