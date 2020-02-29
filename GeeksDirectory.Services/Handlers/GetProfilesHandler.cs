#pragma warning disable CS1998

using AutoMapper;
using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.Domain.Classes;
using GeeksDirectory.Domain.Extensions;
using GeeksDirectory.Domain.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetProfilesHandler : IRequestHandler<GetProfilesQuery, GeekProfilesResponse>
    {
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public GetProfilesHandler(IProfilesRepository repository, IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }
        
        public async Task<GeekProfilesResponse> Handle(GetProfilesQuery request, CancellationToken cancellationToken)
        {
            var queryOptionsBuilder = new QueryOptionsBuilder()
                .AddLimit(request.Limit)
                .AddOffset(request.Offset)
                .AddOrderDirection(request.OrderDirection);

            var queryOptions = !String.IsNullOrEmpty(request.OrderBy) ?
                queryOptionsBuilder.AddOrderBy<GeekProfile>(request.OrderBy.FirstCharToUpper()).Build() :
                queryOptionsBuilder.Build();

            var profiles = this.repository.GetProfiles(queryOptions);
            var total = this.repository.Total();

            var profileResponses = this.mapper.Map<IEnumerable<GeekProfileResponse>>(profiles);

            return new GeekProfilesResponse()
            {
                Pagination = new PaginationResponse() { Limit = request.Limit, Offset = request.Offset, Total = total },
                Data = profileResponses
            };
        }
    }
}
