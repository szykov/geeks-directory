#pragma warning disable CS1998

using AutoMapper;

using FluentResults;

using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Commands;
using GeeksDirectory.Services.Mappings;

using MediatR;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class UpdateProfileHandler : IRequestHandler<UpdateProfileCommand, Result<long>>
    {
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public UpdateProfileHandler(
            IProfilesRepository repository, IMapperService mapperService)
        {
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<Result<long>> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var entity = this.repository.GetProfileById(request.ProfileId);

            if (entity is null)
                return Results.Fail("Profile doesn't exist.");

            this.mapper.Map(request.Profile, entity);
            this.repository.Update(entity);

            return Results.Ok(entity.Id);
        }
    }
}
