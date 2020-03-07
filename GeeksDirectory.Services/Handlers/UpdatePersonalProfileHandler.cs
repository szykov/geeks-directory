#pragma warning disable CS1998

using AutoMapper;

using FluentResults;

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Services.Commands;
using GeeksDirectory.Services.Mappings;

using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System.Threading;
using System.Threading.Tasks;

namespace GeeksDirectory.Services.Handlers
{
    public class UpdatePersonalProfileHandler : IRequestHandler<UpdatePersonalProfileCommand, Result<int>>
    {
        private readonly HttpContext httpContext;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProfilesRepository repository;
        private readonly IMapper mapper;

        public UpdatePersonalProfileHandler(
            IHttpContextAccessor httpContextAccessor,
            UserManager<ApplicationUser> userManager,
            IProfilesRepository repository, IMapperService mapperService)
        {
            this.httpContext = httpContextAccessor.HttpContext;
            this.userManager = userManager;
            this.repository = repository;
            this.mapper = mapperService.GetDataMapper();
        }

        public async Task<Result<int>> Handle(UpdatePersonalProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(httpContext.User);
            var entity = this.repository.GetProfileByUserName(user.Email);

            if (entity is null)
                return Results.Fail("Profile doesn't exist.");

            this.mapper.Map(request.Profile, entity);
            this.repository.Update(entity);

            return Results.Ok(entity.ProfileId);
        }
    }
}
