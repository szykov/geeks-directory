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
    public class GetProfileHandler : IRequestHandler<GetProfileQuery, GeekProfileResponse>
    {
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public GetProfileHandler(IProfilesRepository repository, IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<GeekProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = this.repository.GetProfileById(request.ProfileId);
                return this.mapper.Map<GeekProfileResponse>(profile);
            }
            catch (Exception ex) when (ex is KeyNotFoundException || ex is ArgumentException)
            {
                throw new LogicException(ex.Message, ex) { StatusCode = StatusCodes.Status422UnprocessableEntity };
            }
        }
    }
}
