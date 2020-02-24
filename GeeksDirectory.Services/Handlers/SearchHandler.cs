#pragma warning disable CS1998

using AutoMapper;
using GeeksDirectory.Data.Entities;
using GeeksDirectory.Data.Repositories.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.SharedTypes.Classes;
using GeeksDirectory.SharedTypes.Responses;

using MediatR;

using Microsoft.AspNetCore.Http;

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
            try
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
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
