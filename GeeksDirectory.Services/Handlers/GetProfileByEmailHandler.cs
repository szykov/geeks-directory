#pragma warning disable CS1998

using AutoMapper;

using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Domain.Responses;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetProfileByEmailHandler : IRequestHandler<GetProfileByEmailQuery, GeekProfileResponse>
    {
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public GetProfileByEmailHandler(
            IProfilesRepository repository,
            IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<GeekProfileResponse> Handle(GetProfileByEmailQuery request, CancellationToken cancellationToken)
        {
            var profile = this.repository.GetProfileByUserName(request.Email);
            return this.mapper.Map<GeekProfileResponse>(profile);
        }
    }
}
