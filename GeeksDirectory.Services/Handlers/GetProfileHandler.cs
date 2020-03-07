#pragma warning disable CS1998

using AutoMapper;

using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Mappings;
using GeeksDirectory.Services.Queries;
using GeeksDirectory.Domain.Responses;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class GetProfileHandler : IRequestHandler<GetProfileQuery, GeekProfileResponse?>
    {
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public GetProfileHandler(IProfilesRepository repository, IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<GeekProfileResponse?> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var profile = this.repository.GetProfileById(request.ProfileId);
            return this.mapper.Map<GeekProfileResponse?>(profile);
        }
    }
}
